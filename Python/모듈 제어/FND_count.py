# 스위치 두개와 FND를 이용해서 카운터
# UP, RESET 스위치를 이용해서 설계, 인터럽트를 사용

from ntpath import join
import RPi.GPIO as GPIO        # 라즈베리파이 보드의 GPIO 관련 모듈
import time                    # 시간 관련 모듈
import threading

GPIO.setwarnings(False)        # warning 메세지를 비활성화
GPIO.setmode(GPIO.BOARD)       # BOARD: 라즈베리파이 핀번호, BCM:브로드컴 번호

def UP_Pressed(channel):
    global cnt
    cnt += 1

def RESET_Pressed(channel):
    global cnt
    cnt = 0
        
def FND_Display(digit, num):
    # digit 설정
    for i in range(6):
        if i == (digit-1):
            GPIO.output(FND_DIGIT_PIN[i], GPIO.LOW)
        else:
            GPIO.output(FND_DIGIT_PIN[i], GPIO.HIGH)
    
    # data 설정
    for i in range(8):
        GPIO.output(FND_DATA_PIN[i], FND_DATA[num] & 0x80>>i) 
        
def FND6_Display(num):  # 123456
    str_num = "{:06d}".format(num)
    # print(type(str_num))
    # print(str_num)
    
    for i in range(6):
        FND_Display(i+1,int(str_num[i]))
        time.sleep(delay)
        
def thread_FND_OUT():
    while True:
        FND6_Display(cnt)
        
cnt = 0
delay = 0.001
FND_DATA_PIN = [3,5,23,11,13,15,19,21]  # a~h(dp)
FND_DIGIT_PIN = [29,31,33,35,37,40]     # 1~6
FND_DATA = [0xFC,0x60,0xDA,0xF2,0x66,0xB6,0xBE,0xE0,0xFE,0xF6]
SW_UP = 16
SW_RESET = 32

for i in range(len(FND_DATA_PIN)):
    GPIO.setup(FND_DATA_PIN[i], GPIO.OUT, initial=GPIO.LOW)   # GOIO의 입출력을 설정

for i in range(len(FND_DIGIT_PIN)):
    GPIO.setup(FND_DIGIT_PIN[i], GPIO.OUT, initial=GPIO.LOW) 
    
GPIO.setup(SW_UP, GPIO.IN)
GPIO.setup(SW_RESET, GPIO.IN)
# interrupt 선언
GPIO.add_event_detect(SW_UP, GPIO.RISING, callback=UP_Pressed)
GPIO.add_event_detect(SW_RESET, GPIO.RISING, callback=RESET_Pressed)

t = threading.Thread(target=thread_FND_OUT)
t.start()

try:
    while True:
        pass
       
finally:
    GPIO.cleanup()       # GPIO에 대한 권한을 해제
    print("cleanup")
    print("finally")
