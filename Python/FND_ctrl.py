import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  

FND_DATA_PIN = [3,5,11,13,15,19,21,23] 
FND_DIGIT_PIN =[29,31,33,35,37,40]
FND_DATA = [0xFC,0x60,0xDA,0xF2,0x66,0xB6,0xBE,0xE0,0xFE,0xF6]

for i in range(len(FND_DATA_PIN)):
    GPIO.setup(FND_DATA_PIN[i], GPIO.OUT, initial=GPIO.LOW)
for i in range(len(FND_DIGIT_PIN)):
    GPIO.setup(FND_DIGIT_PIN[i], GPIO.OUT, initial=GPIO.LOW)
#############
# 사용자 함수 정의
def FND_Dis(num):
    s_num = "{:06d}".format(num)       
    print(s_num)
    for i in range(6):
        FND_Display(i+1,int(s_num[i]))
        time.sleep(delay)   
    pass

# 0~9 디지털 표현
def FND_Display(digit,num):
    for i in range(6):
        if i == digit-1:
            GPIO.output(FND_DIGIT_PIN[i],0)
        else:
            GPIO.output(FND_DIGIT_PIN[i],1)   
    for j in range(8):
        GPIO.output(FND_DATA_PIN[j], FND_DATA[num] & 0x80>>j)
    pass  
#############  
delay = 0.001                                    
try:
    cnt = 0
    while True:
        FND_Dis(cnt)
        cnt += 1
        # time.sleep(0.3)   # delay 차이나면 잔상존재 

        #x = int(input('원하는 자리? '))
        # for i in range(10):
        #     FND_Display(i,i)
        #     time.sleep(delay)
        #     for j in range(8):
        #         GPIO.output(FND_DATA_PIN[j], FND_DATA[i] & 0x80>>j)      
        
finally:
    GPIO.cleanup()
    print('cleanup')
    print('finally')
