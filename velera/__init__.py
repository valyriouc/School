from .configurator import Configuration
from .timehandler import TimeHandler
from .filehandler import FileHandler

# TODO: Implement a webscraper for the nextcloud and moodle to automate the file download 

def main():
    configFilePath = "config.json"

    config = None
    if not Configuration.config_file_exists(configFilePath):
        config = Configuration.make_configuration()
    else:
        config = Configuration.load_from_json(configFilePath)

    startYear = config.get_setting("startYear")

    config.edit_setting("yearNumber", TimeHandler.get_current_training_year(startYear))
    fileHandler = FileHandler(config)
    fileHandler.run()

    config.save_to_file(configFilePath)