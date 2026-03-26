using Control.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Responses
{
    /// <summary>
    /// Clase pensada para Valijas AB en donde los bilaterales no se unifican en la pestaña Anexo.
    /// </summary>
    public static class InventoryComparer
    {
        // Clase privada para rastrear qué cantidad de cada fila ya fue procesada
        private class TrackedItem
        {
            public ItemAnexo Original { get; set; }
            public decimal RemainingQty { get; set; }

            public TrackedItem(ItemAnexo item)
            {
                Original = item;
                RemainingQty = item.Quantity; // Iniciamos con la cantidad total de la fila
            }
        }

        public static ComparisonResult CompareLists(List<ItemAnexo> expectedItems, List<ItemAnexo> receivedItems)
        {
            var result = new ComparisonResult();

            // 1. Envolvemos los items para rastrear sus cantidades restantes
            var expTracked = expectedItems.Select(x => new TrackedItem(x)).ToList();
            var recTracked = receivedItems.Select(x => new TrackedItem(x)).ToList();

            // 2. FASE 1: Coincidencias Exactas (Código, Serie y Vencimiento)
            foreach (var exp in expTracked.Where(e => e.RemainingQty > 0))
            {
                var exactMatches = recTracked.Where(r => r.RemainingQty > 0 &&
                                                         StrEq(exp.Original.CodItem, r.Original.CodItem) &&
                                                         StrEq(exp.Original.SerialNumber, r.Original.SerialNumber) &&
                                                         DateEq(exp.Original.DueDate, r.Original.DueDate)).ToList();

                foreach (var rec in exactMatches)
                {
                    if (exp.RemainingQty == 0) break;

                    // Tomamos la cantidad que podamos solventar (la menor entre lo que falta y lo que hay)
                    decimal matchedQty = Math.Min(exp.RemainingQty, rec.RemainingQty);

                    exp.RemainingQty -= matchedQty;
                    rec.RemainingQty -= matchedQty;

                    // Clonamos para registrar exactamente cuántas unidades se emparejaron correctamente
                    var correctItem = exp.Original.Clone();
                    correctItem.Quantity = matchedQty;
                    result.CorrectItems.Add(correctItem);
                }
            }

            // 3. FASE 2: Diferencias (Mismo Código, pero distinta Serie o Vencimiento)
            foreach (var exp in expTracked.Where(e => e.RemainingQty > 0))
            {
                var codeMatches = recTracked.Where(r => r.RemainingQty > 0 &&
                                                        StrEq(exp.Original.CodItem, r.Original.CodItem)).ToList();

                foreach (var rec in codeMatches)
                {
                    if (exp.RemainingQty == 0) break;

                    decimal matchedQty = Math.Min(exp.RemainingQty, rec.RemainingQty);

                    exp.RemainingQty -= matchedQty;
                    rec.RemainingQty -= matchedQty;

                    var expClone = exp.Original.Clone();
                    expClone.Quantity = matchedQty;

                    var recClone = rec.Original.Clone();
                    recClone.Quantity = matchedQty;

                    result.MismatchedItems.Add(new MismatchedDetail
                    {
                        Expected = expClone,
                        Received = recClone,
                        SerialNumberDiffers = !StrEq(exp.Original.SerialNumber, rec.Original.SerialNumber),
                        DueDateDiffers = !DateEq(exp.Original.DueDate, rec.Original.DueDate),
                        // Evaluamos si las líneas originales tenían distinta cantidad para el registro
                        QuantityDiffers = exp.Original.Quantity != rec.Original.Quantity
                    });
                }
            }

            // 4. FASE 3: Faltantes (Esperados que sobraron)
            foreach (var exp in expTracked.Where(e => e.RemainingQty > 0))
            {
                var missingItem = exp.Original.Clone();
                missingItem.Quantity = exp.RemainingQty;
                result.MissingItems.Add(missingItem);
            }

            // 5. FASE 4: Sobrantes (Recibidos no justificados en el listado esperado)
            foreach (var rec in recTracked.Where(r => r.RemainingQty > 0))
            {
                var extraItem = rec.Original.Clone();
                extraItem.Quantity = rec.RemainingQty;
                result.ExtraItems.Add(extraItem);
            }

            return result;
        }

        // --- Funciones Auxiliares (Tus mismas funciones) ---
        private static bool StrEq(string a, string b) =>
            string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);

        private static bool DateEq(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b)) return true;
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b)) return false;

            if (DateTime.TryParse(a, out var da) && DateTime.TryParse(b, out var db))
                return da.Date == db.Date;

            return string.Equals(a.Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
