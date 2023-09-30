# Welche Tracks gibt es von den Red Hot Chili Peppers? Geben Sie die TrackId, den Namen des Lieds und den Bandnamen aus. 
SELECT t.TrackId, t.name, a.name
FROM artist a, album al, track t
WHERE a.ArtistId = al.ArtistId
AND al.AlbumId = t.AlbumId
AND a.name = "Red Hot Chili Peppers";
# Zugang nächste Frage: Die niedrigste TrackId in den Ergebnissen -> 2358


# Welche Tracks gehören zu einem Genre das das Wort "Metal" enthält? Geben Sie die Track-ID, den Namen des Lieds und zum Prüfen den Genre-Namen aus
SELECT genre.name, track.trackid, track.name 
FROM genre, track
WHERE genre.Name LIKE "%Metal%"
AND genre.GenreId = track.GenreId;
# Zugang nächste Frage: Der Name des Liedes mit der kleinsten TrackID -> Enter Sandman (trackid: 77)


# Welche Alben haben einen Song namens "Intro" und von welchem Künstler stammen sie? Geben Sie Künstlername, Albumname und Liedname zur Überprüfung aus
SELECT track.name, artist.Name, album.Title 
FROM track, artist, album
WHERE track.AlbumId = album.AlbumId
AND album.ArtistId = artist.ArtistId
AND track.name = "Intro";
# Zugang zur nächsten Frage: Der kürzeste Bandname in der Ergebnisliste -> Nirvana

# Wie viele Lieder sind von den jeweiligen mediatypen verfügbar? Geben Sie den Namen des Medientyps und die Zahl an
SELECT mediatype.Name, count(*) AS "Verfügbare Titel"
FROM Mediatype, track
WHERE track.MediaTypeId = mediatype.MediaTypeId
GROUP BY mediatype.Name
ORDER BY "Verfügbare Titel" DESC;
# Zugang nächste Frage: Zahl der Lieder des am häufigsten enthaltenen Typs -> 3034


# Welche Liednamen kommen in der Datenbank wie oft vor? 
# Gruppieren Sie nach Namen und geben Sie nach Häufigkeit absteigend aus, wenn das Lied mehr als einmal vorkommt. 
SELECT track.Name, COUNT(*) 
FROM chinook.track
GROUP BY track.Name
HAVING COUNT(*) >1
ORDER BY COUNT(*) DESC; 
# Zugang nächste Frage: Wie oft kommt der häufigste Name vor? ->5

# Wie heißen die Playlists, die Lieder der Band "The Rolling Stones" enthalten? 
# Geben Sie nur den Namen der Playlist aus und vermeiden Sie Duplikate
SELECT DISTINCT p.name 
FROM artist a, album al,track t, playlisttrack pt, playlist p 
WHERE a.ArtistId = al.ArtistId 
AND t.AlbumId = al.AlbumId
AND t.TrackId = pt.TrackId
AND pt.PlaylistId = p.PlaylistId
AND a.name LIKE "%Rolling Stones%";
# Zugang nächste Frage: Das Wort, das alle gefundenen Playlists enthalten. ->Music


# Geben Sie aus, welcher Kunde wie viel Geld für den Kauf von Liedern ausgegeben hat
SELECT customer.LastName, SUM(track.UnitPrice) AS WieViel
FROM track, invoiceline, invoice, customer
WHERE track.TrackId = invoiceline.TrackId
AND invoiceline.InvoiceId = invoice.InvoiceId
AND customer.CustomerId = invoice.CustomerId
GROUP BY customer.CustomerId
ORDER BY WieViel DESC;
# Zugang: Name des Kunden, der 46.62 ausgegeben hat -> Rojas



# Geben Sie aus, wie viele Fans (-> Käufer der Musik) die einzelnen Künstler haben
SELECT artist.name, COUNT(DISTINCT customer.customerId) AS ZahlFans
FROM artist, album, track, invoiceline, invoice, customer
WHERE artist.ArtistId = album.ArtistId
AND album.AlbumId = track.AlbumId
AND track.TrackId = invoiceline.TrackId
AND invoiceline.InvoiceId = invoice.InvoiceId
AND invoice.CustomerId = customer.customerid
group by artist.name
ORDER BY ZahlFans DESC;

# Zugang: Name der Band, die am meisten Käufer hat -> U2


# Wie lang sind die einzelnen Playlists in Minuten? Geben Sie ids und Name nur dann aus, wenn die Playlist länger als eine Stunde dauert  
SELECT p.PlaylistId,p.name, ROUND(SUM(t.Milliseconds)/60000) AS Dauer
FROM playlist p, playlisttrack pt, track t
WHERE p.playlistid = pt.playlistid
AND pt.trackid = t.trackid
GROUP BY p.PlaylistId
HAVING Dauer > 60
ORDER BY Dauer ASC;

# Zugang zu Bonus-Fragen: Name der kuerzesten gefundenen Playlist -> Grunge


# Bonus1: Geben Sie für jedes Lied aus, wie viel Geld damit eingenommen wurde. Auch Lieder, die nie verkauft wurden, sollen auftauchen 
SELECT track.TrackId, track.Name, track.UnitPrice*COUNT(invoiceline.InvoiceLineId) AS Einnahmen
FROM track LEFT JOIN invoiceline
ON track.TrackId = invoiceline.TrackId
group by track.TrackId, track.Name
ORDER BY track.trackid ASC;



# Bonus2 UNION: Geben Sie die Vornamen, Nachnamen und Telefonnummer aller Angestellten und aller Kunden aus 
SELECT employee.firstname, employee.lastname AS Nachname, employee.phone
FROM employee
UNION
SELECT customer.firstname, customer.lastname, customer.phone
FROM customer
ORDER BY Nachname ASC;


# Frage des Tages: Welche Kunden haben Musik von den Red Hot Chili Peppers gekauft? 
SELECT DISTINCT customer.email
FROM artist, album, track, invoiceline, invoice, customer
WHERE artist.ArtistId = album.ArtistId
AND album.AlbumId = track.AlbumId
AND track.TrackId = invoiceline.TrackId
AND invoiceline.InvoiceId = invoice.InvoiceId
AND customer.CustomerId = invoice.CustomerId
AND artist.name= "Red Hot Chili Peppers";

#...Und wieviele Lieder haben Sie jeweils gekauft?
SELECT customer.LastName, customer.email, COUNT(*) AS Gekaufte_RHCP_Lieder
FROM artist, album, track, invoiceline, invoice, customer
WHERE artist.ArtistId = album.ArtistId
AND album.AlbumId = track.AlbumId
AND track.TrackId = invoiceline.TrackId
AND invoiceline.InvoiceId = invoice.InvoiceId
AND customer.CustomerId = invoice.CustomerId
AND artist.name= "Red Hot Chili Peppers"
GROUP BY customer.CustomerID, customer.email;



