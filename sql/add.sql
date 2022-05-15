ALTER PROCEDURE AddBook
@Title NVARCHAR(100),
@Author NVARCHAR (100),
@EnglishLevel INT,
@ID INT OUTPUT
AS
BEGIN
IF EXISTS (SELECT Id FROM EnglishLevel WHERE Id = @EnglishLevel AND IsDelete = 0)
	BEGIN
		INSERT INTO Books (Title, Author) VALUES (@Title, @Author)
		SET @ID = SCOPE_IDENTITY();
		INSERT INTO Books_EnglishLevels (Book, EnglishLevel) VALUES (@ID, @EnglishLevel)
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER PROCEDURE AddEnglishLevel
@Letter NVARCHAR,
@Number INT,
@ID INT OUTPUT
AS
BEGIN
	INSERT INTO EnglishLevel(Number, Letter) VALUES (@Number, @Letter)
	SET @ID = SCOPE_IDENTITY();
END
GO

ALTER PROCEDURE AddExam
@Group  INT,
@Date DATETIME,
@ID INT OUTPUT
AS
BEGIN
IF EXISTS (SELECT Id FROM Groups WHERE Id = @Group AND IsDelete = 0)
	BEGIN
		INSERT INTO Exams (Group_Number, Date) VALUES (@Group, @Date)
		SET @ID = SCOPE_IDENTITY();
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER PROCEDURE AddExamResults
@Student  INT ,
@Exam  INT ,
@Mark  INT,
@ID INT OUTPUT
AS
BEGIN
IF EXISTS (SELECT Id FROM Students WHERE Id = @Student AND IsDelete = 0)
	BEGIN
		IF EXISTS( SELECT Id FROM Exams WHERE Id = @Exam  AND IsDelete = 0)
		BEGIN
			INSERT INTO ExamResults(Student, Exam, Mark) VALUES (@Student, @Exam, @Mark)
			SET @ID = SCOPE_IDENTITY();
		END
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER PROCEDURE AddGroup
@Number  INT,
@Teacher  INT,
@MinLevel  INT,
@ID INT OUTPUT
AS
BEGIN
IF NOT EXISTS (SELECT Id FROM Groups WHERE Number = @Number AND IsDelete = 0)
	BEGIN
		IF EXISTS( SELECT Id FROM Teachers WHERE Id = @Teacher)
		BEGIN
			IF EXISTS (SELECT Id FROM EnglishLevel WHERE Id = @MinLevel)
				BEGIN
					INSERT INTO Groups(Number, Teacher, Min_Level) VALUES (@Number, @Teacher, @MinLevel)
					SET @ID = SCOPE_IDENTITY();
				END
		END
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER TABLE Lessons
ADD CONSTRAINT PK_Lesson PRIMARY KEY (Id)
GO


ALTER PROCEDURE AddLesson
@Book  INT,
@Day  DATETIME,
@Hour  INT,
@Group  INT,
@ID INT OUTPUT
AS
BEGIN
IF EXISTS (SELECT Id FROM Groups WHERE Id = @Group  AND IsDelete = 0)
	BEGIN
		IF EXISTS( SELECT Id FROM Books WHERE Id = @Book)
			BEGIN
				INSERT INTO Lessons(Group_Number, Day, Hour, Book) VALUES (@Group, @Day, @Hour, @Book)
				SET @ID = SCOPE_IDENTITY();
			END
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER PROCEDURE AddStudent
@Name NVARCHAR (100),
@Surname NVARCHAR (100),
@EnglishLevel INT,
@GroupNumber INT,
@Age INT,
@ID INT OUTPUT
AS
BEGIN
IF EXISTS (SELECT Id FROM Groups WHERE Id = @GroupNumber  AND IsDelete = 0)
	BEGIN
		IF EXISTS( SELECT Id FROM EnglishLevel WHERE Id = @EnglishLevel AND IsDelete = 0)
			BEGIN
				INSERT INTO Students(Name, Surname, English_Level, Group_Number, Age) VALUES (@Name, @Surname, @EnglishLevel, @GroupNumber, @Age)
				SET @ID = SCOPE_IDENTITY();
			END
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

ALTER TRIGGER addNewStudentTrigger ON Students
AFTER INSERT
AS
BEGIN
	INSERT INTO TransitionToTheGroup(Group_New, Student, Date) SELECT Group_Number, Id, CONVERT (date, GETDATE()) FROM inserted
	INSERT INTO TransitionToTheLevel(Level_New, Student, Date) SELECT English_Level, Id, CONVERT (date, GETDATE()) FROM inserted
END
GO

ALTER PROCEDURE AddTeacher
@Name NVARCHAR (100),
@Surname NVARCHAR (100),
@Age INT,
@Experience INT,
@ID INT OUTPUT
AS
BEGIN
	INSERT INTO Teachers(Name, Surname, Age, Experience) VALUES (@Name, @Surname, @Age, @Experience)
	SET @ID = SCOPE_IDENTITY();
END
GO
