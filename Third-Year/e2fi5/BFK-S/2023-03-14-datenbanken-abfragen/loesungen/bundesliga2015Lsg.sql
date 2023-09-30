-- 1. Zeige alle verfügbaren Daten der Tabelle „Verein“ an.
-- SELECT * FROM Verein; 

-- 2. Welche Vereine spielen in der zweiten Liga?
-- SELECT Name FROM Verein WHERE Liga=2;

-- 3. Wann war die Erstaustragung eines Spiels der ersten Fußball-Bundeslga?
-- SELECT Erstaustragung FROM Liga WHERE Liga_Nr=1; 

-- 4. Wähle Liga_Nr, Verband und Rekordspieler aller drei Ligen aus.
-- SELECT Liga_Nr, Verband,Rekordspieler FROM Liga; 

-- 5. Zeige alle Vereine an, die die Abkürzung „FC“ im Namen haben.
-- SELECT * FROM Verein WHERE Name LIKE '%FC%'; 

-- 6. An welchem Tag fand das erste Spiel in dieser Saison statt?
-- SELECT MIN(Datum) FROM Spiel;


-- 7. Wie viele Tore wurden in der Saison geschossen ?
--SELECT SUM(Tore_Heim + Tore_Gast) AS Tore_Gesamt FROM Spiel; 


-- 8. Welche Spieler haben in dieser Saison bereits mehr als fünfzehn Tore geschossen? Ordne Sie absteigend nach der Anzahl ihrer Tore.
-- SELECT Spieler_Name,Tore FROM Spieler WHERE Tore > 15 ORDER BY Tore DESC;

-- 9. Wie viele Spieler tragen die Trikot-Nr 12? Benenne die Ergebnisspalte in „Anzahl“ um.
-- SELECT  COUNT(*) AS Anzahl FROM Spieler WHERE Trikot_Nr=12;

-- 10. Welche deutschen Spieler (Land: D) haben in dieser Saison noch an keinem Spiel teilgenommen?
-- SELECT  Spieler_Name  FROM Spieler WHERE Land='D' AND Spiele=0;

-- 11. Zeige die Daten aller Spiele an, die am ersten Spieltag aller drei Ligen nach 17 Uhr begonnen haben.
-- SELECT * FROM Spiel WHERE Spieltag=1 AND Uhrzeit>'17:00';

-- Zusatz: Wer ist der Rekordspieler der zweiten Bundesliga und an wie vielen Spielen hat er teilgenommen?
--SELECT Rekordspieler ,Spiele_Rekordspieler FROM Liga WHERE Liga_Nr=2;

-- 12. Wie viele Tore wurden bisher durchschnittlich von den Spielern geschossen, die schon an mehr als 3 Spielen teilgenommen und mehr als 2 Vorlagen geliefert haben?
-- SELECT AVG(Tore) FROM Spieler WHERE Spiele>3 AND Vorlagen>2;

-- 13. Liste alle Spiele auf, die im August stattgefunden und nach 19 Uhr begonnen haben.
-- SELECT * FROM Spiel WHERE Uhrzeit>'19:00' AND (Datum BETWEEN '2015-08-01' AND '2015-08-31');

-- -----------------------------------------------------------------------------------

-- A14 Welcher Verein war Meister der zweiten Liga? Schreibe zuerst die Abfrage, die die
-- Vereinsnummer des Meisters aus der Tabelle Liga ermittelt. Erstelle dann die Ab-
-- frage aus Verein, die den zugehörigen Namen findet und füge die erste als Sub-
-- query ein.

-- select meister from liga where liga_nr=2; -- => 17
-- select verein.name from verein where verein.v_id=17;
--
-- also: 
-- 
-- select verein.name from verein 
-- where verein.v_id= (select meister from liga where liga_nr=2);
--
-- alternativ:
--
-- SELECT V.Name AS Meister FROM Liga 
--     JOIN Verein AS V
--     ON Meister= V.V_ID WHERE Liga_Nr=2;
--


-- 15. Welcher Spieler hat bisher für den Verein mit der ID 20 die meisten Tore geschossen?

-- select * from verein where verein.v_id=20; -- -> VFL Bochum
-- select * from spieler where spieler.vereins_id=20;
-- select max(tore) from spieler where spieler.vereins_id=20; -- => 20
-- select * from spieler where spieler.vereins_id=20;
-- select spieler_name from spieler where spieler.vereins_id=20 and spieler.tore=20;
--
-- Also
--
-- select spieler_name from spieler where 
-- spieler.vereins_id=20 and 
-- spieler.tore=(select max(tore) from spieler where spieler.vereins_id=20);


