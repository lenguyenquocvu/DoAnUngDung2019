--CREATED CSDL


--CREATED Database MANAGE_STUDENT

CREATE DATABASE MANAGE_STUDENT
GO

--Su dung database
USE MANAGE_STUDENT
GO

--CREATED TABLE CLASSES_LIST (DSLOP)
--drop table CLASSES_LIST
CREATE TABLE CLASSESLIST
(
	ClassCode varchar(10) primary key,
	ClassName nvarchar(55),
)
GO

--CREATED TABLE STUDENT
--drop table STUDENT
CREATE TABLE STUDENT
(
	StudentCode varchar(10) primary key,
	StudentName nvarchar(50),
	StudentGender bit,
	PlaceOfBirth nvarchar (50) not null,
	DataOfBirth date,
	ClassCode varchar(10),
	CourseCode varchar(5)
)
GO

--CREATED TABLE TESTSCORE
CREATE TABLE TESTSCORE
(
	StudentCode varchar(10),
	SubjectsClassCode varchar(20),
	SubjectMark float,
	PRIMARY KEY (StudentCode,SubjectsClassCode)
)
GO

--CREATED TABLE SUBJECTS
CREATE TABLE SUBJECTS
(
	SubjectCode varchar(10) primary key,
	SubjectName nvarchar(50),
	Credit int
)
GO

--CREATED TABLE SUBJECTSCLASS
CREATE TABLE SUBJECTSCLASS
(
	SubjectsClassCode varchar(20) primary key,
	SubjectSClassName nvarchar(55),
	SubjectLesson int,
	SemesterCode tinyint,
	ScholasticCode tinyint
)
GO

--CREATED TABLE SEMESTER
CREATE TABLE SEMESTER
(
	SemesterCode tinyint primary key,
	SemesterName nvarchar(15)
)

--CREATED TABLE SCHOLASTIC
CREATE TABLE SCHOLASTIC
(
	ScholasticCode tinyint primary key,
	ScholasticName varchar(15)
)

--CREATED TABLE COURSE
CREATE TABLE COURSE
(
	CourseCode varchar(5) primary key,
	CourseName varchar(15)
)


--CREATED FOREIGN KEY STUDENT 
ALTER TABLE STUDENT ADD CONSTRAINT FK_CLASSES_LIST_STUDENT FOREIGN KEY (ClassCode) 
REFERENCES CLASSESLIST(ClassCode) ON DELETE CASCADE ON UPDATE CASCADE
--CREATED FOREIGN KEY TESTSCORE
ALTER TABLE TESTSCORE ADD CONSTRAINT FK_STUDENT_TESTSCORE FOREIGN KEY (StudentCode) 
REFERENCES STUDENT (StudentCode) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE TESTSCORE ADD CONSTRAINT FK_SUBJECTS_TESTSCORE FOREIGN KEY (SubjectsClassCode) 
REFERENCES SUBJECTSCLASS (SubjectsClassCode) ON DELETE CASCADE ON UPDATE CASCADE
-----------------------------------------------------------------------------------

--CREATED FOREIGN KEY SUBJECTSCLASS
ALTER TABLE SUBJECTSCLASS ADD CONSTRAINT FK_SEMESTER_SUBJECTSCLASS FOREIGN KEY (SemesterCode) 
REFERENCES SEMESTER (SemesterCode) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE SUBJECTSCLASS ADD CONSTRAINT FK_SCHOLASTIC_SUBJECTSCLASS FOREIGN KEY (ScholasticCode) 
REFERENCES SCHOLASTIC (ScholasticCode) ON DELETE CASCADE ON UPDATE CASCADE

GO

-- INSERT DATA INTO SCHOLASTIC TABLE
INSERT INTO COURSE (CourseCode, CourseName) 
VALUES ('K18', '2018-2021'),
	   ('K19', '2019-2022')
GO

-- INSERT DATA INTO SCHOLASTIC TABLE
INSERT INTO SCHOLASTIC (ScholasticCode, ScholasticName) 
VALUES (18, '2018-2019'),
	   (19, '2019-2020')
GO

-- INSERT DATA INTO CREDITS TABLE
INSERT INTO SEMESTER (SemesterCode, SemesterName) 
VALUES (1, 'Học Kỳ 1'),
	   (2, 'Học kỳ 2'),
	   (3, 'Học kỳ hè')
GO

-- INSERT DATA INTO CLASSESLIST TABLE
INSERT INTO CLASSESLIST (ClassCode, ClassName) 
VALUES ('CD18TT01' , N'CNTT 01'),
	   ('CD19TT02' , N'CNTT 02'),
	   ('CD18TM01' , N'TRUYỀN THÔNG MẠNG 01'),
	   ('CD19TM02' , N'TRUYỀN THÔNG MẠNG 02'),
	   ('CD18DH01' , N'ĐỒ HỌA 01'),
	   ('CD19DH02' , N'ĐỒ HỌA 02')
GO

-- INSERT DATA INTO STUDENT TABLE
INSERT INTO STUDENT (StudentCode, StudentName, StudentGender, PlaceOfBirth, DataOfBirth, ClassCode, CourseCode)
VALUES ('18TT0001' , N'HUỲNH THIÊN ÂN' , 0 , N'TRÀ VINH' , '09/02/1995' , 'CD18TT01', 'K18'),
	   ('18TM0001' , N'TRẦN THỊ HẢO' , 0 , N'TPHCM' , '07/16/1995' , 'CD18TM01', 'K18'),
	   ('18DH0001' , N'TRƯƠNG PHÚ BÌNH' , 1 , N'HÀ NỘI' , '11/13/1996' , 'CD18DH01', 'K18'),
	   ('19TT0002' , N'NGUYỄN THANH HẢI' , 1 , N'KHÁNH HÒA' , '07/24/1996' , 'CD19TT02', 'K19'),
	   ('19TM0002' , N'PHẠM TUẤN ANH' , 1 , N'TPHCM' , '01/13/1996' , 'CD19TM02', 'K19'),
	   ('19DH0002' , N'LÝ SIỄU MINH' , 0 , N'ĐÀ LẠT' , '02/26/1995' , 'CD19DH02', 'K19')
GO

-- INSERT DATA INTO SUBJECTS TABLE
INSERT INTO SUBJECTS (SubjectCode, SubjectName, Credit)
VALUES ('CNC1001' , N'LẬP TRÌNH ỨNG DỤNG', 3),
	   ('CNC1002' , N'LẬP TRÌNH JAVA', 3)
GO

-- INSERT DATA INTO SUBJECTSCLASS TABLE
INSERT INTO SUBJECTSCLASS (SubjectsClassCode, SubjectSClassName, SubjectLesson, SemesterCode, ScholasticCode)
VALUES  ('18CNC1001', N'LẬP TRÌNH ỨNG DỤNG', 75, 1, 18),
		('18CNC1002', N'LẬP TRÌNH JAVA', 75, 1, 18),
		('19CNC1001', N'LẬP TRÌNH ỨNG DỤNG', 75, 1, 19),
		('19CNC1002', N'LẬP TRÌNH JAVA', 75,1, 19)
GO
-- INSERT DATA INTO TESTSCORE TABLE
INSERT INTO TESTSCORE (StudentCode, SubjectsClassCode, SubjectMark)
VALUES ('18TT0001' , '18CNC1001' , 6),
	   ('18TT0001' , '18CNC1002' , 7),
	   ('18TM0001' , '18CNC1001' , 6),
	   ('18TM0001' , '18CNC1002' , 7),
	   ('18DH0001' , '18CNC1001' , 6),
	   ('18DH0001' , '18CNC1002' , 7),
	   ('19TT0002' , '19CNC1001' , 5),
	   ('19TT0002' , '19CNC1002' , 5),
	   ('19TM0002' , '19CNC1001' , 5),
	   ('19TM0002' , '19CNC1002' , 5),
	   ('19DH0002' , '19CNC1001' , 5),
	   ('19DH0002' , '19CNC1002' , 5)
GO

