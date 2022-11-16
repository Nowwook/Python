from skimage.metrics import structural_similarity as compare_ssim
import cv2
import numpy as np
import argparse

imageA = cv2.imread("./image/13.png")
imageB = cv2.imread("./image/12.png")

grayA = cv2.cvtColor(imageA, cv2.COLOR_BGR2GRAY)
grayB = cv2.cvtColor(imageB, cv2.COLOR_BGR2GRAY)
(score, diff) = compare_ssim(grayA, grayB, full=True)

diff = (diff * 255).astype("uint8")
# print(f"SSIM: {score}")     # 두 사진의 유사도, 1이면 같은 사진

thresh = cv2.threshold(
                diff, 0, 200, 
                cv2.THRESH_BINARY_INV | cv2.THRESH_OTSU
            )[1]
cnts, _ = cv2.findContours(
            thresh, 
            cv2.RETR_EXTERNAL, 
            cv2.CHAIN_APPROX_SIMPLE
            )

for c in cnts:
    area = cv2.contourArea(c)
    if area > 40:
        x, y, w, h = cv2.boundingRect(c)
        # 다른 부분 네모 표시
        cv2.rectangle(imageA, (x, y), (x + w, y + h), (0, 0, 255), 2) 
        cv2.rectangle(imageB, (x, y), (x + w, y + h), (0, 0, 255), 2)
        
cv2.imshow("Original", imageA)
cv2.imshow("Modified", imageB)
cv2.waitKey(0)
