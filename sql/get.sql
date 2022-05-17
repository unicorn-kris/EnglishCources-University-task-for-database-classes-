ALTER TABLE Exams
DROP CONSTRAINT FK_Exams_Groups;
GO

ALTER TABLE Lessons
ADD Constraint FK_Exams_Groups Foreign KEY (Group_Number) REFERENCES Groups(Id)
GO

ALTER PROCEDURE SelectAllBooks
AS
BEGIN
	SELECT Id, Author, Title
	FROM Books

	SELECT e.Id AS Id, e.Number AS Number, e.Letter AS Letter, b.Id AS BookId
	FROM Books AS b
	LEFT JOIN Books_EnglishLevels AS be ON be.Book = b.Id
	LEFT JOIN EnglishLevel AS e ON be.EnglishLevel = e.Id
	WHERE e.IsDelete = 0
END
GO

ALTER PROCEDURE SelectBookById
@Id int
AS
BEGIN
	SELECT Id, Author, Title
	FROM Books WHERE Id = @Id

	SELECT e.Id AS Id, e.Number AS Number, e.Letter AS Letter, b.Id AS BookId
	FROM Books AS b
	LEFT JOIN Books_EnglishLevels AS be ON be.Book = b.Id
	LEFT JOIN EnglishLevel AS e ON be.EnglishLevel = e.Id
	WHERE e.IsDelete = 0 AND b.Id = @Id
END
GO


CREATE PROCEDURE SelectBooksByLevel
@Id int
AS
BEGIN
	SELECT b.Id AS Id, Author, Title
	FROM Books AS b
	LEFT JOIN Books_EnglishLevels AS be ON be.Book = b.Id 
	WHERE be.EnglishLevel = @Id

	SELECT e.Id AS Id, e.Number AS Number, e.Letter AS Letter, b.Id AS BookId
	FROM Books_EnglishLevels AS be
	LEFT JOIN EnglishLevel AS e ON be.EnglishLevel = e.Id
	LEFT JOIN Books AS b ON be.Book = b.Id
	WHERE e.IsDelete = 0 AND be.EnglishLevel = @Id
END
GO


CREATE PROCEDURE SelectAllEnglishLevels
AS
BEGIN
	SELECT Id, Number, Letter FROM EnglishLevel
	 WHERE IsDelete = 0
END
GO

CREATE PROCEDURE SelectEnglishLevelById
@Id INT
AS
BEGIN
	SELECT Id, Number, Letter FROM EnglishLevel
		WHERE Id = @Id AND IsDelete = 0
END
GO

CREATE PROCEDURE SortEnglishLevels
@Id INT
AS
BEGIN
	SELECT Id, Number, Letter FROM EnglishLevel
	WHERE IsDelete = 0
		ORDER BY Number, Letter
		
END
GO


CREATE PROCEDURE SelectAllExams
AS
BEGIN
	SELECT Id, Date 
		FROM Exams WHERE IsDelete = 0

	SELECT g.Id AS GoupId, g.Number AS Number, e.Id AS ExamId
		FROM Exams AS e
		LEFT JOIN GROUPS AS g ON e.Group_Number = g.Id
		WHERE e.IsDelete = 0 AND g.IsDelete = 0
END
GO

CREATE PROCEDURE SelectExamById
@Id INT
AS
BEGIN
	SELECT Id, Date 
		FROM Exams WHERE IsDelete = 0 AND Id = @Id

	SELECT g.Id AS GoupId, g.Number AS Number, e.Id AS ExamId
		FROM Exams AS e
		LEFT JOIN GROUPS AS g ON e.Group_Number = g.Id
		WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND e.Id = @Id
END
GO

CREATE PROCEDURE SelectExamsByDay
@Day DateTime
AS
BEGIN
	SELECT Id, Date 
		FROM Exams WHERE IsDelete = 0 AND Date = @Day

	SELECT g.Id AS GoupId, g.Number AS Number, e.Id AS ExamId
		FROM Exams AS e
		LEFT JOIN GROUPS AS g ON e.Group_Number = g.Id
		WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND e.Date = @Day
END
GO

CREATE PROCEDURE SelectExamsByGroup
@GroupId INT
AS
BEGIN
	SELECT Id, Date 
		FROM Exams WHERE IsDelete = 0 AND Group_Number = @GroupId

	SELECT g.Id AS GoupId, g.Number AS Number, e.Id AS ExamId
		FROM Exams AS e
		LEFT JOIN GROUPS AS g ON e.Group_Number = g.Id
		WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND g.Id = @GroupId
