import cv2
import sys
import PIL
from matplotlib import pyplot as plt
import numpy as np

image = cv2.imread("./Image/stuck1.png")           # 이미지 읽기
image_gray = cv2.imread("./Image/dead1.png", cv2.IMREAD_GRAYSCALE)      # 흑백으로 이미지 읽기

# jupyter notebook에서 이미지를 보이게 하기
'''
b,g,r = cv2.split(image)
image2 = cv2.merge([r,g,b])
 
plt.imshow(image2)
plt.xticks([])
plt.yticks([])
plt.show()
'''

# 윈도우 창에서 이미지를 보이게 하기
'''
cv2.imshow('image', image)
cv2.imshow('image_gray', image_gray)

cv2.waitKey(0)
cv2.destroyAllWindows()
'''

#  가우시안 블러 이용하여 배경과 구분
# blur = cv2.GaussianBlur(image_gray, ksize=(3,3), sigmaX=0)
# ret, thresh1 = cv2.threshold(blur, 127, 255, cv2.THRESH_BINARY)

blur = cv2.GaussianBlur(image_gray, ksize=(5,5), sigmaX=0)
ret, thresh1 = cv2.threshold(blur, 127, 255, cv2.THRESH_BINARY)

# Canny를 이용하여 테두리 찾기
edged = cv2.Canny(blur, 10, 250)
# cv2.imshow('Edged', edged)
# cv2.waitKey(0)

# 작은 홈, 작은 홀들이 사라지고, 얇은 연결선이 두꺼워 짐
kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (7,7))
closed = cv2.morphologyEx(edged, cv2.MORPH_CLOSE, kernel)
# cv2.imshow('closed', closed)
# cv2.waitKey(0)

# 경계선 연결
contours, _ = cv2.findContours(closed.copy(),cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
# total = 0

# 배열화
contours_xy = np.array(contours)
contours_xy.shape

# x의 min과 max 찾기
x_min, x_max = 0,0
value = list()
for i in range(len(contours_xy)):
    for j in range(len(contours_xy[i])):
        value.append(contours_xy[i][j][0][0]) #네번째 괄호가 0일때 x의 값
        x_min = min(value)
        x_max = max(value)
print(x_max - x_min)
 
# y의 min과 max 찾기
y_min, y_max = 0,0
value = list()
for i in range(len(contours_xy)):
    for j in range(len(contours_xy[i])):
        value.append(contours_xy[i][j][0][1]) #네번째 괄호가 0일때 x의 값
        y_min = min(value)
        y_max = max(value)
# print(y_min)
print(y_max - y_min)

x = x_min
y = y_min
# w = x_max-x_min
# h = y_max-y_min
w = 973
h = 420

# 잘라서 저장
img_trim = image[y:y+h, x:x+w]
cv2.imwrite('org_trim.jpg', img_trim)
org_image = cv2.imread('org_trim.jpg')

cv2.imshow('org_image', org_image)
cv2.waitKey(0)
cv2.destroyAllWindows()
