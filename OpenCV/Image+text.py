import numpy as np
from PIL import ImageFont, ImageDraw, Image
import cv2

# 한글 쓸때
font = ImageFont.truetype("fonts/gulim.ttc", 20)

# img = cv2.imread("domain.png")
img = np.full((200, 300, 3), (255, 255, 255), np.uint8)
img = Image.fromarray(img)

draw = ImageDraw.Draw(img)

text = "이미지에 한글 출력\n\nhttps://jvvp.tistory.com"
draw.text((30, 50),  text, font=font, fill=(0, 0, 0))

img = np.array(img)

cv2.imshow("text", img)

cv2.waitKey()
cv2.destroyAllWindows()


# 영어만 쓸때
'''
import numpy as np
import cv2

img = np.full((100, 200, 3), (255, 255, 255), np.uint8)

text = "파이썬 OpenCV"

cv2.putText(img,  text, (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 0, 0), 1, cv2.LINE_AA)

cv2.imshow("text", img)

cv2.waitKey()
cv2.destroyAllWindows()
'''