END
GO

CREATE PROCEDURE SelectAllExamResults
AS
BEGIN
	SELECT Id, Mark FROM ExamResults 

	SELECT e.Id AS Id, e.Date AS Date, er.Id AS ExamResultsId
	FROM  ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id 
	WHERE e.IsDelete = 0

	SELECT g.Id AS GroupId, g.Number AS Number, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id
	LEFT JOIN Groups AS g ON g.Id = e.Group_Number
	WHERE e.IsDelete = 0 AND g.IsDelete = 0 

	SELECT s.Id AS Students, s.Name AS Name, s.Surname AS Surname, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Students AS s ON er.Student = s.Id
	WHERE s.IsDelete = 0 
END
GO

CREATE PROCEDURE SelectExamResultsById
@Id INT
AS
BEGIN
	SELECT Id, Mark FROM ExamResults 
	WHERE Id = @Id

	SELECT e.Id AS Id, e.Date AS Date, er.Id AS ExamResultsId
	FROM  ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id 
	WHERE e.IsDelete = 0 AND er.Id = @Id

	SELECT g.Id AS GroupId, g.Number AS Number, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id
	LEFT JOIN Groups AS g ON g.Id = e.Group_Number
	WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND er.Id = @Id

	SELECT s.Id AS Students, s.Name AS Name, s.Surname AS Surname, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Students AS s ON er.Student = s.Id
	WHERE s.IsDelete = 0 AND er.Id = @Id
END
GO

CREATE PROCEDURE SelectExamResultsByMark
@Mark INT
AS
BEGIN
	SELECT Id, Mark FROM ExamResults 
	WHERE Mark = @Mark

	SELECT e.Id AS Id, e.Date AS Date, er.Id AS ExamResultsId
	FROM  ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id 
	WHERE e.IsDelete = 0 AND er.Mark = Mark

	SELECT g.Id AS GroupId, g.Number AS Number, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id
	LEFT JOIN Groups AS g ON g.Id = e.Group_Number
	WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND er.Mark = Mark

	SELECT s.Id AS Students, s.Name AS Name, s.Surname AS Surname, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Students AS s ON er.Student = s.Id
	WHERE s.IsDelete = 0 AND er.Mark = Mark
END
GO

CREATE PROCEDURE SelectExamResultsByStudentt
@StudentId INT
AS
BEGIN
	SELECT Id, Mark FROM ExamResults 
	WHERE Student = @StudentId

	SELECT e.Id AS Id, e.Date AS Date, er.Id AS ExamResultsId
	FROM  ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id 
	WHERE e.IsDelete = 0 AND er.Student = @StudentId

	SELECT g.Id AS GroupId, g.Number AS Number, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Exams AS e ON er.Exam = e.Id
	LEFT JOIN Groups AS g ON g.Id = e.Group_Number
	WHERE e.IsDelete = 0 AND g.IsDelete = 0 AND er.Student = @StudentId

	SELECT s.Id AS Students, s.Name AS Name, s.Surname AS Surname, er.Id AS ExamResultsId
	FROM ExamResults AS er
	LEFT JOIN Students AS s ON er.Student = @StudentId
	WHERE s.IsDelete = 0 
END
GO

CREATE PROCEDURE SelectAllGroups
AS
BEGIN
	SELECT Id, Number
	FROM Groups
	WHERE IsDelete = 0

	SELECT t.Id AS TeacherId, t.Name AS Name, t.Surname AS Surname, t.Age AS Age, t.Experience AS Experience, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN Teachers AS t ON g.Teacher = t.Id
	WHERE g.IsDelete = 0

	SELECT e.Id AS LevelId, e.Number AS Number, e.Letter AS Letter, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN EnglishLevel AS e ON g.Min_Level = e.Id
	WHERE g.IsDelete = 0 AND e.IsDelete = 0
END
GO

CREATE PROCEDURE SelectGroupById
@Id INT
AS
BEGIN
	SELECT Id, Number
	FROM Groups
	WHERE IsDelete = 0 AND Id = @Id

	SELECT t.Id AS TeacherId, t.Name AS Name, t.Surname AS Surname, t.Age AS Age, t.Experience AS Experience, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN Teachers AS t ON g.Teacher = t.Id
	WHERE g.IsDelete = 0 AND g.Id = @Id

	SELECT e.Id AS LevelId, e.Number AS Number, e.Letter AS Letter, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN EnglishLevel AS e ON g.Min_Level = e.Id
	WHERE g.IsDelete = 0 AND e.IsDelete = 0 AND g.Id = @Id
