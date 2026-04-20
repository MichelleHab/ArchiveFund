-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: ArchiveFund
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `ArchiveFund`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `ArchiveFund` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `ArchiveFund`;

--
-- Table structure for table `Boxes`
--

DROP TABLE IF EXISTS `Boxes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Boxes` (
  `box_id` int NOT NULL AUTO_INCREMENT,
  `box_name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL COMMENT 'имя(А10,АБ17,Н1...)',
  `rack_number` int DEFAULT NULL COMMENT 'номер стеллажа',
  `shelf_number` int DEFAULT NULL COMMENT 'номер полки',
  `group_id` int DEFAULT NULL,
  `type_id` int NOT NULL,
  `year_work` date DEFAULT NULL COMMENT 'год работы',
  PRIMARY KEY (`box_id`),
  UNIQUE KEY `box_name` (`box_name`),
  KEY `boxes_ibfk_1` (`group_id`) USING BTREE,
  KEY `boxes_ibfk_2` (`type_id`) USING BTREE,
  CONSTRAINT `boxes_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `Group` (`group_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `boxes_ibfk_2` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `DeletedDocuments`
--

DROP TABLE IF EXISTS `DeletedDocuments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DeletedDocuments` (
  `doc_id` int NOT NULL AUTO_INCREMENT,
  `document_subject` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL COMMENT 'Тема',
  `start_data` date NOT NULL,
  `type_id` int NOT NULL,
  `Supervisor_full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL COMMENT 'Полное имя руководителя',
  `student_id` int DEFAULT NULL,
  `box_id` int DEFAULT NULL,
  PRIMARY KEY (`doc_id`) USING BTREE,
  KEY `deleteddocuments_ibfk_1` (`student_id`) USING BTREE,
  KEY `deleteddocuments_ibfk_2` (`type_id`) USING BTREE,
  KEY `deleteddocuments_ibfk_3` (`box_id`),
  CONSTRAINT `deleteddocuments_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `deleteddocuments_ibfk_2` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `deleteddocuments_ibfk_3` FOREIGN KEY (`box_id`) REFERENCES `Boxes` (`box_id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `DeletedStudentsPersFiles`
--

DROP TABLE IF EXISTS `DeletedStudentsPersFiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DeletedStudentsPersFiles` (
  `pers_file_id` int NOT NULL AUTO_INCREMENT,
  `deduction_year` date DEFAULT NULL COMMENT 'год вычета',
  `reason` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL COMMENT 'причина вычета',
  `admission_year` date NOT NULL COMMENT 'год поступления',
  `student_id` int NOT NULL,
  PRIMARY KEY (`pers_file_id`) USING BTREE,
  KEY `deletedstudentspersfiles_ibfk_1` (`student_id`) USING BTREE,
  CONSTRAINT `deletedstudentspersfiles_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Documents`
--

DROP TABLE IF EXISTS `Documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Documents` (
  `doc_id` int NOT NULL AUTO_INCREMENT,
  `document_subject` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL COMMENT 'Тема',
  `start_data` date NOT NULL,
  `type_id` int NOT NULL,
  `Supervisor_full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL COMMENT 'Полное имя руководителя',
  `student_id` int DEFAULT NULL,
  `box_id` int DEFAULT NULL,
  PRIMARY KEY (`doc_id`),
  KEY `documents_ibfk_1` (`type_id`) USING BTREE,
  KEY `documents_ibfk_2` (`student_id`) USING BTREE,
  KEY `documents_ibfk_3` (`box_id`),
  CONSTRAINT `documents_ibfk_1` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `documents_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `documents_ibfk_3` FOREIGN KEY (`box_id`) REFERENCES `Boxes` (`box_id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `DocumentTypes`
--

DROP TABLE IF EXISTS `DocumentTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DocumentTypes` (
  `type_id` int NOT NULL AUTO_INCREMENT,
  `type_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`type_id`),
  UNIQUE KEY `type_name` (`type_name`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Group`
--

DROP TABLE IF EXISTS `Group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Group` (
  `group_id` int NOT NULL AUTO_INCREMENT,
  `group_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `formation_year` date NOT NULL COMMENT 'год создания',
  `specialization` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL COMMENT 'специальность',
  PRIMARY KEY (`group_id`),
  UNIQUE KEY `group_name` (`group_name`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Student`
--

DROP TABLE IF EXISTS `Student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Student` (
  `student_id` int NOT NULL AUTO_INCREMENT,
  `full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `group_id` int DEFAULT NULL,
  PRIMARY KEY (`student_id`),
  KEY `student_ibfk_1` (`group_id`),
  CONSTRAINT `student_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `Group` (`group_id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `StudentsPersFiles`
--

DROP TABLE IF EXISTS `StudentsPersFiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StudentsPersFiles` (
  `pers_file_id` int NOT NULL AUTO_INCREMENT,
  `deduction_year` date DEFAULT NULL COMMENT 'год вычета',
  `reason` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL COMMENT 'причина вычета',
  `admission_year` date NOT NULL COMMENT 'год поступления',
  `student_id` int NOT NULL,
  PRIMARY KEY (`pers_file_id`),
  KEY `studentspersfiles_ibfk_1` (`student_id`),
  CONSTRAINT `studentspersfiles_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `User` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `FIO` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `role` enum('Admin','Employer') CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `login` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_vi_0900_as_cs NOT NULL DEFAULT '',
  `password` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`user_id`) USING BTREE,
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

insert into `User`(`user_id`, `FIO`, `role`, `login`, `password`) values (-1, 'Админ', 'Admin', 'Admin', '887375daec62a9f02d32a63c9e14c7641a9a8a42e4fa8f6590eb928d9744b57bb5057a1d227e4d40ef911ac030590bbce2bfdb78103ff0b79094cee8425601f5');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-11 18:36:52
