DROP TABLE IF EXISTS Offers;
DROP TABLE IF EXISTS Class_Schedule;
DROP TABLE IF EXISTS Class;
DROP TABLE IF EXISTS Member_Phone;
DROP TABLE IF EXISTS Member;
DROP TABLE IF EXISTS Workout_Plan;
DROP TABLE IF EXISTS Trainer;
DROP TABLE IF EXISTS Branch_Manager;
DROP TABLE IF EXISTS Membership;
DROP TABLE IF EXISTS Equipment;

CREATE TABLE Membership (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Duration VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0)
);

INSERT INTO Membership (Duration, Price) VALUES
('1 Month', 300.00),
('3 Months', 800.00),
('6 Months', 1500.00);

CREATE TABLE Branch_Manager (
    Branch_ID INT IDENTITY(1,1) PRIMARY KEY,
    Type VARCHAR(50) NOT NULL CHECK (Type IN ('Male','Female','Mixed')),
    City VARCHAR(50) NOT NULL,
    Area VARCHAR(50) NOT NULL,
    Manager_ID INT UNIQUE NOT NULL,
    Manager_Fname VARCHAR(50) NOT NULL,
    Manager_Lname VARCHAR(50) NOT NULL,
    Manager_Phone VARCHAR(20) UNIQUE
);

INSERT INTO Branch_Manager
(Type, City, Area, Manager_ID, Manager_Fname, Manager_Lname, Manager_Phone)
VALUES
('Male', 'Cairo', 'Nasr City', 101, 'Ahmed', 'Ali', '01011111111'),
('Female', 'Giza', 'Dokki', 102, 'Sara', 'Omar', '01022222222'),
('Mixed', 'Alex', 'Smouha', 103, 'Mona', 'Hassan', '01033333333');

CREATE TABLE Trainer (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Fname VARCHAR(50) NOT NULL,
    Lname VARCHAR(50) NOT NULL,
    Gender VARCHAR(10) NOT NULL CHECK (Gender IN ('Male', 'Female')),
    Shift VARCHAR(20) CHECK (Shift IN ('Morning', 'Evening', 'Night')),
    Speciality VARCHAR(50) CHECK (Speciality IN 
    ('Cardio', 'Yoga', 'Strength', 'CrossFit', 'Pilates',
     'Zumba', 'Bodybuilding', 'Aerobics', 'Powerlifting')),
    Phone VARCHAR(20) UNIQUE,
    Branch_ID INT NOT NULL,
    FOREIGN KEY (Branch_ID) REFERENCES Branch_Manager(Branch_ID)
);

INSERT INTO Trainer
(Fname, Lname, Gender, Shift, Speciality, Phone, Branch_ID)
VALUES
('Ali', 'Mahmoud', 'Male', 'Morning', 'Cardio', '01111111111', 1),
('Nour', 'Samy', 'Female', 'Evening', 'Yoga', '01122222222', 2),
('Omar', 'Khaled', 'Male', 'Morning', 'Strength', '01133333333', 3);

CREATE TABLE Workout_Plan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL CHECK (Name IN (
        'Weight Loss',
        'Muscle Gain',
        'Fitness Starter',
        'Bodybuilding',
        'Cardio Blast',
        'Fat Burn',
        'Strength Builder'
    )),
    Duration INT NOT NULL CHECK (Duration > 0),
    Intensity_Level VARCHAR(20) NOT NULL CHECK (Intensity_Level IN ('Low', 'Medium', 'High')),
    Trainer_ID INT NOT NULL,
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(ID)
);

INSERT INTO Workout_Plan
(Name, Duration, Intensity_Level, Trainer_ID)
VALUES
('Weight Loss', 8, 'Medium', 1),
('Muscle Gain', 12, 'High', 2),
('Fitness Starter', 6, 'Low', 3);

CREATE TABLE Member (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Fname VARCHAR(50) NOT NULL,
    Lname VARCHAR(50) NOT NULL,
    Gender VARCHAR(10) NOT NULL CHECK (Gender IN ('Male', 'Female')),
    Join_Date DATE NOT NULL,
    Membership_ID INT NOT NULL,
    Start_Date DATE NOT NULL,
    Branch_ID INT NOT NULL,
    Plan_ID INT,
    FOREIGN KEY (Membership_ID) REFERENCES Membership(ID),
    FOREIGN KEY (Branch_ID) REFERENCES Branch_Manager(Branch_ID),
    FOREIGN KEY (Plan_ID) REFERENCES Workout_Plan(ID)
);

INSERT INTO Member
(Fname, Lname, Gender, Join_Date, Membership_ID, Start_Date, Branch_ID, Plan_ID)
VALUES
('Mariam', 'Adel', 'Female', '2026-04-01', 1, '2026-04-02', 1, 1),
('Youssef', 'Hany', 'Male', '2026-04-03', 2, '2026-04-04', 2, 2),
('Salma', 'Tarek', 'Female', '2026-04-05', 3, '2026-04-06', 3, 3);

CREATE TABLE Member_Phone (
    Member_ID INT NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    PRIMARY KEY (Member_ID, Phone),
    FOREIGN KEY (Member_ID) REFERENCES Member(ID)
);

INSERT INTO Member_Phone VALUES
(1, '01211111111'),
(2, '01222222222'),
(3, '01233333333');

CREATE TABLE Class (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Trainer_ID INT NOT NULL,
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(ID)
);

INSERT INTO Class
(Name, Trainer_ID)
VALUES
('Morning Cardio', 1),
('Yoga Flow', 2),
('Strength Basics', 3);

CREATE TABLE Class_Schedule (
    Class_ID INT NOT NULL,
    Day VARCHAR(20) NOT NULL CHECK (Day IN 
    ('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday')),
    Time TIME NOT NULL,
    PRIMARY KEY (Class_ID, Day, Time),
    FOREIGN KEY (Class_ID) REFERENCES Class(ID)
);

INSERT INTO Class_Schedule VALUES
(1, 'Monday', '08:00:00'),
(2, 'Wednesday', '17:00:00'),
(3, 'Friday', '09:00:00');

CREATE TABLE Equipment (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Purchase_Date DATE,
    Maintainance_Duration INT CHECK (Maintainance_Duration > 0)
);

INSERT INTO Equipment
(Name, Purchase_Date, Maintainance_Duration)
VALUES
('Treadmill', '2024-01-10', 90),
('Yoga Mat', '2024-03-15', 180),
('Barbell Set', '2023-11-20', 120);

CREATE TABLE Offers (
    Branch_ID INT NOT NULL,
    Class_ID INT NOT NULL,
    PRIMARY KEY (Branch_ID, Class_ID),
    FOREIGN KEY (Branch_ID) REFERENCES Branch_Manager(Branch_ID),
    FOREIGN KEY (Class_ID) REFERENCES Class(ID)
);

INSERT INTO Offers VALUES
(1, 1),
(2, 2),
(3, 3);