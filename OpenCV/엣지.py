import cv2
gray_img = cv2.imread("./image/12.png", cv2.IMREAD_GRAYSCALE)

# threshold1 : 다른 엣지와의 인접 부분(엣지가 되기 쉬운 부분)에 있어 엣지인지 아닌지를 판단하는 임계값
# threshold2 : 엣지인지 아닌지를 판단하는 임계값
threshold1 = 200
threshold2 = 360
edge_img = cv2.Canny(gray_img, threshold1, threshold2)

cv2.imshow('BGR_test1', edge_img)
cv2.waitKey(0)
cv2.destroyAllWindows()
