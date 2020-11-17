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


