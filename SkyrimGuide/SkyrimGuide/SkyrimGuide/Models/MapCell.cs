using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class MapCell
    {
        public string ImageName { get; set; }
        public double Opacity { get; set; }
    }

    public class MapRow
    {
        public int RowNumber { get; set; }
        public List<MapCell> RowData { get; set; }


    }
}
