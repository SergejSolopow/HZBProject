import requests
import random
import json
import urllib3
import datetime
import ssl
from time import sleep


class RequestData:
    def __init__(self):
        self.value_map = {"locationId": "string2",
                          "monochromatorPos": 0,
                          "intensity": 0,
                          "temperature": 0,
                          "measureTime": "2022-03-09T12:28:03.174Z",
                          "anglePosition": 0}
        
        self.url_post = "https://localhost:50506/MeasureSet"
        self.url_get = "https://localhost:50506/MeasureSets"
    
    def generate_data(self):
        for x in self.value_map:
            self.value_map[x] = round(random.random(), 2)
        self.value_map["locationId"] = "34"
        self.value_map["measureTime"] = (datetime.datetime.now().isoformat())
        return self.value_map
    
    def post_request(self):
        urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
        for x in range(10):
            requests.post(self.url_post, json = self.generate_data(), verify = False)
            sleep(1.5)
    
    def get_request(self):
        urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
        for x in range(10):
            r = requests.get(self.url_get, json = self.generate_data(), verify = False)
            print(r.json())
            sleep(1.5)            
    
  
if __name__ == "__main__":
    
    instance = RequestData()
    
    