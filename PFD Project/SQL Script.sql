/* CREATE DATABASE PFD_DATABASE_GROUP_C; */

CREATE TABLE Users (
	UserID int NOT NULL PRIMARY KEY,
    Name varchar(255) NOT NULL,
	Pin char(6) NOT NULL,
	Balance money NOT NULL,
	Fingerprint image NOT NULL
);

CREATE TABLE Feedback (
	FeedbackID int NOT NULL PRIMARY KEY,
	Rating int CHECK(Rating >= 1 AND Rating <= 5),
	Description varchar(255),
	UserID int,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Transactions (
	TransactionID int NOT NULL PRIMARY KEY,
	UserID int NOT NULL,
	TransactionType varchar(10) NOT NULL,
	Amount money NOT NULL,
	TransactionDate datetime NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Users
SELECT 1, 'Xavier', '123456', 500, BulkColumn
FROM Openrowset ( Bulk 'C:\Users\xavie\OneDrive\Pictures\Camera Roll\WIN_20231102_15_21_04_Pro.jpg', Single_Blob) as img;

