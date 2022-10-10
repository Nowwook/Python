# pwm 이용 LED 밝이 조절, 모터 속도 조절    
import RPi.GPIO as GPIO   
import time                              

GPIO.setwarnings(False)   
GPIO.setmode(GPIO.BOARD)  
                                         
DC_M = [36,38,32] # P, N, EN
LED = 40

for i in range(len(DC_M)):
    GPIO.setup(DC_M[i], GPIO.OUT, initial=GPIO.LOW)     # GOIO의 입출력을 설정
GPIO.setup(LED, GPIO.OUT, initial=GPIO.LOW)

# PWM
# start(dc) : pwm를 시작하는 함수, 인자값은 시작 duty%
# stop() : pwm이 정지하는 함수
# ChangeDutyCycle(dc) : pwm의 duty% 를 변경하는 함수
# ChangeFrequence(freq) : pwm의 주파수를 변경하는 함수

DC_EN = GPIO.PWM(DC_M[2], 1000)     # (pwm_pin,hz) 주파수(주기)  초=1/hz
DC_EN.start(0)                      # (duty_rate) , 0~100%

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
