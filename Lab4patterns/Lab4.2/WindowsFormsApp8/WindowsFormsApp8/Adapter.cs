using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class DigitalWatch
    {
        public virtual string getTimeDigital(DateTime time)
        {
            string stringTime = time.ToString("HH:mm:ss");
            return stringTime;
        }
    }

    class Adapter: DigitalWatch
    {
        private AnalogWatch analogWatch = new AnalogWatch();

        public override string getTimeDigital(DateTime time)
        {
            return analogWatch.GetTimeAnalog(time);
        }
    }


    class AnalogWatch
    {
        public string GetTimeAnalog(DateTime time)
        {
            int hours = Convert.ToInt32(time.ToString("hh"));
            int minutes = Convert.ToInt32(time.ToString("mm"));
            int seconds = Convert.ToInt32(time.ToString("ss"));

            double angle1 = hours * 2 * Math.PI / 12 + minutes * 2 * Math.PI / (12*60);
            double angle2 = minutes * 2 * Math.PI / 60;
            double angle3 = seconds * 2 * Math.PI / 60;

            string angles = angle1 + ":" + angle2 + ":" + angle3;

            return angles;
        }
    }
}
