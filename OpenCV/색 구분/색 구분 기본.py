import numpy as np
import cv2
from time import sleep

# 메인 함수
def main():
    image = cv2.imread("./image/13.png") # 파일 읽어들이기

    # BGR로 색추출
    bgrLower = np.array([52, 20, 255])      # 추출할 색의 하한
    bgrUpper = np.array([250, 255, 255])    # 추출할 색의 상한
    bgrResult = bgrExtraction(image, bgrLower, bgrUpper)
    cv2.imshow('BGR_test1', bgrResult)
    # sleep(1)

    # HSV로 색추출
    # hsvLower = np.array([30, 153, 255])    # 추출할 색의 하한
    # hsvUpper = np.array([30, 153, 255])    # 추출할 색의 상한
    # hsvResult = hsvExtraction(image, hsvLower, hsvUpper)
    # cv2.imshow('HSV_test1', hsvResult)
    # sleep(1)

    cv2.waitKey(0)
    cv2.destroyAllWindows()


# BGR로 특정 색을 추출하는 함수
def bgrExtraction(image, bgrLower, bgrUpper):
    img_mask = cv2.inRange(image, bgrLower, bgrUpper) 
    result = cv2.bitwise_and(image, image, mask=img_mask) 
    return result

# HSV로 특정 색을 추출하는 함수
def hsvExtraction(image, hsvLower, hsvUpper):
    hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV) 
    hsv_mask = cv2.inRange(hsv, hsvLower, hsvUpper) 
    result = cv2.bitwise_and(image, image, mask=hsv_mask)
    return result

if __name__ == '__main__':
    main()
