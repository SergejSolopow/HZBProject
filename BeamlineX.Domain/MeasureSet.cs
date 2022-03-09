using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamlineX.Domain
{
    public class MeasureSet : Entity
    {
        public MeasureSet(
            string locationId,
            double monochromatorPos,
            double intensity,
            double temperature,
            DateTime measureTime,
            double anglePosition)
        {
            LocationId = locationId;
            MonochromatorPos = monochromatorPos;
            Intensity = intensity;
            Temperature = temperature;
            MeasureTime = measureTime;
            AnglePosition = anglePosition;
        }

        public string LocationId { get; private set; }
        public double MonochromatorPos { get; private set; }
        public double Intensity { get; private set; }
        public double Temperature { get; private set; }
        public DateTime MeasureTime { get; private set; }
        public double AnglePosition { get; private set; }
    }
}
