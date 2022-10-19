import cv2

# 이미지 읽어오기
img = cv2.imread("./image/ieu-01.jpg")

# gray scale로 바꾸기
gray =cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)

# 이미지 화면에 보이기
cv2.imshow("IU",img)
cv2.imshow("IU_grey",gray)

# jpg 파일로 지정 폴더에 쓰기
# cv2.imwrite("image/IU.jpg",gray)
        
# 아무키 누를 때 까지 cpu 지연
cv2.waitKey(0)
# 종료
cv2.destroyAllWindows()
