import RPi.GPIO as GPIO
BROADCAST_TO_PORT = 9001
import time
from socket import *
from datetime import datetime

#Vores nummer 1 sensor
SensorID = 1

s = socket(AF_INET, SOCK_DGRAM)
#s.bind(('', 14593))     # (ip, port)
# no explicit bind: will bind to default IP + random port
s.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

GPIO.setmode(GPIO.BOARD)
channel = 5
GPIO.setup(channel, GPIO.IN)

IsOpen = 0

while True:
    Reading = GPIO.input(channel)
    
    if Reading != IsOpen:
        IsOpen = Reading
        #Broadcast the change with [image == null] "(data)" so that we can see the change
        data = str(Reading) + " " + str(SensorID) + " " + str(datetime.now()) + " " + str(IsOpen)
        print(data)
        s.sendto(bytes(data, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
        
        if IsOpen == 1:
            #broadcast with picture
            print()
    time.sleep(1)