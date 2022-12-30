import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  

# 스위치로 LED 켜기                                         
LED = 40
SW = 16
A = 0
pre_sw_val = 0  # 스위치 이전값  
cur_sw_val = 0  # 스위치 현재값

GPIO.setup(LED, GPIO.OUT, initial=GPIO.LOW)
GPIO.setup(SW, GPIO.IN)

# 누르고 있을 때만 on
try:
    while True:
        cur_sw_val = GPIO.input(SW)
        if pre_sw_val == 0 and cur_sw_val == 1:    # 상승 엣지 체크 
            if A == 0:
                GPIO.output(LED,1)
                A = 1
            else:
                GPIO.output(LED,0) 
                A = 0  
            time.sleep(0.3)    
        pre_sw_val = cur_sw_val       # 이전값 갱신        
finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally')
