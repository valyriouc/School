import wifi

import secrets

import binascii

import ipaddress

import socketpool

import time

import board

from adafruit_bme280 import basic as adafruit_bme280

from adafruit_lc709203f import LC709203F, PackSize

\# Create sensor objects, using the board's default I2C bus.

i2c = board.I2C()  # uses board.SCL and board.SDA

\# i2c = board.STEMMA_I2C()  # For using the built-in STEMMA QT connector on a microcontroller

bme280 = adafruit_bme280.Adafruit_BME280_I2C(i2c)

battery_monitor = LC709203F(i2c)

battery_monitor.pack_size = PackSize.MAH400

\# change this to match your location's pressure (hPa) at sea level

bme280.sea_level_pressure = 1013.25

\# Get wifi details and more from a secrets.py file

try:

    from secrets import secrets

except ImportError:

    print('''Wifi secrets are kept in secrets.py, please add them here!''')

    raise

\# Connect to wifi

ssid = secrets\["ssid"\]

pwd = secrets\["password"\]

print(f"Connecting to wifi: {ssid} / {pwd}")

wifi.radio.connect(secrets\["ssid"\], secrets\["password"\])

print("My IP address is", wifi.radio.ipv4_address)

print("My MAC address is", binascii.hexlify(wifi.radio.mac_address, ':').decode('utf-8'.upper()))

\# ipv4 = ipaddress.ip_address("8.8.4.4")

\# print("Ping google.com: %f ms" % (wifi.radio.ping(ipv4)\*1000))

pool = socketpool.SocketPool(wifi.radio)

print("Creating Socket")

while True:

    with pool.socket(pool.AF_INET, pool.SOCK_STREAM) as s:

        s.settimeout(3000)

        # print(f"Connecting to {HOST} @ Port {PORT}")

        print(f"Connecting to 192.168.0.101 @ Port 11000")

        s.connect(("192.168.0.101", 11000))

        print("Sending")

        message = f"1453;1453;1453;192.168.1.69;"

        print(message)

        sent = s.send(message)

        print("Receiving")

        buff = bytearray(128)

        numbytes = s.recv_into(buff)

        print(repr(buff))

        print(numbytes)

        sleep(1000)