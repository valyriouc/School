
from .configurator import Configuration
import os
import sys
import shutil

class FileHandler:
    downloadFolder = "Download"

    def __init__(self, config: Configuration) -> None:
        self.config = config
        
    @staticmethod
    def map_year_to_destination(startYear):
        folders = {
            1: "First-Year",
            2: "Second-Year",
            3: "Third-Year"
        }

        return folders[startYear]
    
    @staticmethod 
    def get_class_name(startYear):
        classes = {
            1: "e1fi3",
            2: "e2fi3",
            3: "e3fi3"
        }

        return classes[startYear]
    
    @staticmethod
    def exists(path):
        return os.path.exists(path)
    
    @staticmethod
    def get_files_recursive(path, parent):
        files = []
        for item in os.listdir(path):
            p = os.path.join(path, item)
            if os.path.isfile(p):
                file_relative = p.replace(parent, "")
                files.append(file_relative)
            else:
                result_files = FileHandler.get_files_recursive(p, parent)
                files.extend(result_files)
        return files

    @staticmethod
    def filter_files(source, destination):
        filtered = []
        for s in source:
            if s not in destination:
                filtered.append(s)
        return filtered
    
    @staticmethod
    def handle_missing_folder(folder: str):
        path = folder.rsplit("\\", 1)[0]
        if (not os.path.exists(path)):
            os.makedirs(path)
        
    @staticmethod
    def copy_files(files: list, source, destination):
        for file in files:
            file = str(file)
            try:
                src = f"{source}{file}"
                dst = f"{destination}{file}"
                shutil.copyfile(src, dst)
            except:
                FileHandler.handle_missing_folder(dst)
                shutil.copyfile(src, dst)
            
    def run(self):

        downloadFolder = os.path.join(os.getcwd(), FileHandler.downloadFolder)

        sourceFolder = os.path.join(downloadFolder, FileHandler.get_class_name(self.config.get_setting('yearNumber')))
        destinationFolder = os.path.join(os.getcwd(), FileHandler.map_year_to_destination(self.config.get_setting('yearNumber')))

        if (not FileHandler.exists(sourceFolder)):
            print("No content provided!!!")
            sys.exit(-1)

        if (not FileHandler.exists(destinationFolder)):
            print(f"Main folder for {self.config.get_setting('yearNumber')} does not exists!!!")
            sys.exit(-1)

        # Getting all files from the download section
        source = FileHandler.get_files_recursive(sourceFolder, sourceFolder)

        # Getting all files from the destination section
        destination = FileHandler.get_files_recursive(destinationFolder, destinationFolder)

        # Getting all files which are in Download but not in the destination folder
        filtered = FileHandler.filter_files(source, destination)

        # Copying this files to the destination folder
        FileHandler.copy_files(filtered, sourceFolder, destinationFolder)

        # At the end delete the downloaded content
        for u in downloadFolder:
            shutil.rmtree(u)
        
        # TODO: Implement automated git commiting
        
        # Auto commit changes

        