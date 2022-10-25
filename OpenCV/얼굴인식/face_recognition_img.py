# pip install pillow
# pip install face_recognition
from PIL import Image
import face_recognition

# jpg 파일을 numpy 배열에 로드
img_path = './image/iu.jpg'
image = face_recognition.load_image_file(img_path)

# HOG-based model 사용하여 이미지의 모든 얼굴을 찾기
# 이 방법은 상당히 정확하지만 GPU 가속이 아닌 CNN 모델만큼 정확하지 않음
# 참조: find_faces_in_picture_cnn.py 
face_locations = face_recognition.face_locations(image)

print("I found {} face(s) in this photograph.".format(len(face_locations)))

for face_location in face_locations:

    # 이 이미지에서 각 얼굴의 위치를 print
    top, right, bottom, left = face_location
    print("A face is located at pixel location Top: {}, Left: {}, Bottom: {}, Right: {}".format(top, left, bottom, right))

    # 다음과 같이 실제 얼굴 자체에 액세스 가능
    face_image = image[top:bottom, left:right]
    pil_image = Image.fromarray(face_image)
    pil_image.show()