
ALTER TABLE Lessons
ADD Book INT
GO

ALTER TABLE Lessons
ADD CONSTRAINT FK_Book FOREIGN KEY (Book) REFERENCES Books(Id)
GO

CREATE PROCEDURE DeleteBook
@Id Int
AS
BEGIN
IF EXISTS (SELECT Id FROM Books_EnglishLevels WHERE Book = @Id)
	BEGIN
		DELETE FROM Books_EnglishLevels WHERE Book = @Id
	END
IF NOT EXISTS (SELECT Id FROM Lessons WHERE Book = @Id)
	DELETE FROM Books WHERE Id = @Id

RETURN @@ROWCOUNT

END
GO

ALTER TABLE EnglishLevel
ADD IsDelete BIT DEFAULT 0
GO

CREATE PROCEDURE DeleteEnglishLevel
@Id Int
AS
BEGIN
IF NOT EXISTS (SELECT Id FROM Groups WHERE Min_Level = @Id)
	AND NOT EXISTS (SELECT Id FROM Students WHERE English_Level = @Id)
BEGIN
	DELETE FROM Books_EnglishLevels WHERE EnglishLevel = @Id
	UPDATE EnglishLevel SET IsDelete = 1 WHERE Id = @Id
END
RETURN @@ROWCOUNT
END
GO

ALTER TABLE Exams
ADD IsDelete BIT DEFAULT 0
GO

CREATE PROCEDURE DeleteExam
@Id Int
AS
BEGIN
	UPDATE Exams SET IsDelete = 1 WHERE Id = @Id
	RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE DeleteExamResults
@Id Int
AS
BEGIN
	DELETE FROM ExamResults WHERE Id = @Id

	RETURN @@ROWCOUNT

END
GO

ALTER TABLE Groups
ADD IsDelete BIT DEFAULT 0
GO

CREATE PROCEDURE DeleteGroup
@Id Int

AS
BEGIN
IF NOT EXISTS (SELECT Id FROM Lessons WHERE Group_Number = @Id)
	AND NOT EXISTS( SELECT Id FROM Students WHERE Group_Number = @Id)
		AND NOT EXISTS (SELECT Id FROM Exams WHERE Group_Number = @Id AND IsDelete = 0)
				BEGIN
					UPDATE Groups SET IsDelete = 1 WHERE Id = @Id
				END
	RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE DeleteLesson
@Id Int

AS
BEGIN
	DELETE FROM Lessons WHERE Id = @Id

	RETURN @@ROWCOUNT
END
GO


ALTER TABLE Students
ADD IsDelete BIT DEFAULT 0
GO

CREATE PROCEDURE DeleteStudent
@Id Int

AS
BEGIN
	UPDATE Students SET IsDelete = 1 WHERE Id = @Id
	RETURN @@ROWCOUNT

END
GO

CREATE PROCEDURE DeleteTeacher
@Id Int

AS
BEGIN
	IF NOT EXISTS (SELECT Id FROM Groups WHERE Teacher = @Id)
	BEGIN
		DELETE FROM Teachers WHERE Id = @Id
	END
RETURN @@ROWCOUNT
END
GO
