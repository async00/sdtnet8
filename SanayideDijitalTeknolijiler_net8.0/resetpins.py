import RPi.GPIO as GPIO
import time

# GPIO modunu BCM olarak ayarla
GPIO.setmode(GPIO.BCM)

# GPIO pinlerinin numaralarını al
all_pins = [pin for pin in range(2, 28)]  # BCM numaralandırması 2-27 arası pinler

try:
    # Tüm pinleri çıkış olarak ayarla
    for pin in all_pins:
        GPIO.setup(pin, GPIO.OUT)

    # Tüm pinlere 0 (LOW) değeri ata
    for pin in all_pins:
        GPIO.output(pin, GPIO.LOW)

    # 1 saniye bekle
    time.sleep(1)

finally:
    print("succes !")
    GPIO.cleanup()
