import cv2

img = cv2.imread("../Image/8.png")

# degree 회전각
degree= 90

h, w = img.shape[:-1]
crossLine = int(((w * h + h * w) ** 0.5))
centerRotatePT = int(w / 2), int(h / 2)
new_h, new_w = h, w

rotatefigure = cv2.getRotationMatrix2D(centerRotatePT, degree, 1)
result = cv2.warpAffine(img, rotatefigure, (new_w, new_h))
    
cv2.imshow('img', result)
cv2.waitKey(0)
cv2.destroyAllWindows()
