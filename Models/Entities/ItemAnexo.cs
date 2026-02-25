using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Entities
{
    public class ItemAnexo
    {
        private string _codItem;
        private string _description;
        private string _serialNumber;
        private decimal _quantity;
        private string _dueDate;
        private bool _isAquaKit = false;

        public ItemAnexo()
        {
            _codItem = "";
            _description = "";
            _serialNumber = "";
            _quantity = 0;
            _dueDate = "";
            _isAquaKit = false;
        }

        public ItemAnexo(string pCodItem, string pDesciption, string pSerialNumber, decimal pQuantity = 0, string pDueDate = "", bool pIsAquaKit = false)
        {
            _codItem = pCodItem;
            _description = pDesciption;
            _serialNumber = pSerialNumber;
            _quantity = pQuantity;
            _dueDate = pDueDate;
            _isAquaKit = pIsAquaKit;
        }

        public string CodItem
        {
            get { return _codItem; }
            set { _codItem = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public bool IsAquaKit
        {
            get { return _isAquaKit; }
            set { _isAquaKit = value; }
        }

        public ItemAnexo Clone()
        {
            return new ItemAnexo
            {
                CodItem = CodItem,
                Description = Description,
                SerialNumber = SerialNumber,
                Quantity = Quantity,
                DueDate = DueDate
            };
        }

        public ItemAnexoReport GetItemAnexoReport()
        {
            return new ItemAnexoReport
            {
                CodItem = CodItem,
                Description = Description,
                SerialNumber = SerialNumber,
                Quantity = Quantity,
                DueDate = DueDate,
                QuantityFisical = 0
            };
        }
    }
}
