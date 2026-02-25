using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Settings
{
    public class SettingsModel
    {
        public string ColorDifferences { get; set; } = "#FFFFC0";
        public string ColorMissingItem { get; set; } = "#FFC0C0";
        public string ArticlePrice { get; set; } = "0.01";
        public bool Test { get; set; } = false;
        public Base_Settings ValijasAB { get; set; } = new Base_Settings();
        public Base_Settings AccessoriesAB { get; set; } = new Base_Settings();
        public Base_Settings InventoryAB { get; set; } = new Base_Settings();

        public OpenOrange OpenOrange { get; set; } = new OpenOrange();

        public Base_Settings InventoryAtos { get; set; } = new Base_Settings();
        public Base_Settings IngresoAtos { get; set; } = new Base_Settings();

        public Base_Settings IngresoBernafon { get; set; } = new Base_Settings();
        public Base_Settings InventoryBernafon { get; set; } = new Base_Settings();
        public Movements_Bernafon MovementsBernafon { get; set; } = new Movements_Bernafon();

        public Base_Settings IngresoInomed { get; set; } = new Base_Settings();
        public Base_Settings InventoryInomed { get; set; } = new Base_Settings();

        public Base_Settings IngresoOticom { get; set; } = new Base_Settings();
        public Base_Settings InventoryOticom { get; set; } = new Base_Settings();


        public SettingsModel()
        {
            if (OpenOrange == null)
                OpenOrange = new OpenOrange();
        }
    }
}
