import sys

from Config import *
from SensorSystemInfomation import *


if __name__ == "__main__":
	config = Config()	
	sensor = SensorSystemInfomation(config)
	
	try:
		sensor.run()
	except:
		sensor.stop()
		print("terminating because of error:", sys.exc_info())
		
