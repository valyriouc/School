import board
import wifi
import neopixel
import time
import secrets
from adafruit_bme280 import basic as adafruit_bme280
from adafruit_lc709203f import LC709203F, PackSize
import socketpool
import adafruit_minimqtt.adafruit_minimqtt as MQTT

i2c = board.I2C()
bme280 = adafruit_bme280.Adafruit_BME280_I2C(i2c)

bme280.sea_level_pressure = 1013.25
pixel = neopixel.NeoPixel(board.NEOPIXEL, 1)

wifi.radio.connect(
    secrets.secret["ssid"], 
    secrets.secret["password"])

pool = socketpool.SocketPool(wifi.radio)

while True:

    temp = bme280.temperature
    humid = bme280.humidity
    press = bme280.pressure

    # MQTT.set_socket(sock)

    with MQTT.MQTT(
            broker="192.168.0.101",
            username="mqtt_user",
            password="mqtt_user",
            socket_pool=pool
        ) as mqtt_client:

        mqtt_client.connect()
        mqtt_client.publish("klassenraum/ron/temp", temp)
        mqtt_client.subscribe("klassenraum/eren/temp")
        print("connected to ")
        def on_message(client, userdata, msg):
            print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
            print(f"{userdata}")
        mqtt_client.on_message = on_message
