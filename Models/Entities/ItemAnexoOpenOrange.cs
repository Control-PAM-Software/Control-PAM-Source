using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Entities
{
    public class ItemAnexoOpenOrange : ItemAnexo
    {
        private string _Price = "";
        private string _BatchStatus = "";
        private string _Kit = "";

        private bool _CodeActive = false;
        private bool _QuantityActive = false;
        private bool _SerialActive = false;
        private bool _DuedateActive = false;
        private bool _PriceActive = false;
        private bool _BatchStatusActive = false;
        private bool _KitActive = false;

        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string BatchStatus
        {
            get { return _BatchStatus; }
            set { _BatchStatus = value; }
        }

        public string Kit
        {
            get { return _Kit; }
            set { _Kit = value; }
        }

        public bool CodeActive
        {
            get { return _CodeActive; }
            set { _CodeActive = value; }
        }

        public bool QuantityActive
        {
            get { return _QuantityActive; }
            set { _QuantityActive = value; }
        }

        public bool SerialActive
        {
            get { return _SerialActive; }
            set { _SerialActive = value; }
        }

        public bool DueDateActive
        {
            get { return _DuedateActive; }
            set { _DuedateActive = value; }
        }

        public bool PriceActive
        {
            get { return _PriceActive; }
            set { _PriceActive = value; }
        }

        public bool BatchStatusActive
        {
            get { return _BatchStatusActive; }
            set { _BatchStatusActive = value; }
        }

        public bool KitActive
        {
            get { return _KitActive; }
            set { _KitActive = value; }
        }

    }
}
