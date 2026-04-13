SET @db = 'db_stud';
SET @User = 'root@%';
SET @TABLES1 = 'groups, students, users';
SELECT @User IN (SELECT DISTINCT CONCAT(`USER`, '@', `HOST`) FROM `mysql`.`user`) AS 'does such a user exist',
@db IN (SELECT DISTINCT TABLE_SCHEMA FROM information_schema.TABLES) AS 'does such a database exist',
@TABLES1 = (select GROUP_CONCAT(DISTINCT `TABLE_NAME` SEPARATOR ', ') FROM information_schema.TABLES WHERE `TABLE_SCHEMA`
= @db) AS 'does this table structure exist';