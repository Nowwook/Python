# pip install pillow
# pip install face_recognition
# pip install opencv-python

import face_recognition
import cv2
import numpy as np

# 웹캠의 라이브 비디오에서 얼굴 인식을 실행하는 매우 간단하지만 느린 예
# 조금 더 복잡하지만 더 빠르게 실행되는 두 번째 예 있음

# PLEASE NOTE: OpenCV (the `cv2` library) 설치 필수
# OpenCV는 face_recognition 라이브러리를 사용하기 위해 필요하지 않음. 이 예를 실행하려는 경우에만 필요
# specific demo. If you have trouble installing it, try any of the other demos that don't require it instead.
# 특정 데모. 설치하는 데 문제가 있으면 대신 필요하지 않은 다른 데모를 시도

# Get a reference to webcam #0 (the default one)
video_capture = cv2.VideoCapture(0)

# 인물1
image_1 = face_recognition.load_image_file("image/ceu.jpg")
face_encoding_1 = face_recognition.face_encodings(image_1)[0]

# 인물2
image_2 = face_recognition.load_image_file("image/biden.jpg")
face_encoding_2 = face_recognition.face_encodings(image_2)[0]

# 인물3
image_3 = face_recognition.load_image_file("image/iu.jpg")
face_encoding_3 = face_recognition.face_encodings(image_3)[0]

# 얼굴 인코딩 및 해당 이름의 배열 생성
known_face_encodings = [
    face_encoding_1,
    face_encoding_2,
    face_encoding_3
]
# 순서대로 얼굴의 이름(label)
known_face_names = [
    "ceu",
    "Joe Biden",
    "Iu"
]

while True:
    # 한 프레임 잡기
    ret, frame = video_capture.read()

    # 이미지를 BGR 색상(OpenCV 사용)에서 RGB 색상(face_recognition 사용)으로 변환
    rgb_frame = frame[:, :, ::-1]

    # 비디오 프레임에서 모든 얼굴 및 얼굴 인코딩 찾기
    face_locations = face_recognition.face_locations(rgb_frame)
    face_encodings = face_recognition.face_encodings(rgb_frame, face_locations)

    # Loop through each face in this frame of video
    for (top, right, bottom, left), face_encoding in zip(face_locations, face_encodings):
        # 매치 확인
        matches = face_recognition.compare_faces(known_face_encodings, face_encoding)

        name = "Unknown"

        # known_face_encodings에서 일치하는 항목이 발견되면 첫 번째 항목만 사용
        # if True in matches:
        #     first_match_index = matches.index(True)
        #     name = known_face_names[first_match_index]

        # 아니면 가장 비슷한 얼굴 사용
        face_distances = face_recognition.face_distance(known_face_encodings, face_encoding)
        best_match_index = np.argmin(face_distances)
        if matches[best_match_index]:
            name = known_face_names[best_match_index]

        # 얼굴에 상자 그리기
        cv2.rectangle(frame, (left, top), (right, bottom), (0, 0, 255), 2)

        # 얼굴 아래 이름 레이블 생성
        cv2.rectangle(frame, (left, bottom - 35), (right, bottom), (0, 0, 255), cv2.FILLED)
        font = cv2.FONT_HERSHEY_DUPLEX
        cv2.putText(frame, name, (left + 6, bottom - 6), font, 1.0, (255, 255, 255), 1)

    # Display the resulting image
    cv2.imshow('Video', frame)

    # q 종료
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# Release handle to the webcam
video_capture.release()
cv2.destroyAllWindows()
