using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Entities
{
    public class ItemAnexoReport : ItemAnexo
    {
        private decimal _quantityFisical = 0;
        private decimal _quantityDifference;

        public decimal QuantityFisical
        {
            get { return _quantityFisical; }
            set { _quantityFisical = value; }
        }

        public decimal QuantityDifference
        {
            get { return Quantity - QuantityFisical; }
            set { _quantityDifference = value; }
        }

    }
}
