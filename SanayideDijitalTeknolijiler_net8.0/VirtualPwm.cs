using System;
using System.Device.Gpio;
using System.Threading;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public class VirtualPwm
    {
        private GpioController controller;
        private int pin;
        private int frequency;
        private int dutyCycle;
        private Timer pwmTimer;
        private bool isHigh;

        public VirtualPwm(int pinNumber, int frequency)
        {
            pin = pinNumber;
            this.frequency = frequency;
            controller = new GpioController();
            controller.OpenPin(pin, PinMode.Output);
        }

        public void SetPercent(int dutyCycle)
        {
            if (dutyCycle < 0 || dutyCycle > 100)
            {
                throw new ArgumentOutOfRangeException("Duty cycle must be between 0 and 100");
            }

            this.dutyCycle = dutyCycle;
            int period = 1000 / frequency; // Period in milliseconds
            int onTime = period * dutyCycle / 100; // On time in milliseconds
            int offTime = period - onTime; // Off time in milliseconds

            if (pwmTimer != null)
            {
                pwmTimer.Dispose();
            }

            pwmTimer = new Timer(UpdatePWM, null, 0, period);

            void UpdatePWM(object state)
            {
                if (isHigh)
                {
                    controller.Write(pin, PinValue.Low);
                    isHigh = false;
                    pwmTimer.Change(offTime, Timeout.Infinite);
                }
                else
                {
                    controller.Write(pin, PinValue.High);
                    isHigh = true;
                    pwmTimer.Change(onTime, Timeout.Infinite);
                }
            }
        }

        public void Stop()
        {
            if (pwmTimer != null)
            {
                pwmTimer.Dispose();
                pwmTimer = null;
            }
            controller.Write(pin, PinValue.Low);
        }
    }
}
