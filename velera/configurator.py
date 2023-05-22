import json 
import os

class Configuration: 
    def __init__(self, config: dict):
        self.config = config

    def add_setting(self, key, value):
        if (self.has_key(key)):
            raise ValueError("Key ${key} already exists!")
        self.config[key] = value

    def remove_setting(self, key):
        if (not self.has_key(key)):
            raise ValueError("Key ${key} does not exists!")
        self.config.pop(key)

    def edit_setting(self, key, value):
        if (self.has_key(key)):
            self.config[key] = value
        else:
            self.add_setting(key, value)
            
    def get_setting(self, key):
        if (not self.has_key(key)):
            raise ValueError("Key ${key} does not exists!")
        return self.config[key]
    
    def has_key(self, key):
        return key in self.config.keys()
    
    @staticmethod
    def load_from_json(filepath: str):
        config = {}
        if (Configuration.config_file_exists(filepath)):
            with open(filepath, "r") as configFile:
                config = json.load(configFile)

        return Configuration(config)

    @staticmethod
    def config_file_exists(filepath: str):
        return os.path.exists(filepath) and os.path.isfile(filepath) and filepath.endswith(".json") and filepath.count(".") == 1 

    def save_to_file(self, filepath):
        with open(filepath, "w") as configFile:
            json.dump(self.config, configFile)

    @staticmethod
    def make_configuration():
        config = {} 
        
        # TODO: Implement a check for correct year 
        startYear = int(input("When do you started your apprenticeship? "))
        config['startYear'] = startYear


        return Configuration(config)


