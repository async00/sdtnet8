using System;
using System.Device.Gpio;
using System.Threading;

public class PwmController
{
    private readonly int _gpioPin;
    private readonly double _frequency;
    private readonly GpioController _gpioController;
    private Thread _pwmThread;
    private bool _isRunning;
    private double _dutyCyclePercentage;

    public PwmController(int gpioPin, double frequency = 50)
    {
        _gpioPin = gpioPin;
        _frequency = frequency;
        _gpioController = new GpioController();
        _gpioController.OpenPin(_gpioPin, PinMode.Output);
    }

    public void Start()
    {
        _isRunning = true;
        _pwmThread = new Thread(RunPwm);
        _pwmThread.Start();
    }

    public void Stop()
    {
        _isRunning = false;
        _pwmThread?.Join();
    }

    public void SetDutyCycle(double dutyCyclePercentage)
    {
        if (dutyCyclePercentage < 0 || dutyCyclePercentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(dutyCyclePercentage), "Duty cycle must be between 0 and 100.");
        }

        _dutyCyclePercentage = dutyCyclePercentage;
    }

    public void SetDutyCycle(byte value)
    {
        double dutyCyclePercentage = (value / 255.0) * 100.0;
        SetDutyCycle(dutyCyclePercentage);
    }

    private void RunPwm()
    {
        double period = 1000.0 / _frequency;
        double highTime = period * (_dutyCyclePercentage / 100.0);
        double lowTime = period - highTime;

        while (_isRunning)
        {
            _gpioController.Write(_gpioPin, PinValue.High);
            Thread.Sleep(TimeSpan.FromMilliseconds(highTime));
            _gpioController.Write(_gpioPin, PinValue.Low);
            Thread.Sleep(TimeSpan.FromMilliseconds(lowTime));
        }
    }

    public void Dispose()
    {
        Stop();
        _gpioController.ClosePin(_gpioPin);
        _gpioController.Dispose();
    }
}
