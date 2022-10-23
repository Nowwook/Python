from tensorflow.keras.models import load_model
from PIL import Image, ImageOps
import numpy as np

# Load the model
model = load_model('./models/keras_model.h5')

# 테스트 이미지를 저장할 변수의 타입과 shape 정의 
data = np.ndarray(shape=(1, 224, 224, 3), dtype=np.float32)

# 테스트 이미지 path 정의
image = Image.open('./image/nomask.jpg').convert('RGB')

# Teachable Machine의 기본 이미지 사이즈 정의 및 리사이즈
size = (224, 224)
image = ImageOps.fit(image, size, Image.ANTIALIAS)

# 이미지를 numpy array로 변경
image_array = np.asarray(image)

# Normalize the image
normalized_image_array = (image_array.astype(np.float32) / 127.0) - 1

# 정규화한 이미지를 data 변수에 대입
data[0] = normalized_image_array

# labels.txt 파일 읽어오기
# load class_name
class_names=[]
with open("./models/labels.txt", "r") as f:
    print(f)
    for line in f:
        #print(line.strip())
        class_names.append(line)

# run the inference(추론)
prediction = model.predict(data)
index = np.argmax(prediction)
class_name = class_names[index]
confidence_score = prediction[0][index]

print("prediction : ", prediction)
print("np.argmax(prediction) : ", index)
print("Class: ", class_name)
print("Confidence Score: ", confidence_score)
