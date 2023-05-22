-- Aufgabe aus Prüfung So 2015 GAII A2 

-- myDB.sql
  -- Erzeuge die Tabelle test

-- DROP DATABASE db; CREATE DATABASE db; \c db

DROP TABLE kundendaten;
DROP TABLE trainingsdaten;
DROP TABLE messwerte;

CREATE TABLE kundendaten( 
  kundenID integer PRIMARY KEY, 
  name varchar(50),
  vorname varchar(50),
  gebdatum date,
  groesse real,
  geschlecht varchar(1)
);

CREATE TABLE trainingsdaten( 
  trainingsID integer PRIMARY KEY,
  kundenID integer, 
  datum date,
  gewicht real,
  trainingsziel varchar(20)
);

CREATE TABLE messwerte( 
  trainingsID integer,
  zeitpunkt time, 
  aktFrequenz integer,
  CONSTRAINT pk1 PRIMARY KEY(trainingsID,zeitpunkt) 
);

INSERT INTO kundendaten VALUES (1392,'Dick','Mitarbeiter','01.01.1980',1.70,'m');
INSERT INTO kundendaten VALUES (2,'Schlank','Mitarbeiter','1975-01-01',1.50,'m');

INSERT INTO trainingsdaten VALUES (1,1392,'2015-04-17',90.0,'Fitness');
INSERT INTO trainingsdaten VALUES (2,1392,'2015-04-27',88.0,'Fitness');
INSERT INTO trainingsdaten VALUES (3,2,'2015-04-17',60.0,'Muskelaufbau');
INSERT INTO trainingsdaten VALUES (4,2,'2015-04-27',68.0,'Muskelaufbau');

INSERT INTO messwerte VALUES(1,'13:00:01',140);
INSERT INTO messwerte VALUES(1,'13:00:05',145);
INSERT INTO messwerte VALUES(1,'13:00:10',150);

INSERT INTO messwerte VALUES(2,'14:00:01',110);
INSERT INTO messwerte VALUES(2,'14:00:05',115);
INSERT INTO messwerte VALUES(2,'14:00:10',120);



select kundendaten.gebdatum, trainingsdaten.trainingsziel
FROM kundendaten INNER JOIN trainingsdaten ON kundendaten.kundenID=trainingsdaten.kundenID
WHERE kundendaten.kundenID=1392 AND trainingsdaten.datum='17.04.2015';


/*
select kundendaten.kundenID, count(*) as AnzahlMessungen from messwerte, trainingsdaten, kundendaten where kundendaten.kundenID = trainingsdaten.kundenID and trainingsdaten.trainingsID = messwerte.trainingsID and trainingsdaten.datum = '2015-04-17' and kundendaten.kundenID = 1392 group by kundendaten.kundenID;
*/

/*
SELECT 
count(kundendaten.*) as AnzahlMessungen
FROM
kundendaten INNER JOIN trainingsdaten ON (kundendaten.kundenID = trainingsdaten.kundenID)
INNER JOIN messwerte ON (trainingsdaten.trainingsID = messwerte.trainingsID)
WHERE
trainingsdaten.datum = '2015.04.17' AND kundendaten.kundenID = '1392'
GROUP BY kundendaten.kundenID;
*/



/*
-- select messwerte.trainingsID, messwerte.zeitpunkt 
select count(messwerte.trainingsID) AS AnzahlMessungen
FROM messwerte, trainingsdaten
WHERE messwerte.trainingsID=trainingsdaten.trainingsID
AND trainingsdaten.kundenID=1392 ;
*/
