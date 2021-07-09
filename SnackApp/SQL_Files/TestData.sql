-- ======================
-- Insert Test Data
-- ======================

USE DB_SnackAPP
GO

-- ======================
-- Insert user1 with password 12345 into users Table
-- Insert admin with password admin into users Table
-- ======================

SET IDENTITY_INSERT users OFF; 
INSERT INTO users(user_name, email, password, verified, is_admin, salt, language) VALUES 
('user1', 'user1@user1.com', '57d741d9725916ee63d154201462334e668578232d5b92f1e7539af0b53dad9e', '1', 0, 634, 'en-US'),
('admin', 'admin@unisg.ch', 'd55d43c3d38d527d5935079ba7b7b5425b67e134aae6296999137fc1ce1513ae', 1, 1, 992, 'en-US');
GO

-- ======================
-- Insert Snack coffee into table items
-- Insert Snack water into table items
-- ======================

SET IDENTITY_INSERT items OFF; 
INSERT INTO items(item_name, item_path) VALUES 
('coffee', '~\item_images\coffee.jpg'),
('water', '~\item_images\water.jpg');
GO

-- ======================
-- Insert relationship user_items for user1
-- ======================

SET IDENTITY_INSERT user_items OFF; 
INSERT INTO user_items(fk_userID, fk_itemID, numberOfItems) VALUES 
(1, 1, 0),
(1, 2, 0);
GO
