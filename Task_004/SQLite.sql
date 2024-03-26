-- https://sqliteonline.com/

PRAGMA foreign_keys = ON;

CREATE TABLE members (
  	id INTEGER PRIMARY KEY AUTOINCREMENT,
	name varchar(30),
  	address varchar(60),
  	contact varchar(15),
  	membership_date DATE TIME,
  	status varchar (10)
);

CREATE TABLE movies (
  	id INTEGER PRIMARY KEY AUTOINCREMENT,
	name VARCHAR (50), 
  	genre VARCHAR (20),
  	year INT,
  	status varchar (10)
);

-- DROP TABLE rented
CREATE TABLE rented (
  start_date DATE TIME,
  end_date DATE TIME,
  member_id INTEGER,
  movie_id INTEGER,
  FOREIGN KEY (member_id) REFERENCES members(id),  
  FOREIGN KEY (movie_id) REFERENCES movies(id),
  CONSTRAINT PK_member_movie PRIMARY KEY (member_id, movie_id)
);

CREATE TABLE renting_history (
	start_date DATE TIME,
    end_date DATE TIME,
    member_id INTEGER,
    movie_id INTEGER,
    FOREIGN KEY (member_id) REFERENCES members(id),  
    FOREIGN KEY (movie_id) REFERENCES movies(id),
    CONSTRAINT PK_member_movie_renting_history PRIMARY KEY (member_id, movie_id)
);

/*
Create TABLE movie_genre (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
  	genre varchar(20)
);

Create TABLE movie_genre_junctions (
	movie_id INT FOREIGN KEY REFERENCES movies(id),
    genre_id INT FOREIGN KEY REFERENCES movie_genre(id),
    CONSTRAINT FK_member_movie PRIMARY KEY (movie_id, genre_id)
);
*/

-- a. ispisati sve filmove žanra „Akcija“ (SELECT)
SELECT * FROM movies WHERE genre = "Akcija";

-- b. ispisati sve posuđene filmove žanra „Akcija“ (SELECT)
SELECT m.* FROM movies m, renting r WHERE genre = "Akcija" and r.movie_id = m.id;

-- c. ažurirati žanr svih filmova starijih od 1980. na žanr „Klasika“ (UPDATE)
UPDATE movies
SET genre = "Klasika"
WHERE year < 1980;

-- d. evidentirati povijest posudbe X na dan vraćanja filma u tabelu Povijest Posudbi (INSERT+SELECT) te obrisati posudbu X iz tabele Posudbe (DELETE)
SELECT * FROM rented;
SELECT * FROM renting_history;

INSERT INTO renting_history (start_date, end_date, member_id, movie_id)
SELECT start_date, end_date, member_id, movie_id
FROM rented 
WHERE member_id = 3 AND movie_id = 17;

DELETE FROM rented WHERE member_id = 3 AND movie_id = 17;

-- e. ažurirati status svih članova na status „Frequent“ koji imaju arhivirano više od 50 posudbi (UPDATE)
UPDATE members
SET status = "Frequent"
WHERE id = (
  SELECT member_id FROM (
  	SELECT member_id, COUNT(*) as rental_count
  	FROM renting_history
  	GROUP BY member_id
  ) AS rentals_per_member
  WHERE rental_count > 50
);

SELECT * FROM members


-- PODACI

INSERT INTO members (name, address, contact, membership_date, status) VALUES
('John Doe', '123 Main St, Anytown, USA', '123-456-7890', '2023-05-15', '1'),
('Jane Smith', '456 Elm St, Othertown, USA', '987-654-3210', '2022-11-20', '1'),
('Alice Johnson', '789 Oak St, Anycity, USA', '555-123-4567', '2024-01-10', '0'),
('Bob Williams', '321 Maple St, Anothercity, USA', '444-555-6666', '2023-08-25', '1'),
('Emily Brown', '567 Pine St, Somewhere, USA', '777-888-9999', '2022-10-05', '0'),
('Michael Lee', '890 Birch St, Anywhere, USA', '222-333-4444', '2023-04-30', '1'),
('Sarah Wilson', '234 Cedar St, Nowhere, USA', '666-777-8888', '2024-02-18', '0'),
('David Martinez', '901 Spruce St, Elsewhere, USA', '111-222-3333', '2022-09-12', '1');

-- SELECT * FROM members;



INSERT INTO movies (name, genre, year, status) VALUES
('The Matrix', 'Sci-Fi', 1999, '1'),
('Inception', 'Sci-Fi', 2010, '1'),
('The Godfather', 'Crime', 1972, '1'),
('Pulp Fiction', 'Crime', 1994, '1'),
('The Shawshank Redemption', 'Drama', 1994, '1'),
('Forrest Gump', 'Drama', 1994, '1'),
('The Dark Knight', 'Akcija', 2008, '1'),
('Interstellar', 'Sci-Fi', 2014, '1'),
('Die Hard', 'Akcija', 1988, '1'),
('Mad Max: Fury Road', 'Akcija', 2015, '1');


-- SELECT * FROM movies;


INSERT INTO rented (start_date, end_date, member_id, movie_id) 
VALUES
("01-01-2024", "02-02-2024", 1, 1),
("01-01-2024", "02-02-2025", 1, 2),
("01-01-2024", "02-04-2024", 1, 3),
("01-01-2024", "02-02-2024", 2, 4),
("01-01-2024", "02-02-2024", 3, 17), -- akcija
("01-01-2024", "02-02-2024", 4, 18); -- akcija

-- SELECT * FROM rented;

