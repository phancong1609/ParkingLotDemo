import cv2
import socket
import struct

cap = cv2.VideoCapture(1)
detector = cv2.QRCodeDetector()

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ('localhost', 12345)
client_socket.connect(server_address)
# initalize the camera


while True:
    _, img = cap.read()

# detect and decode
    data, vertices_array, _ = detector.detectAndDecode(img)

    #    check if there is a QRCode in the image
    if vertices_array is not None:
        if data:
            print(data)
            break

    # display the result
    #cv2.imshow("img", img)

    _, buffer = cv2.imencode('.jpg', img)
    client_socket.sendall(struct.pack('<L', len(buffer)))
    client_socket.sendall(buffer)

    # Enter q to Quit
    if cv2.waitKey(1) == ord("q"):
        break

cap.release()
cv2.destroyAllWindows()
socket.close()