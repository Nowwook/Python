import RPi.GPIO as GPIO   
import time           

GPIO.setwarnings(False)  
GPIO.setmode(GPIO.BOARD) 

DC_M = [36,38,32]   # [P,N,EN]

for i in range(len(DC_M)):
    GPIO.setup(DC_M[i], GPIO.OUT, initial=GPIO.LOW)  
    
try:
    while True:
        # CCW
        GPIO.output(DC_M[0], GPIO.LOW)
        GPIO.output(DC_M[1], GPIO.HIGH)
        GPIO.output(DC_M[2], GPIO.HIGH)
        time.sleep(1)
        
        # STOP
        GPIO.output(DC_M[0], GPIO.LOW)
        GPIO.output(DC_M[1], GPIO.LOW)
        GPIO.output(DC_M[2], GPIO.LOW)
        time.sleep(1)
        
        # CW
        GPIO.output(DC_M[0], GPIO.HIGH)
        GPIO.output(DC_M[1], GPIO.LOW)
        GPIO.output(DC_M[2], GPIO.HIGH)
        time.sleep(1)
        
        # Break
        GPIO.output(DC_M[0], GPIO.HIGH)
        GPIO.output(DC_M[1], GPIO.HIGH)
        GPIO.output(DC_M[2], GPIO.HIGH)
        time.sleep(1)
        break
       
finally:
    GPIO.cleanup()     
    print("cleanup")
    print("finally")
