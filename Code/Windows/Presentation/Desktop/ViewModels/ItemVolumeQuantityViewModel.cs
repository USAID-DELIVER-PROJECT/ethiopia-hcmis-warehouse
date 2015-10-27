using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Desktop.ViewModels
{
    public class ItemVolumeQuantityViewModel
    {
        public int ItemID { get; set; }
        public int UnitID { get; set; }
        public decimal? HeightMM { get; set; }
        public decimal? WidthMM { get; set; }
        public decimal? DepthMM { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Quantity { get; set; }
    }
}
