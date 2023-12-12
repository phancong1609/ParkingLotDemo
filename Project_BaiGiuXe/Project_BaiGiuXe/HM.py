from roboflow import Roboflow
import cv2
import easyocr
import pytesseract 
import matplotlib as plt
from skimage.filters import threshold_local
import numpy as np
import re
import sys
import os


original_stdout = sys.stdout
sys.stdout = open(os.devnull, 'w')

rf = Roboflow(api_key="gaUKo8Li2k3U0WYjW361")
project = rf.workspace().project("anpr-pekus")
model = project.version(1).model

image_filename = "Images\image.jpg"
image_path = os.path.join(os.getcwd(), image_filename)

print(image_path)
img = cv2.imread(image_path)


detected = model.predict(image_path, confidence=40, overlap=30)
# infer on a local image
predict = detected.json()
predict_pos = predict['predictions'][0]
x = predict_pos['x']
y= predict_pos['y']
w = predict_pos['width']
h= predict_pos['height']

license_plate = img[int(y - (h / 2)):int(y + (h / 2)), int(x - (w / 2)):int(x + (w / 2)), :].copy()



V = cv2.split(cv2.cvtColor(license_plate, cv2.COLOR_BGR2HSV))[2]
# adaptive threshold
T = threshold_local(V, 35, offset=5, method="gaussian")
thresh = (V > T).astype("uint8") * 255
thresh = cv2.bitwise_not(thresh)

_, labels = cv2.connectedComponents(thresh)
mask = np.zeros(thresh.shape, dtype="uint8")
total_pixels = thresh.shape[0] * thresh.shape[1]
lower = total_pixels // 120
upper = total_pixels // 20
for label in np.unique(labels):
        if label == 0:
            continue
        labelMask = np.zeros(thresh.shape, dtype="uint8")
        labelMask[labels == label] = 255
        numPixels = cv2.countNonZero(labelMask)
        if numPixels > lower and numPixels < upper:
            mask = cv2.add(mask, labelMask)

#cv2.imshow("masked",mask)
cv2.waitKey()
reader = easyocr.Reader(['en'],verbose=False)

extracted_text = []
output = reader.readtext(mask)
for out in output:
    text_bbox, text, text_score = out
    if text_score > 0:
        extracted_text.append(text)
        
extracted_text = [re.sub(r'\s', '', text) for text in extracted_text]
sys.stdout = original_stdout

for text in extracted_text:
    print(text)