import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  
                                         
# 사용할 GPIO 핀
FND_DATA = [3,5,11,13,15,19,21,23]

for i in range(len(FND_DATA)):
    GPIO.setup(FND_DATA[i], GPIO.OUT, initial=GPIO.LOW)

try:
    while True:
    
        pass
finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally')
