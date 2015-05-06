import os
import platform
import psutil 
import socket
from time import sleep
import time
import json


class SensorSystemInfomation():
	interval = 0.0	
	isRunning = True
	msg = {}	
	dataToMeas = {}
	
	def __init__(self, config):
		self.config = config
		self.interval = 1.0 / config.frequency
		self.msg['sensor_name'] = self.getSensorName()	
		self.dataToMeas = {
			'systemName' : self.systemName,
			'CPU' : self.CPU,
			'architecture' : self.architecture,
			'totalRAM' : self.totalRAM,
			'totalDiskSpace' : self.totalDiskSpace
		}
		
	def stop(self):
		self.isRunning = False

	def run(self):
		print("Sensor1: System information");
		self.measureData()

	def measureData(self):
		dataToSend = self.msg.copy()
		while self.isRunning:
			for metric, methodPtr in self.dataToMeas.items():
				dataToSend['metric'] = metric
				dataToSend['data'] = {'val' : methodPtr(), 'time' : str(self.getTimestamp()) }
				json_msg = json.JSONEncoder().encode(dataToSend)
				print(json_msg)
			print("============") #sending data is under development
			sleep(self.interval)

	def getSensorName(self):
		return self.config.sensorname;

	def systemName(self):
		return platform.system() + " " + platform.release()

	def CPU(self): 
		return platform.processor()
		
	def architecture(self):
		return platform.architecture()[0]

	def totalRAM(self):
		mem = psutil.virtual_memory()
		return int(mem.total)
		
	def totalDiskSpace(self):
		return psutil.disk_usage('/').total
	
	def getTimestamp(self):
		return int(time.time());