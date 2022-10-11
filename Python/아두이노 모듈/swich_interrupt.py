import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  

# 스위치로 LED 켜기                                         
LED = 40
SW = 16
A = 0

GPIO.setup(LED, GPIO.OUT, initial=GPIO.LOW)
GPIO.setup(SW, GPIO.IN)
#####사용자 함수
def switchPressed(channal):                # channal pin 번호
    global A
    print('channal %s Pressed!!' %channal)
    if A == 0:
        GPIO.output(LED,1)
        A = 1
    else:
        GPIO.output(LED,0) 
        A = 0      
#### interrupt 선언  
GPIO.add_event_detect(SW, GPIO.RISING,callback = switchPressed)     #스위치 누르면 callback 호출

try:
    while True:
        pass        
finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally') 