-- 16. Liste alle Spieler auf, die überdurchschnittlich viele Tore geschossen haben. Be-
-- stimme dazu in einer Subquery die durchschnittliche Anzahl Tore.

-- select avg(tore) FROM spieler;
--
-- Also
--
--select spieler.spieler_name from spieler where spieler.tore > 
--  (select avg(tore) FROM spieler);


-- Zusatz. Wer (Name) war am ersten Spieltag Gegner von „Dynamo Dresden“  ? Finde die V_ID von „Dynamo Dresden“ zuvor mit einer eigenen SQL-Abfrage heraus.
-- SELECT V_ID FROM Verein WHERE Name LIKE '%Dresden%';
-- SELECT * FROM Spiel JOIN Verein ON Gast=V_ID WHERE Spieltag=2 AND Heim=27;
-- Auch möglich: den SELECT nach der V_ID von Dresden als Unterabfrage direkt einfügen
-- SELECT * FROM Spiel JOIN Verein ON Gast=V_ID WHERE Spieltag=2 AND Heim=
--    (SELECT V_ID FROM Verein WHERE Name LIKE '%Dresden%');


-- 17. Welche Spieler spielen für den Verein “SC Freiburg“? Gib auch die 
-- Trikotnummer und das Heimatland jedes Spielers sowie die Anzahl seiner Tore mit aus. 
-- Ordne die Ergebnisse aufsteigend nach der Trikotnummer.
-- SELECT Trikot_Nr,Spieler_Name,Land,Tore FROM Spieler 
--   JOIN Verein ON Spieler.Vereins_ID=Verein.V_ID
--   WHERE Verein.Name = 'SC Freiburg'
--   ORDER BY Trikot_Nr;


-- 18. Gib Trikotnummer, Name und die Anzahl der Tore aller Spieler der zweiten Liga
-- aus, die bisher schon mehr als 10 Tore geschossen haben. Ordne nach der Anzahl
-- ihrer Tore.
--
-- SELECT trikot_nr, spieler_name, tore FROM spieler, verein 
-- WHERE spieler.vereins_id=verein.v_id and verein.liga=2
--       and tore>10;


-- 19. a) Welche Vereine haben bisher ein Heimspiel gegen den Verein mit der V_ID 10
--       gewonnen? Wie lauteten die Ergebnisse dieser Spiele?

-- i) Einfache Anfrage mit Ausgabe der vereins_id
-- 
-- SELECT heim, tore_heim,tore_gast FROM spiel WHERE gast=10 and tore_heim>tore_gast;
-- 
-- ii) Gleiche Anfrage mit Ausgabe des Vereinsnamen
-- 
-- SELECT verein.name, tore_heim,tore_gast FROM spiel, verein WHERE verein.v_id=spiel.heim and gast=10 and tore_heim>tore_gast;

-- 19. b) Welche Vereine haben bisher ein Spiel gegen den Verein mit der V_ID 10
--       gewonnen? Wie lauteten die Ergebnisse dieser Spiele? Hinweis:hier muss man
--       eine umfangreichere Bedingung in der ON-Klausel formulieren.
--
-- SELECT verein.name, tore_heim,tore_gast FROM spiel, verein 
-- WHERE (verein.v_id=spiel.heim and gast=10 and tore_heim>tore_gast) OR 
--       (verein.v_id=spiel.gast and heim=10 and tore_gast>tore_heim);
--
--
-- 
-- 19. An welchen Tagen finden die Spiele der ersten Liga statt?
-- Hinweis: Jedes Datum darf nur einmal ausgegeben werden.
--SELECT DISTINCT(Datum) FROM Spiel 
--    JOIN Verein ON V_ID=Gast AND Verein.Liga=1 WHERE Spieltag=1
--    ORDER BY Datum; 

-- ---------------------- Hier weiter --------------------------------------------


-- 20. Zeige für jeden brasilianischen Spieler der ersten Liga an wie vielen Spielen er teilgenommen hat. 
-- Gib außerdem die Anzahl ihrer Tore und Vorlagen und den Namen des Vereins aus, für den sie spielen.
-- SELECT Spieler_Name,Name,Tore,Vorlagen 
-- FROM Spieler 
-- JOIN Verein ON Vereins_ID=V_ID
-- WHERE Land='BRA' 
-- ORDER BY Name; -- ORDER war nicht gefordert


