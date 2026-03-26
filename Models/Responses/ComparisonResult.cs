using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control.Models.Entities;

namespace Control.Models.Responses
{
    public class ComparisonResult
    {
        public List<ItemAnexo> CorrectItems { get; set; } = new();
        public List<MismatchedDetail> MismatchedItems { get; set; } = new();
        public List<ItemAnexo> MissingItems { get; set; } = new();
        public List<ItemAnexo> ExtraItems { get; set; } = new();
        public List<ItemAnexo> ResultItems { get; set; } = new(); // Para retornar el listado del anexo que falta comparar (CompareItemsNew)
                

        static public ComparisonResult CompareItems(List<ItemAnexo> items, List<ItemAnexo> itemsReceived)
        {
            var result = new ComparisonResult();
            var usedReceived = new HashSet<ItemAnexo>(); // guardamos referencias a los recibidos ya usados

            // Agrupamos los esperados por código para procesar por grupo
            var expectedGroups = items.GroupBy(x => x.CodItem).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kv in expectedGroups)
            {
                var code = kv.Key;
                var expectedList = kv.Value;
                var receivedList = itemsReceived.Where(x => x.CodItem == code).ToList();

                if (receivedList.Count == 0)
                {
                    // no hay ninguno recibido con ese código -> todos faltan
                    result.MissingItems.AddRange(expectedList);
                    continue;
                }

                var expMatched = new bool[expectedList.Count];
                var recUsed = new bool[receivedList.Count];

                // 1) Exact matches (serial + qty + dueDate)
                for (int i = 0; i < expectedList.Count; i++)
                {
                    if (expMatched[i]) continue;
                    for (int j = 0; j < receivedList.Count; j++)
                    {
                        if (recUsed[j]) continue;
                        if (AreExact(expectedList[i], receivedList[j]))
                        {
                            result.CorrectItems.Add(expectedList[i]);
                            expMatched[i] = true;
                            recUsed[j] = true;
                            usedReceived.Add(receivedList[j]);

                            // Agrego los ítems al listado de resultado final

                            break;
                        }
                    }
                }

                // 2) Match por serial (si existe)
                for (int i = 0; i < expectedList.Count; i++)
                {
                    if (expMatched[i]) continue;
                    for (int j = 0; j < receivedList.Count; j++)
                    {
                        if (recUsed[j]) continue;
                        if (StrEq(expectedList[i].SerialNumber, receivedList[j].SerialNumber))
                        {
                            var e = expectedList[i]; // ItemAnexo esperado
                            var r = receivedList[j]; // ItemAnexo recibido

                            result.MismatchedItems.Add(new MismatchedDetail
                            {
                                Expected = e,
                                Received = r,
                                SerialNumberDiffers = false,
                                QuantityDiffers = e.Quantity != r.Quantity,
                                DueDateDiffers = !DateEq(e.DueDate, r.DueDate)
                            });
                            expMatched[i] = true;
                            recUsed[j] = true;
                            usedReceived.Add(r);
                            break;
                        }
                    }
                }

                // 3) Emparejamiento "global" heurístico (greedy: elegir el par con menor costo repetidamente)
                var remainingExpIdx = Enumerable.Range(0, expectedList.Count).Where(i => !expMatched[i]).ToList();
                var remainingRecIdx = Enumerable.Range(0, receivedList.Count).Where(j => !recUsed[j]).ToList();

                while (remainingExpIdx.Count > 0 && remainingRecIdx.Count > 0)
                {
                    int bestE = -1, bestR = -1, bestCost = int.MaxValue;
                    foreach (var i in remainingExpIdx)
                    {
                        foreach (var j in remainingRecIdx)
                        {
                            int cost = DifferenceCost(expectedList[i], receivedList[j]);
                            if (cost < bestCost)
                            {
                                bestCost = cost;
                                bestE = i;
                                bestR = j;
                                if (bestCost == 0) break; // no podemos mejorar
                            }
                        }
                        if (bestCost == 0) break;
                    }

                    if (bestE == -1) break; // seguridad
                    var eSel = expectedList[bestE];
                    var rSel = receivedList[bestR];

                    // si cost == 0 sería exacto (aunque ya buscamos exactos), manejamos como correct o mismatched según corresponda
                    result.MismatchedItems.Add(new MismatchedDetail
                    {
                        Expected = eSel,
                        Received = rSel,
                        SerialNumberDiffers = !StrEq(eSel.SerialNumber, rSel.SerialNumber),
                        QuantityDiffers = eSel.Quantity != rSel.Quantity,
                        DueDateDiffers = !DateEq(eSel.DueDate, rSel.DueDate)
                    });

                    expMatched[bestE] = true;
                    recUsed[bestR] = true;
                    usedReceived.Add(rSel);

                    remainingExpIdx.Remove(bestE);
                    remainingRecIdx.Remove(bestR);
                }

                // 4) Lo que quedó de expected -> Missing
                for (int i = 0; i < expectedList.Count; i++)
                    if (!expMatched[i]) result.MissingItems.Add(expectedList[i]);

                // Nota: los received "no usados" se añadirán como ExtraItems al final (comparando con usedReceived).
            }

