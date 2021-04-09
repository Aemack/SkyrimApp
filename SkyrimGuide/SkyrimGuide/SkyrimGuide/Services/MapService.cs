using SkyrimGuide.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class MapService
    {
        public List<MapRow> SetUpMap(Location location)
        {
            List<MapRow> mapRows = new List<MapRow>();
            var count = 0;
            var imageString = GetMapImageFromCoord(location.Coordinates.Replace("[", "").Replace("]", ""));
            for (int i = 0; i < 8; i++)
            {
                var RowImages = new List<MapCell>();
                for (int j = 0; j < 12; j++)
                {
                    var cell = new MapCell() { ImageName = "MapImage" + count + ".png" };
                    if ("MapImage" + count + ".png" == imageString)
                    {
                        cell.Opacity = 0.5;
                    }
                    else
                    {
                        cell.Opacity = 1;
                    }
                    RowImages.Add(cell);
                    count++;
                }

                mapRows.Add(new MapRow() { RowData = RowImages, RowNumber = i });
            }
            return mapRows;
        }


        public string GetMapImageFromCoord(string coords)
        {
            coords = coords.Replace("[", "").Replace("]", "");
            var alphabet = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };
            int count = 0;
            for (int it = 1; it <= 8; it++)
            {
                for (int i = 0; i <= 11; i++)
                {
                    if ("" + alphabet[i] + it == coords)
                    {
                        return $"MapImage{count}.png";
                    }
                    count++;
                }
            }
            return "";
        }
    }
}
