# img = 이미지, gray로 변환
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
ret, thresh = cv2.threshold(gray, 100, 255, cv2.THRESH_BINARY)

# cv2.threshold(a,b,c,cv2.THRESH_BINARY)
# a 그림에서 b보다 크면c 나머진0
