﻿-- ======================
-- Create the different Tables
-- ======================

USE DB_SnackAPP
GO

-- Create Table users

CREATE TABLE users(
	userID int IDENTITY(1,1) PRIMARY KEY,
	user_name varchar(255),
	email varchar(255),
	password varchar(255),
	salt int,
	verified bit,
	is_admin bit,
	language varchar(255)
);
GO

-- Create Table Items

CREATE TABLE items(
	itemID int IDENTITY(1,1) PRIMARY KEY,
	item_name varchar(255),
	item_path varchar(255)
);
GO

-- Create Table user_items

CREATE TABLE user_items(
	user_itemsID int IDENTITY(1,1) PRIMARY KEY,
	fk_userID int NOT NULL,
	fk_itemID int NOT NULL,
	numberOfItems int,
	FOREIGN KEY (fk_userID) REFERENCES users(userID),
	FOREIGN KEY (fk_itemID) REFERENCES items(itemID)
);
GO