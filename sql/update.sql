CREATE PROCEDURE UpdateBook
@Id INT,
@Title NVARCHAR(100),
@Author NVARCHAR (100),
@EnglishLevel INT
AS
BEGIN
IF EXISTS (SELECT Id FROM Books WHERE Id = @Id)
	BEGIN
		UPDATE Books SET Title = @Title, Author = @Author WHERE Id = @Id
		UPDATE Books_EnglishLevels SET EnglishLevel = @EnglishLevel WHERE Book = @Id
		RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateEnglishLevel
@Id INT,
@Letter NVARCHAR,
@Number INT
AS
BEGIN
IF EXISTS (SELECT Id FROM EnglishLevel WHERE Id = @Id)
	BEGIN
	UPDATE EnglishLevel SET Number = @Number, Letter = @Letter WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateExam
@Id INT,
@Group  INT,
@Date DATETIME
AS
BEGIN
IF EXISTS (SELECT Id FROM Exams WHERE Id = @Id)
	BEGIN
	UPDATE Exams SET Group_Number = @Group, Date = @Date WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateExamResults
@Id INT,
@Student  INT ,
@Exam  INT ,
@Mark  INT
AS
BEGIN
IF EXISTS (SELECT Id FROM ExamResults WHERE Id = @Id)
	BEGIN
	UPDATE ExamResults SET Student = @Student, Exam = @Exam, Mark = @Mark WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateGroup
@Id INT,
@Number  INT,
@Teacher  INT,
@MinLevel  INT
AS
BEGIN
IF EXISTS (SELECT Id FROM Groups WHERE Id = @Id)
	BEGIN
	UPDATE Groups SET Number = @Number, Teacher = @Teacher, Min_Level = @MinLevel WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateLesson
@Id INT,
@Book  INT,
@Day  DATETIME,
@Hour  INT,
@Group  INT
AS
BEGIN
IF EXISTS (SELECT Id FROM Lessons WHERE Id = @Id)
	BEGIN
	UPDATE Lessons SET Book = @Book, Day = @Day, Hour = @Hour, Group_Number = @Group WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE PROCEDURE UpdateStudent
@Id INT,
@Name NVARCHAR (100),
@Surname NVARCHAR (100),
@EnglishLevel INT,
@GroupNumber INT
AS
BEGIN
IF EXISTS (SELECT Id FROM Students WHERE Id = @Id)
	BEGIN
	UPDATE Students SET Name = @Name, Surname = @Surname, English_Level = @EnglishLevel, Group_Number = @GroupNumber WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

CREATE TRIGGER updateNewStudentTrigger ON Students
AFTER UPDATE
AS
BEGIN
IF (SELECT Group_Number FROM deleted) != (SELECT Group_Number FROM inserted)
BEGIN
	INSERT INTO TransitionToTheGroup(Group_New, Student) SELECT Group_Number, Id FROM inserted
END
IF (SELECT English_Level FROM deleted) != (SELECT English_Level FROM inserted)
BEGIN
	INSERT INTO TransitionToTheLevel(Level_New, Student) SELECT English_Level, Id FROM inserted
END
END
GO

CREATE PROCEDURE UpdateTeacher
@Id INT,
@Name NVARCHAR (100),
@Surname NVARCHAR (100),
@Age INT,
@Experience INT
AS
BEGIN
IF EXISTS (SELECT Id FROM Teachers WHERE Id = @Id)
	BEGIN
	UPDATE Teachers SET Name = @Name, Surname = @Surname, Age = @Age, Experience = @Experience WHERE Id = @Id
	RETURN 1
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO
