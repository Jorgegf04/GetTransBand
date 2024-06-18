using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    public class ActiveDTO
    {
        public int IdActive { get; set; }
        public string DesLine { get; set; }
        public string DesZone { get; set; }
        public string DesActive { get; set; }
        public string ImageActive { get; set; }

        public ActiveDTO(int idActive, string desLine, string desZone, string desActive, string imageActive)
        {
            IdActive = idActive;
            DesLine = desLine;
            DesZone = desZone;
            DesActive = desActive;
            ImageActive = imageActive;
        }
    }
}
