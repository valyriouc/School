import os
os.chdir(os.path.join(os.path.dirname(os.path.abspath(__file__)), './'))
import pandas as pd
import random

# Data Frame mittels pd aus Datei lesen
df = pd.read_csv("../data/wohnungspreiseGeordnet.csv")   # sep=',' ist Default-Trennzeichen
x = df["Quadratmeter"]    # Spalte mit Quadratmeterpreise in Liste x lesen
#print(X.shape)
y = df["Verkaufspreis"]   # Spalte mit Verkaufspreisen in Liste y lesen

###
### sklearn
###

#print(x.shape)
X = x.values.reshape(-1,1) # erforderlich da sklearn ein zweidimensionales Array erwartet
#print(X.shape)

from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, random_state = 42, test_size = 0.25) # 75% Trainingsdaten 25% Testdaten

# Regression berechnen
from sklearn.linear_model import LinearRegression

model = LinearRegression()
model.fit(X_train, y_train)
score = model.score(X_train, y_train)

print("Intercept: " + str(model.intercept_))
print("Coef: " + str(model.coef_))
print("R2 Score: "+ str(score))
print("y = ",model.coef_[0],"x + ",model.intercept_)
print("R2 Score von Model Test: "+ str(model.score(X_test, y_test)))

# Funktionstest
squaremeter = 70
price = model.coef_[0] * squaremeter + model.intercept_ 
print(price)

# Alternativ mit predict
squaremeters = [[70]]
prices = model.predict(squaremeters)
print(prices[0])
y_pred = model.predict(X_test)



