import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  

# 스위치로 LED on,off                                         
LED = 40
SW = 16
A = 0


GPIO.setup(LED, GPIO.OUT, initial=GPIO.LOW)
GPIO.setup(SW, GPIO.IN)

try:
    cnt = 1
    while True:
        sw_val = GPIO.input(SW)
        # print(sw_val)
        if sw_val == 1: 
            if A == 0:
                GPIO.output(LED,1)
                A = 1
            else:
                GPIO.output(LED,0) 
                A = 0  
            time.sleep(0.3)    
        #     A = A + 1
        # if A%2 == 1:
        #     GPIO.output(LED,1)   
        # else:
        #     GPIO.output(LED,0)   
        # time.sleep(0.3)
        
finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally') 
