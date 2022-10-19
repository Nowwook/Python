import cv2

img = cv2.imread("./image/ieu-01.jpg")
gray =cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)

cv2.imshow("IU",img)
cv2.imshow("IU_grey",gray)

# 아무키 누를 때 까지 cpu 지연
cv2.waitKey(0)
# 종료
cv2.destroyAllWindows()