-- 21. Gib Trikotnummer, Name und die Anzahl der Tore aller Spieler der zweiten Liga, 
-- die bisher schon mehr als 10 Tore geschossen haben, geordnet nach der Anzahl ihrer Tore aus. 
-- SELECT Trikot_Nr,Spieler_Name,Tore FROM Spieler
-- JOIN Verein ON Vereins_ID=V_ID
-- WHERE Liga=2 AND Tore>10;
-- 
-- 22. Welche Vereine haben bisher gegen den Verein mit der V_ID 10 gewonnen? Wie
-- lauteten die Ergebnisse dieser Spiele?

-- SELECT Spieltag,Name,Tore_Heim,Tore_Gast FROM Spiel
-- JOIN Verein on 
--   (Heim <> 10 AND Heim=V_ID) OR (Gast<>10 AND Gast=V_ID)
-- WHERE (Heim=10 AND Tore_Heim< Tore_Gast) 
--     OR (Gast=10 AND Tore_Gast<Tore_Heim)
-- ORDER BY Spieltag
-- ;
-- 
-- oder
-- SELECT Spieltag,Name,Tore_Heim AS Tore Mannschaft 10,Tore_Gast  AS Tore Gegner
-- FROM Spiel JOINVerein ON 
--     Gast=V_ID
-- WHERE Heim=10 AND Tore_Heim<Tore_Gast
-- 
-- UNION -- das Ergebnis zweier abfragen aneinanderhängen. Beide Abfragen
--       -- müssen genau die gleichen Ergebnisspalten haben
-- SELECT Spieltag,Name,Tore_Gast AS Tore Mannschaft 10,Tore_Heim AS Tore Gegner
-- FROM Spiel JOINVerein ON 
--     Heim=V_ID
-- WHERE Gast=10 AND Tore_Heim>Tore_Gast
-- ORDER BY Spieltag;

-- 23. Welcher Spieler hat  für den „1. FC Nürnberg“ die meisten Tore geschos-
-- sen? (!)

-- SELECT Spieler_Name ,Spieler.Tore FROM Spieler
-- JOIN Verein ON
--   V_ID=Vereins_ID
-- WHERE Verein.Name = '1. FC Nürnberg'
-- ORDER BY Tore DESC LIMIT 1; -- Nicht so gut, weil es mehrere Spieler geben könnte, die die Maximaltorzahl erreichen
-- 
-- SELECT Spieler.Spieler_Name,Tore FROM Spieler
-- JOIN Verein ON
--   V_ID=Vereins_ID
--  WHERE Verein.Name = '1. FC Nürnberg'
--   AND Tore = (
--         SELECT  MAX(Tore) FROM  Spieler
--             JOIN Verein ON
--                 V_ID=Vereins_ID
--                 WHERE Verein.Name = '1. FC Nürnberg')


-- 24. Welche Vereine haben am ersten Spieltag der ersten Liga gegeneinander ge-
-- spielt, wie lauten die Ergebnisse?

-- SELECT A.Name AS Heim, B.Name AS Gast,
--         Tore_Heim,Tore_Gast
-- FROM Spiel 
-- JOIN Verein AS A ON
--     A.V_ID = Heim
-- JOIN Verein AS B ON
--     B.V_ID = Gast
-- WHERE Spieltag=1 AND A.Liga=1;


-- 25. Gegen welche Vereine hat der „FC Schalke 04“ bisher Auswärtsspiele bestritten?

-- SELECT Spieltag,Name AS Gastgeber FROM Spiel
-- JOIN Verein ON Heim=V_ID
-- WHERE Gast=(    
--     SELECT V_ID FROM Verein WHERE Name='FC Schalke 04');

-- 26. Wie viele Spiele hat „Hannover 96“ bis heute gewonnen? (!)
-- SELECT COUNT(*) AS Hannover gewann so oft FROM Spiel
-- JOIN Verein
-- ON (V_ID=Heim AND Tore_Heim>Tore_Gast )  
--     OR (V_ID=Gast AND Tore_Gast>Tore_Heim)
-- WHERE Name = 'Hannover 96';

-----------------------------------------------------------------------
---   GROUP BY
---------------------------------------------------------------
-- 27. Wie viele Spieler hat jeder Verein der ersten Liga? Gib die Ergebnisse mit dem
--Vereinsnamen aus und ordne sie absteigend nach der Anzahl der Spieler.


