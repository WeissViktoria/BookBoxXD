-- Benutzer 1
INSERT INTO BENUTZER (BENUTZER_NAME, PASSWORT)
VALUES ('MaxMustermann', 'Passwort123');

-- Benutzer 2
INSERT INTO BENUTZER (BENUTZER_NAME, PASSWORT, EMAIL_ADDRESSE, GEBURTSTAG)
VALUES ('AnnaMusterfrau', 'SicheresPasswort1', 'anna.musterfrau@example.com', '1985-08-22');

-- Benutzer 3
INSERT INTO BENUTZER (BENUTZER_NAME, PASSWORT, EMAIL_ADDRESSE, GEBURTSTAG)
VALUES ('JohnDoe', 'SuperSecure123', 'john.doe@example.com', '2000-01-30');

-- Benutzer 4
INSERT INTO BENUTZER (BENUTZER_NAME, PASSWORT, EMAIL_ADDRESSE, GEBURTSTAG)
VALUES ('JuliaSchmidt', 'Passw0rd!', 'julia.schmidt@example.com', '1995-03-10');

-- Benutzer 5
INSERT INTO BENUTZER (BENUTZER_NAME, PASSWORT, EMAIL_ADDRESSE, GEBURTSTAG)
VALUES ('StefanMüller', 'Müller@2025', 'stefan.mueller@example.com', '1988-12-04');


INSERT INTO BUECHER (TITEL, AUTOR, BESCHREIBUNG, ERSTER_SATZ, COVER_URL, ISBN, OLID)
VALUES ('Beispiel Titel', 'Beispiel Autor', 'Beispiel Beschreibung', 'Beispiel erster Satz', 'https://example.com/cover.jpg', '1234567890', 'OLID12345');

ALTER TABLE BENUTZER
    ADD COLUMN LOGGED_IN BOOLEAN DEFAULT FALSE;

ALTER TABLE BENUTZER
    MODIFY COLUMN EMAIL_ADDRESSE VARCHAR(100) NULL;

ALTER TABLE BENUTZER
    MODIFY COLUMN GEBURTSTAG DATETIME NULL;

ALTER TABLE BENUTZER MODIFY COLUMN PROFIL_BILD BLOB NULL;

DELETE FROM BUECHER WHERE BUCH_ID = 4;



ALTER TABLE BUECHER
    ADD OLID VARCHAR(100);

ALTER TABLE BUECHER
    MODIFY BESCHREIBUNG VARCHAR(2000);

ALTER TABLE BUECHER
    MODIFY OLID INT NOT NULL;

ALTER TABLE BUECHER
    MODIFY COLUMN ERSTER_SATZ VARCHAR(1000) NULL;

ALTER TABLE BUECHER
    MODIFY COLUMN COVER_URL VARCHAR(400) NULL;

ALTER TABLE BUECHER
    MODIFY COLUMN ISBN VARCHAR(50) NULL;

ALTER TABLE BUECHER
    MODIFY COLUMN TITEL VARCHAR(100) NULL;

ALTER TABLE BUECHER
    MODIFY COLUMN AUTOR VARCHAR(200) NULL;

INSERT INTO BUECHER (TITEL, AUTOR, BESCHREIBUNG, ERSTER_SATZ, COVER_URL, ISBN, OLID)
VALUES (null, null, null, null, null,'1234567890', 'OLID12345');




