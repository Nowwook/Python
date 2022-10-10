import RPi.GPIO as GPIO     # 라즈베리파이 보드의 GPIO 관련 모듈
import time                 # 시간 관련 모듈            

GPIO.setwarnings(False)     # warning 메세지를 비활성화
GPIO.setmode(GPIO.BOARD)    # BOARD: 라즈베리파이 핀번호, BCM:브로드컴 번호
                                         
# 사용할 GPIO 핀
FND_DATA = [3,5,11,13,15,19,21,23]

for i in range(len(FND_DATA)):
    GPIO.setup(FND_DATA[i], GPIO.OUT, initial=GPIO.LOW)   # GOIO의 입출력을 설정

try:
    while True:
    # 프로그램 작성
    
except KeyboardInterrupt:         # 오류 메세지 제거
    print('KeyboardInterrupt')
except ZeroDivisionError:
    print('ZeroDivisionError')
except IndexError:
    print('IndexError')
    
finally:
    GPIO.cleanup()      # GPIO에 대한 권한을 해제
    print('cleanup')
    print('finally')
