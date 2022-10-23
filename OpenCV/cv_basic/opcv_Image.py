import cv2
import numpy as np

print("OpenCV version:")
print(cv2.__version__)
 
img = cv2.imread("image/bts-02.jpg")
print("image shape: {} pixels".format(img.shape))
print("width: {} pixels".format(img.shape[1]))
print("height: {} pixels".format(img.shape[0]))
print("channels: {}".format(img.shape[2]))

(height, width) = img.shape[:2]

# 이미지의 중간값
center = (width // 2, height // 2) # % : 나눗셈의 나머지 계산 , // 몫을 계산
 
cv2.imshow("bts", img)

# move = np.float32([[1, 0, 왼쪽에서], [0, 1, 윗쪽에서]]) 
# 1, 0 좌우 움직임, 0, 1 상하 움직임
# move = np.float32([[1, 0, -100], [0, 1, 100]])
# moved_img = cv2.warpAffine(img, move, (width, height))
# cv2.imshow("Moved down: +, up: - and right: +, left - ", moved_img)

# 회전
# rotate = cv2.getRotationMatrix2D(center, 90, 1.0) # -90 : 시계 방향 90도, scale
# rotated_img = cv2.warpAffine(img, rotate, (width, height))
# cv2.imshow("Rotated clockwise degrees", rotated_img)

# 이미지 resize

# ratio = 200.0 / width # 200px / 현재 너비 
# dimension = (200, int(height * ratio))  # (width, height)

# # interpolation(보관법) = cv2.INTER_AREA(축소시) , interpolation = cv2.INTER_LINEAR(확대시)
# # 일반적으로 cv2.INTER_AREA 사용
# resized = cv2.resize(img, dimension, interpolation = cv2.INTER_LINEAR)
# cv2.imshow("Resized", resized)

# 대칭으로 만들기
#lipped Horizontal 1, Vertical 0, both(대각선) -1 
flipped = cv2.flip(img, 1)
cv2.imshow("Flipped Horizontal 1, Vertical 0, both -1 ", flipped)

cv2.waitKey(0)
cv2.destroyAllWindows()
