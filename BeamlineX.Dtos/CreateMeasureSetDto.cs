using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamlineX.Dtos
{
    public struct CreateMeasureSetDto
    {
        public string LocationId { get; set; }
        public double MonochromatorPos { get; set; }
        public double Intensity { get; set; }
        public double Temperature { get; set; }
        public DateTime MeasureTime { get; set; }
        public double AnglePosition { get; set; }
    }
}
