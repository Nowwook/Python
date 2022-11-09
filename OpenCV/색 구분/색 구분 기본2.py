import cv2
import numpy as np

img = cv2.imread('2.png')                       # 사진 읽기
hsv_img = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)  # 색상 BGR 에서 HSV 로 변환
# 인식할 범위 ex)녹색
bound_lower = np.array([25, 20, 20])            # 색상 하한값 
bound_upper = np.array([100, 255, 255])         # 색상 상한값 

mask_green = cv2.inRange(hsv_img, bound_lower, bound_upper) # 특정 생삭 영역을 추출, 상하한 값 기준
kernel = np.ones((7,7),np.uint8)      # 1로 된 array를 생성 , np.ones(shape, dtype, order)

mask_green = cv2.morphologyEx(mask_green, cv2.MORPH_CLOSE, kernel)  # 검은부분의 백색 잡음 제거
mask_green = cv2.morphologyEx(mask_green, cv2.MORPH_OPEN, kernel)   # 백색부분의 검은 잡음 제거

seg_img = cv2.bitwise_and(img, img, mask=mask_green)                  # 겹치는 부분 출력
contours, hier = cv2.findContours(mask_green.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)    # 분할부분 경계표시
output = cv2.drawContours(seg_img, contours, -1, (0, 0, 255), 3)      # 레드 컬러로

cv2.imshow("Result", output)
cv2.waitKey(0)
cv2.destroyAllWindows()
