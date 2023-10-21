import board

import socketpool

import ssl

import wifi

import neopixel

import time

from adafruit_bme280 import basic as adafruit_bme280

from adafruit_lc709203f import LC709203F, PackSize

import socketpool

import ipaddress

import binascii

import secrets

i2c = board.I2C()

bme280 = adafruit_bme280.Adafruit_BME280_I2C(i2c)

bme280.sea_level_pressure = 1013.25

wifi.radio.connect(

secrets.secrets\["CIRCUITPY_WIFI_SSID"\],

secrets.secrets\["CIRCUITPY_WIFI_PASSWORD"\])

\#Create Socketpool

pool = socketpool.SocketPool(wifi.radio)

while True:

try:

with pool.socket(pool.AF_INET, pool.SOCK_STREAM) as sock:

sock.connect(("192.168.0.101", 11000))

print("Trying request...")

data = f"{bme280.temperature};{bme280.humidity};{bme280.pressure};192.168.1.187"

print(data)

sock.send(data.encode())

print("Made request...")

time.sleep(1)

except pool.error as e:

print(f"Socket error: {e}")

time.sleep(10)  # If there's an error, maybe wait longer before retrying