            // Extras: todos los recibidos que NO fueron usados
            foreach (var r in itemsReceived)
                if (!usedReceived.Contains(r))
                    result.ExtraItems.Add(r);

            return result;
        }

        static bool StrEq(string a, string b) =>
        string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);

        static bool DateEq(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
                return true;
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
                return false;

            if (DateTime.TryParse(a, out var da) && DateTime.TryParse(b, out var db))
                return da.Date == db.Date;  // compara solo la fecha (ignora la hora)

            // si no se pueden parsear, comparamos como string "plano"
            return string.Equals(a.Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase);
        }


        static bool AreExact(ItemAnexo e, ItemAnexo r) =>
        StrEq(e.SerialNumber, r.SerialNumber)
        && e.Quantity == r.Quantity
        && DateEq(e.DueDate, r.DueDate);


        static int DifferenceCost(ItemAnexo e, ItemAnexo r)
        {
            int c = 0;
            if (!StrEq(e.SerialNumber, r.SerialNumber)) c++;
            if (e.Quantity != r.Quantity) c++;
            if (!DateEq(e.DueDate, r.DueDate)) c++;
            return c;
        }

        public static ComparisonResult CompareItemsNew(List<ItemAnexo> items, List<ItemAnexo> itemsReceived)
        {
            var result = new ComparisonResult();

            RemoveExactItems(items, itemsReceived);

            FindSerialEqualItems(items, itemsReceived, result);

            return result;

            //return new List<ItemAnexo>();
        }

        private static void FindSerialEqualItems(List<ItemAnexo> items, List<ItemAnexo> itemsReceived, ComparisonResult result)
        {
            List<ItemAnexo> receivedCopy = itemsReceived.Select(x => x.Clone()).ToList();

            foreach (var item in receivedCopy)
            {

                // Verifico que solo difiera la cantidad
                ItemAnexo? itemEqual = items.FirstOrDefault(x => StrEq(x.CodItem, item.CodItem) && StrEq(x.SerialNumber, item.SerialNumber) && DateEq(x.DueDate, item.DueDate));

                if (itemEqual != null)
                {
                    ItemAnexo? itemReceivedEqual = itemsReceived.FirstOrDefault(x => StrEq(x.CodItem, item.CodItem) && StrEq(x.SerialNumber, item.SerialNumber) && DateEq(x.DueDate, item.DueDate));

                    MismatchedDetail mismatchedDetail = new MismatchedDetail();
                    mismatchedDetail.Received = itemReceivedEqual;
                    mismatchedDetail.Expected = itemEqual;
                    mismatchedDetail.SerialNumberDiffers = false;
                    mismatchedDetail.QuantityDiffers = itemEqual.Quantity != itemReceivedEqual.Quantity;
                    mismatchedDetail.DueDateDiffers = false;

                    result.MismatchedItems.Add(mismatchedDetail);

                    if (itemEqual.Quantity == itemReceivedEqual.Quantity) continue;

                    // Significa que hay más unidades en stock que real (al menos en esta tanda, el usuario puede cargar más unidades)
                    if (itemEqual.Quantity > itemReceivedEqual.Quantity)
                    {
                        itemEqual.Quantity -= itemReceivedEqual.Quantity;
                        itemsReceived.Remove(itemReceivedEqual);
                    }
                    else
                    {
                        itemReceivedEqual.Quantity -= itemEqual.Quantity;
                        items.Remove(itemEqual);
                    }



                }

            }
        }

        private static void RemoveExactItems(List<ItemAnexo> items, List<ItemAnexo> itemsReceived)
        {
            List<ItemAnexo> receivedCopy = itemsReceived.Select(x => x.Clone()).ToList();

            foreach (var item in receivedCopy)
            {
                ItemAnexo? itemEqual = items.FirstOrDefault(x => StrEq(x.CodItem, item.CodItem) && StrEq(x.SerialNumber, item.SerialNumber) && x.Quantity == item.Quantity && DateEq(x.DueDate, item.DueDate));

                if (itemEqual != null)
                {
                    ItemAnexo? itemReceivedEqual = itemsReceived.FirstOrDefault(x => x.CodItem == item.CodItem && x.SerialNumber == item.SerialNumber);

                    items.Remove(itemEqual);
                    itemsReceived.Remove(itemReceivedEqual);
                }
            }
        }

        public bool IsComparisonCorrect()
        {
            return (CorrectItems.Count > 0 && MismatchedItems.Count() == 0 && MissingItems.Count() == 0 && ExtraItems.Count() == 0);
        }
    }

    public class MismatchedDetail
    {
        public ItemAnexo Expected { get; set; }
        public ItemAnexo Received { get; set; }
        public bool SerialNumberDiffers { get; set; }
        public bool QuantityDiffers { get; set; }
        public bool DueDateDiffers { get; set; }
    }


}