END
GO

CREATE PROCEDURE SelectGroupByNumber
@Number INT
AS
BEGIN
	SELECT Id, Number
	FROM Groups
	WHERE IsDelete = 0 AND Number = @Number

	SELECT t.Id AS TeacherId, t.Name AS Name, t.Surname AS Surname, t.Age AS Age, t.Experience AS Experience, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN Teachers AS t ON g.Teacher = t.Id
	WHERE g.IsDelete = 0 AND g.Number = @Number

	SELECT e.Id AS LevelId, e.Number AS Number, e.Letter AS Letter, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN EnglishLevel AS e ON g.Min_Level = e.Id
	WHERE g.IsDelete = 0 AND e.IsDelete = 0 AND g.Number = @Number
END
GO

CREATE PROCEDURE SelectGroupsByLevel
@EnglishLevel INT
AS
BEGIN
	SELECT Id, Number
	FROM Groups
	WHERE IsDelete = 0 AND Min_Level = @EnglishLevel

	SELECT t.Id AS TeacherId, t.Name AS Name, t.Surname AS Surname, t.Age AS Age, t.Experience AS Experience, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN Teachers AS t ON g.Teacher = t.Id
	WHERE g.IsDelete = 0 AND g.Min_Level = @EnglishLevel

	SELECT e.Id AS LevelId, e.Number AS Number, e.Letter AS Letter, g.Id AS GroupId
	FROM Groups AS g
	LEFT JOIN EnglishLevel AS e ON g.Min_Level = e.Id
	WHERE g.IsDelete = 0 AND e.IsDelete = 0 AND g.Min_Level = @EnglishLevel
END
GO

CREATE PROCEDURE SelectAllLessons
AS
BEGIN
	SELECT Id, Day, Hour 
	FROM Lessons
	
	SELECT g.Id AS GroupId, g.Number AS Number, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Groups AS g ON l.Group_Number = g.Id
	WHERE g.IsDelete = 0

	SELECT b.Id AS BookId,b.Author AS Author, b.Title AS Title, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Books AS b ON l.Book = b.Id
END
GO

CREATE PROCEDURE SelectLessonById
@Id INT
AS
BEGIN
	SELECT Id, Day, Hour 
	FROM Lessons WHERE Id = @Id
	
	SELECT g.Id AS GroupId, g.Number AS Number, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Groups AS g ON l.Group_Number = g.Id
	WHERE g.IsDelete = 0 AND l.Id = @Id

	SELECT b.Id AS BookId,b.Author AS Author, b.Title AS Title, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Books AS b ON l.Book = b.Id
	WHERE l.Id = @Id
END
GO

CREATE PROCEDURE SelectLessonsByGroup
@GroupId INT
AS
BEGIN
	SELECT Id, Day, Hour 
	FROM Lessons WHERE Group_Number = @GroupId
	
	SELECT g.Id AS GroupId, g.Number AS Number, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Groups AS g ON @GroupId = g.Id
	WHERE g.IsDelete = 0 

	SELECT b.Id AS BookId,b.Author AS Author, b.Title AS Title, l.Id AS LessonId
	FROM Lessons AS l
	LEFT JOIN Books AS b ON l.Book = b.Id
	WHERE l. Group_Number = @GroupId
END
GO


CREATE PROCEDURE SelectAllStudents
AS
BEGIN
	SELECT Id, Name, Surname
	FROM Students

	SELECT g.Id AS GroupId, g.Number AS Number, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN Groups As g ON s.Group_Number = g.Id
	WHERE g.IsDelete = 0

	SELECT e.Id AS EnglishLevelId, e.Number AS Number,  e.Letter AS Letter, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN EnglishLevel As e ON s.English_Level = e.Id
	WHERE e.IsDelete = 0

END
GO

CREATE PROCEDURE SelectStudentById
@Id INT
AS
BEGIN
	SELECT Id, Name, Surname
	FROM Students WHERE Id = @Id

	SELECT g.Id AS GroupId, g.Number AS Number, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN Groups As g ON s.Group_Number = g.Id
	WHERE g.IsDelete = 0 AND s.Id = @Id

	SELECT e.Id AS EnglishLevelId, e.Number AS Number,  e.Letter AS Letter, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN EnglishLevel As e ON s.English_Level = e.Id
	WHERE e.IsDelete = 0 AND s.Id = @Id

END
GO

ALTER PROCEDURE SelectStudentByGroup
@GroupId INT
AS
BEGIN
	SELECT Id, Name, Surname
	FROM Students WHERE Group_Number = @GroupId

	SELECT g.Id AS GroupId, g.Number AS Number, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN Groups As g ON @GroupId = g.Id
	WHERE g.IsDelete = 0  AND s.Group_Number = @GroupId

	SELECT e.Id AS EnglishLevelId, e.Number AS Number,  e.Letter AS Letter, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN EnglishLevel As e ON s.English_Level = e.Id
	WHERE e.IsDelete = 0 AND s.Group_Number = @GroupId

END
GO

ALTER PROCEDURE SelectStudentsByLevel
@LevelId INT
AS
BEGIN
	SELECT Id, Name, Surname
	FROM Students WHERE English_Level = @LevelId

	SELECT g.Id AS GroupId, g.Number AS Number, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN Groups As g ON s.Group_Number = g.Id
	WHERE g.IsDelete = 0 AND s.English_Level = @LevelId

	SELECT e.Id AS EnglishLevelId, e.Number AS Number,  e.Letter AS Letter, s.Id AS StudentId
	FROM Students AS s
	LEFT JOIN EnglishLevel As e ON @LevelId = e.Id
	WHERE e.IsDelete = 0 AND s.English_Level = @LevelId

END
GO

CREATE PROCEDURE SelectAllTeachers
AS
BEGIN
	SELECT Id, Name, Surname, Age, Experience
	FROM Teachers 
END
GO

CREATE PROCEDURE SelectTeacherById
@Id INT
AS
BEGIN
	SELECT Id, Name, Surname, Age, Experience
	FROM Teachers WHERE Id = @Id
END
GO

CREATE PROCEDURE SortTeachersByExperience
AS
BEGIN
	SELECT Id, Name, Surname, Age, Experience
	FROM Teachers 
	ORDER BY Experience
END
GO



CREATE PROCEDURE SelectAllTransitionsToTheGroup
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheGroup 

	SELECT g.Id AS GroupId, g.Number AS Number, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Groups AS g ON t.Group_New = g.Id

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
END
GO

CREATE PROCEDURE SelectTransitionToTheGroupById
@Id INT
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheGroup WHERE Id = @Id

	SELECT g.Id AS GroupId, g.Number AS Number, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Groups AS g ON t.Group_New = g.Id
	WHERE t.Id = @Id

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
	WHERE t.Id = @Id
END
GO

CREATE PROCEDURE SelectTransitionsToTheGroupByGroup
@GroupId INT
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheGroup WHERE Group_New = @GroupId

	SELECT g.Id AS GroupId, g.Number AS Number, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Groups AS g ON @GroupId = g.Id
	

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
	WHERE t.Group_New = @GroupId
END
GO

CREATE PROCEDURE SortTransitionsToTheGroupByDate
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheGroup 
	ORDER BY Date

	SELECT g.Id AS GroupId, g.Number AS Number, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Groups AS g ON t.Group_New = g.Id
	

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheGroup AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
END
GO



CREATE PROCEDURE SelectAllTransitionsToTheLevel
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheLevel 

	SELECT l.Id AS LevelId, l.Number AS Number, l.letter AS Letter, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN EnglishLevel AS l ON t.Level_New = l.Id

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
END
GO

CREATE PROCEDURE SelectTransitionToTheLevelById
@Id INT
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheLevel WHERE Id = @Id

	SELECT l.Id AS LevelId, l.Number AS Number, l.letter AS Letter, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN EnglishLevel AS l ON t.Level_New = l.Id
	WHERE t.Id = @Id

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
	WHERE t.Id = @Id
END
GO

CREATE PROCEDURE SelectTransitionsToTheLevelByLevel
@LevelId INT
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheLevel WHERE Level_New = @LevelId

	SELECT l.Id AS LevelId, l.Number AS Number, l.letter AS Letter, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN EnglishLevel AS l ON @LevelId = l.Id
	

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
	WHERE t.Level_New = @LevelId
END
GO

CREATE PROCEDURE SortTransitionsToTheLevelByDate
AS
BEGIN
	SELECT Id, Date
	FROM TransitionToTheLevel 
	ORDER BY Date

	SELECT l.Id AS LevelId, l.Number AS Number, l.letter AS Letter, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN EnglishLevel AS l ON t.Level_New = l.Id
	

	SELECT s.Id AS StudentId, s.Name AS Name, s.Surname AS Surname, t.Id AS TransitionId
	FROM TransitionToTheLevel AS t
	LEFT JOIN Students AS s ON t.Student = s.Id
END
GO