-- SELECT verein.name, count(spieler.spieler_id) AS Anzahl 
-- FROM spieler, verein 
-- WHERE spieler.vereins_id=verein.v_id and verein.liga=1 
-- GROUP BY verein.name 
-- ORDER BY Anzahl DESC;
--
-- oder mit JOIN
--
-- SELECT Name,COUNT(Spieler_ID) AS Anzahl FROM Verein
-- JOIN Spieler ON V_ID=Vereins_ID
-- GROUP BY Name
-- ORDER BY  Anzahl DESC;
-- 


-- 28. Wie viele Tore sind bisher in jeder Liga gefallen?
--SELECT Liga,SUM(Tore_Heim)+SUM(Tore_Gast) AS Tore FROM Spiel JOIN Verein ON
--Gast=V_ID GROUP BY Verein.Liga;

-- 29. Welche Vereine (Name, Liga) haben  schon mindestens fünfmal unentschie-
-- den gespielt? Ordne das Ergebnis aufsteigend nach der Liga und absteigend
-- nach der Zahl der Unentschieden.
--SELECT Liga,Name,COUNT(Spiel_ID)  AS Anzahl Unentschieden FROM Verein 
--     JOIN Spiel ON Gast=V_ID OR Heim=V_ID
--     WHERE Tore_Heim=Tore_Gast
--     
--     GROUP BY Name,Liga
--     HAVING COUNT(Spiel_ID) >=5
--   ORDER BY Liga,Anzahl Unentschieden DESC;

--30. Erstelle eine Liste in der für jeden Verein anzeigt, wie viele 
--Heimspiele er gewonnen hat.

-- SELECT Name,COUNT(Heim) AS a FROM Spiel
-- JOIN Verein ON V_ID=Heim
-- WHERE Tore_Heim>Tore_Gast
-- GROUP BY Name;

--31. Gib die Liste aller Zweitligavereine mit Ihren in Auswärtsspielen erreichten Punkten aus. 
--Hinweis: Bei jedem Spiel gilt: Sieg = 3 Punkte, Unentschieden = 1 Punkt, Niederlage = 0 Punkte
-- Zur Lösung: Man kann anstelle einer Tabelle auch das Ergebnis einer
-- Abfrage verwenden, da jedes Ergebnis ja in sich wieder tabellarisch
-- aufgebaut ist. Eine Subquery, die in einem FROM .. JOIN benutzt
-- wird MUSS einen Namen bekommen -> AS ... hinter der Klammer
-- Dadurch kann man sie erst in weiteren Vergleichen (ON, WHERE) benutzen)
-- Hier habe ich erste eine einzelne Query aufgebaut, die alle Auswärtssiege
--pro Mannschaft zählt, dann das gleiche für Unentschieden.
-- Danach habe ich diese Einzelqueries zu Subquerys gemacht, und mit
-- Verein verjoint, um den eigentlichen Namen zu finden.
-- Das ganze ist zugegebenermaßen Fortgeschrittenenzeugs.
-- SELECT Name,sieg*3+un*1 FROM Verein 
--         JOIN
--             (
--              SELECT Gast, COUNT(*) AS sieg FROM Spiel 
--               WHERE Tore_Gast>Tore_Heim
--                GROUP BY Gast ) AS A 
--         ON A.Gast =V_ID               
--         JOIN (
--             SELECT Gast,COUNT(*) AS un FROM Spiel 
--             WHERE Tore_Gast=Tore_Heim
--             GROUP BY Gast ) AS B
--         ON V_ID = B.Gast

 -- ;

-- 32. Welcher Verein hat bisher die meisten Tore geschossen? (!)
-- Hinweis: Mit dem Vergleich
-- >= ALL(...Unterabfrage...) in der HAVING-Klausel
-- kann man den größten der durch GROUP BY ermittelten Werte bestimmen.
--Möglichkeit 1 (ohne ALL):
-- SELECT Name,SUM(Tore) AS Tore FROM Spieler
--   JOIN Verein ON V_ID = Vereins_ID
--   GROUP BY Name
--   HAVING SUM(Tore) >= (
--  
--          SELECT MAX(t) FROM (SELECT Vereins_ID,SUM(Tore) AS t FROM Spieler
--          GROUP BY Vereins_ID) AS a
--   )
-- ;
----Möglichkeit 1 (mit ALL):
-- SELECT Name,SUM(Tore) AS Tore FROM Spieler
--   JOIN Verein ON V_ID = Vereins_ID
--   GROUP BY Name
--   HAVING SUM(Tore) >= 
--            ALL (
--                SELECT Vereins_ID,SUM(Tore) 
--                    FROM Spieler  GROUP BY Vereins_ID)
-- ;

