CREATE DATABASE Checkpoint2;
GO

USE Checkpoint2;

CREATE TABLE Class(
	classId INT PRIMARY KEY IDENTITY(1, 1),
	classLanguage VARCHAR (80) NOT NULL,
);

CREATE TABLE Student(
	studentId INT PRIMARY KEY IDENTITY(1, 1),
	studentFirstName VARCHAR (80) NOT NULL,
	studentLastName VARCHAR (80) NOT NULL,
	FK_classId INT FOREIGN KEY REFERENCES Class(classId) NOT NULL,

);

CREATE TABLE Assignment(
	assignmentId INT PRIMARY KEY IDENTITY(1, 1),
	assignmentNote DECIMAL NOT NULL,
	FK_studentId INT FOREIGN KEY REFERENCES Student(studentId) NOT NULL,

);
GO

INSERT INTO Class(classLanguage)
	VALUES ('C#'), ('JS');
GO

INSERT INTO Student(studentFirstName, studentLastName, FK_classId)
	VALUES ('Coline', 'Bui', 1), ('Gabriel', 'Said Omar', 1),('Maïlys', 'Dumas', 1),('Sophie', 'Brultet', 1),('Fabien', 'Desnoues', 1),
			('Adrien', 'Faure', 2),('Flavien', 'Besseau', 2),('Alexandre', 'D', 2),('Emeric', 'P', 2),('Emilie', 'A', 2);
GO

INSERT INTO Assignment(assignmentNote, FK_studentId)
	VALUES (12.5, 1), (11.5, 1),
		(14.5, 2), (18.5, 2),
		(15, 3), (13, 3),
		(12.5, 4), (12.5, 4),
		(16.5, 5), (18.5, 5),
		(12, 6), (11, 6),
		(15, 7), (11, 7),
		(10.5, 8), (11.5, 8),
		(15, 9), (15, 9),
		(10, 10), (15, 10);
GO
