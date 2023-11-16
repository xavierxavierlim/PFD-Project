/* CREATE DATABASE PFD_DATABASE_GROUP_C; */

/* DROP DATABASE PFD_DATABASE_GROUP_C; */

/*
CREATE TABLE Users (
	UserID int NOT NULL PRIMARY KEY,
	AccountNo varchar(255) NOT NULL,
    Name varchar(255) NOT NULL,
	Pin char(6) NOT NULL,
	Balance money NOT NULL,
);

CREATE TABLE Feedback (
	FeedbackID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Rating int CHECK(Rating >= 1 AND Rating <= 5),
	Description varchar(255),
	UserID int NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Transactions (
	TransactionID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserID int NOT NULL,
	TransactionType varchar(10) NOT NULL,
	Amount money NOT NULL,
	TransactionDate datetime NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Users 
VALUES (1, '123456789012', 'Xavier', '123456', 500);

INSERT INTO Users
VALUES (2, '777777777777', 'Jia Dong', '777777', 777);
*/