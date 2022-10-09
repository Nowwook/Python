# 숫자를 2진수 형태로 LED에 표시하세요.

import RPi.GPIO as GPIO        # 라즈베리파이 보드의 GPIO 관련 모듈
import time                    # 시간 관련 모듈

GPIO.setwarnings(False)        # warning 메세지를 비활성화
GPIO.setmode(GPIO.BOARD)       # BOARD: 라즈베리파이 핀번호, BCM:브로드컴 번호

LED = [3,5,23,11,13,15,19,21]
LED_NUM = 8

for i in range(len(LED)):
    GPIO.setup(LED[i], GPIO.OUT, initial=GPIO.LOW)   # GOIO의 입출력을 설정

try:
    while True:
        # 프로그램 작성
        num = int(input("숫자를 입력하세요: "))
        print(num)
        bin_num = bin(num)[2:]      # '0b'를 빼낸다.
        
        while True:
            if len(bin_num) <= LED_NUM:
                bin_num = '0' + bin_num
            else:
                bin_num = bin_num[-8:]
                break
        # 2진수 리스트를 LED에 표시
        for i in range(LED_NUM):
            GPIO.output(LED[i], int(bin_num[(LED_NUM-1)-i]))
               
        print(bin_num)
        print(type(bin_num))
    
finally:
    GPIO.cleanup()       # GPIO에 대한 권한을 해제
    print("cleanup")
    print("finally")
    

# pwm 이용 LED 밝이 조절, 모터 속도 조절    
import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  
                                         
DC_M = [36,38,32] # P, N, EN
LED = 40

for i in range(len(DC_M)):
    GPIO.setup(DC_M[i], GPIO.OUT, initial=GPIO.LOW)
GPIO.setup(LED, GPIO.OUT, initial=GPIO.LOW)

DC_EN = GPIO.PWM(DC_M[2], 1000)   # (pwm_pin,hz) 주파수(주기)  초=1/hz
DC_EN.start(0)  # (duty_rate) , 0~100%

LED_PWM = GPIO.PWM(LED,1000)
LED_PWM.start(0)
try:
    cnt = 0
    GPIO.output(DC_M[0], 0)
    GPIO.output(DC_M[1], 1)
    while True:
        for i in range(100):
            cnt += 1    
            DC_EN.ChangeDutyCycle(cnt)    # duty 변경
            LED_PWM.ChangeDutyCycle(cnt)
            time.sleep(0.1)
        for j in range(100):
            cnt -= 1
            DC_EN.ChangeDutyCycle(cnt)
            LED_PWM.ChangeDutyCycle(cnt)
            time.sleep(0.1)

finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally') 
