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
center = (width // 2, height // 2)
 
cv2.imshow("bts", img)

mask = np.zeros(img.shape[:2], dtype = "uint8") # 8bit로 부호없 정수 표현 
# print(mask)
# #cv2.circle(mask, center, 반지름, (255, 255, 255), -1)
mask = cv2.circle(mask, center, 200, (255, 255, 255), -1) # -1 : 색상으로 면을 채움
# cv2.circle(mask, center, 200, (255, 255, 255), -1) # -1 : 색상으로 면을 채움

cv2.imshow("mask", mask)

# # mask적용, bitwise 연산 : not, and, or, xor
# # 참고 : https://docs.opencv.org/3.4/d0/d86/tutorial_py_image_arithmetics.html
masked = cv2.bitwise_and(img, img, mask = mask)
cv2.imshow("bts with mask", masked)

cv2.waitKey(0)
cv2.destroyAllWindows()
