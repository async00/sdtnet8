using System;
using System.Device.Gpio;
using System.Threading;

namespace SanayideDijitalTeknolijiler_net8._0
{
    internal static class DistanceSens
    {

        //bu boktan kod muhammed ali büyük tarafından yazılmıştır.
        internal static double GetDistance()
        {
            int triggerPin = 15;
            int echoPin = 14;

            // GpioController nesnesi oluştur
            using (GpioController controller = new GpioController(PinNumberingScheme.Logical))
            {
                controller.OpenPin(triggerPin, PinMode.Output);
                controller.OpenPin(echoPin, PinMode.Input);
                controller.Write(triggerPin, PinValue.High);
                controller.Write(triggerPin, PinValue.Low);
                while (controller.Read(echoPin) == PinValue.Low) { }
                DateTime startTime = DateTime.Now;
                while (controller.Read(echoPin) == PinValue.High) { }
                DateTime endTime = DateTime.Now;
                TimeSpan travelTime = endTime - startTime;
                double distance = travelTime.TotalSeconds * 34300 / 2;
                return distance;
                
            }
        }
    }
}