import datetime

class TimeHandler:
    
    @staticmethod
    def get_current_training_year(startYear: int):
        """ This function should return the current training year based on the starting year"""
        if (not TimeHandler.validate_year(startYear)):
            raise ValueError("Year must be between 2000 and 2099")

        today = datetime.date.today()

        if (today >= datetime.date(startYear, 9, 1) and today <= datetime.date(startYear + 1, 8, 31)):
            return 1
        elif (today >= datetime.date(startYear + 1, 9, 1) and today <= datetime.date(startYear + 2, 8, 31)):
            return 2
        elif (today >= datetime.date(startYear + 2, 9, 1) and today <= datetime.date(startYear + 3, 8, 31)):
            return 3
        else:
            return -1

    @staticmethod
    def validate_year(year):
        return year >= 2000 and year <= 2099

    
