import RPi.GPIO as GPIO
BROADCAST_TO_PORT = 9001
import time
from socket import *
from datetime import datetime
import requests
from PIL import Image
import os
import PIL
import glob
import urllib
import base64
from pushbullet import Pushbullet

#Vores nummer 1 sensor
SensorID = 1

s = socket(AF_INET, SOCK_DGRAM)
s.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

GPIO.setmode(GPIO.BOARD)
channel = 5
GPIO.setup(channel, GPIO.IN)

pb = Pushbullet("o.A0gGsWLmgPF64Ju3gZWQ2P4tbTZ7v4g1")
print(pb.devices)

IsOpen = 0
IsOpenbool = "false"

while True:
    Reading = GPIO.input(channel)
    
    if (Reading != IsOpen) and (IsOpen == 1):
        IsOpen = Reading
        if Reading == 0:
            IsOpenbool = "false"
        else:
            IsOpenbool = "true"
        data1 = str(SensorID) + " " + str("1") + " " + str(int(time.time())) + " " + str(IsOpenbool)  + " " + str("null") 
        print(data1)
        #Broadcast the change with [image == null] "(data)" so that we can see the change
        s.sendto(bytes(data1, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
        time.sleep(1)
    if Reading != IsOpen:
        IsOpen = 1
        if Reading == 1:
            IsOpenbool = "true"
        else:
            IsOpenbool = "false"
        
        #broadcast with picture
        r = requests.get('https://100k-faces.glitch.me/random-image')
        print(r.url)
        urllib.request.urlretrieve(r.url, "image.jpg")
        image = Image.open("image.jpg")
        print(image.size)
        image = Image.open('image.jpg')
        new_image = image.resize((128, 128))
        new_image.save('image128.jpg')
        time.sleep(2)
        print(new_image.size)
        time.sleep(2)
        with open("image128.jpg", "rb") as imageFile:
            bar = base64.b64encode(imageFile.read())
        os.path.getsize('image128.jpg')
        

        data = str(SensorID) + " " + str("1") + " " + str(int(time.time())) + " " + str(IsOpenbool)  + " " +  str(bar) 
        print(data)
        dev = pb.get_device('OnePlus IN2023')
        push = dev.push_note("ALERT!!", "SOMEONE IS IN YOUR SLIKSKAB")
        s.sendto(bytes(data, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
        time.sleep(1)