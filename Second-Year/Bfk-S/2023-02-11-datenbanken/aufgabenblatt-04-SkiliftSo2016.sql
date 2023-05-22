-- myDB.sql
  -- Erzeuge die Tabelle test

-- DROP DATABASE db; CREATE DATABASE db; \c db

 DROP TABLE Bestellung;
 DROP TABLE Kunden;

CREATE TABLE Kunden( 
  KundenNr INTEGER PRIMARY KEY, 
  Name varchar(100));


CREATE TABLE Bestellung( 
  BestellNr INTEGER PRIMARY KEY, 
  KundenNr INTEGER REFERENCES Kunden(KundenNr)), 
  Bestelldatum TIME NOT NULL);




SELECT * FROM Kunden;
