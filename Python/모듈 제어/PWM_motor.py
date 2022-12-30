import RPi.GPIO as GPIO      
import time              

GPIO.setwarnings(False)      
GPIO.setmode(GPIO.BOARD) 

DC_M = [36,38,32]   # [P,N,EN]

for i in range(len(DC_M)):
    GPIO.setup(DC_M[i], GPIO.OUT, initial=GPIO.LOW)  

DC_EN = GPIO.PWM(DC_M[2], 1000)   # (pwm_pin, Hz)
DC_EN.start(0)                   # (duty_rate), 0~100

try:
    cnt = 0
    GPIO.output(DC_M[0], GPIO.LOW)
    GPIO.output(DC_M[1], GPIO.HIGH)
    
    # 속도 점점 증가,감소 반복
    while True:
        for i in range(100):
            cnt += 1    
            DC_EN.ChangeDutyCycle(cnt)  
            time.sleep(0.1)
        for j in range(100):
            cnt -= 1
            DC_EN.ChangeDutyCycle(cnt)
            time.sleep(0.1)
       
finally:
    GPIO.cleanup()   
    print("cleanup")
    print("finally")
