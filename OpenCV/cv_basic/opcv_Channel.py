import cv2
import numpy as np

print("OpenCV version:")
print(cv2.__version__)
 
img = cv2.imread("image/bts-03.jpg")
print("image shape : {} pixels".format(img.shape))
print("width: {} pixels".format(img.shape[1]))
print("height: {} pixels".format(img.shape[0]))
print("channels: {}".format(img.shape[2]))

(height, width) = img.shape[:2]
center = (width // 2, height // 2)

cv2.imshow("bts original", img)

# img의 이미지의 color channel 분리
(B, G, R) = cv2.split(img)

# cv2.imshow("Red Channel", R)
# cv2.imshow("Green Channel", G)
# cv2.imshow("Blue Channel", B)
# cv2.waitKey(0)

# 색상을 머지함
# zeros_img = np.zeros(img.shape[:2], dtype = "uint8")
# cv2.imshow("Red", cv2.merge([zeros_img, G, R]))
# cv2.imshow("Green", cv2.merge([zeros_img, G, zeros_img]))
# cv2.imshow("Blue", cv2.merge([B, zeros_img, zeros_img]))
# cv2.waitKey(0)

# 필터 적용
# gray_img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
# cv2.imshow("Gray Filter", gray_img)

# hsv : 색상(Hue), 채도(Saturation), 명도(Value)
# hsv_img = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)
# cv2.imshow("HSV Filter", hsv_img)

#  Lab Color 채널을 이용해 이미지 선명도를 높이기 위한 필터
# lab = cv2.cvtColor(img, cv2.COLOR_BGR2LAB)
# cv2.imshow("LAB Filter", lab)
# cv2.waitKey(0)

BGR = cv2.merge([B, G, R])
cv2.imshow("Blue, Green and Red", BGR)

cv2.waitKey(0)
cv2.destroyAllWindows()
