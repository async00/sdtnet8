using System;
using System.Device.Gpio;



namespace SanayideDijitalTeknolijiler_net8._0{
public static class GC
{
    private static readonly GpioController _gpioController = new GpioController();

    // Pin'i açma ve modunu ayarlama
    public static void PreparePin(int pinNumber, PinMode mode)
    {
        if (!_gpioController.IsPinOpen(pinNumber))
        {
            _gpioController.OpenPin(pinNumber, mode);
        }
        else
        {
            _gpioController.SetPinMode(pinNumber, mode);
        }
    }

    // pini high ve ya low yap
    public static void Write(int pinNumber, PinValue value)
    {
        if (_gpioController.IsPinOpen(pinNumber))
        {
            _gpioController.Write(pinNumber, value);
        }
        else
        {
            LogSys.
        }
    }

    // pini oku
    public static PinValue ReadPin(int pinNumber)
    {
        if (_gpioController.IsPinOpen(pinNumber))
        {
            return _gpioController.Read(pinNumber);
        }
        else
        {
            throw new InvalidOperationException($"Pin {pinNumber} is not open.");
        }
    }

    // Pin'i kapatma
    public static void ClosePin(int pinNumber)
    {
        if (_gpioController.IsPinOpen(pinNumber))
        {
            _gpioController.ClosePin(pinNumber);
        }
    }

    // Sınıfın kullanımını sonlandırma
    public static void Dispose()
    {
        _gpioController.Dispose();
    }
}

}
