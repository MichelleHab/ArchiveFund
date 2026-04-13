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
  `box_id` int NOT NULL,
  `rack_number` int DEFAULT NULL,
  `shelf_number` int DEFAULT NULL,
  `group_id` int NOT NULL,
  `type_id` int NOT NULL,
  `year_work` date DEFAULT NULL,
  PRIMARY KEY (`box_id`),
  KEY `boxes_ibfk_3` (`group_id`),
  KEY `boxes_ibfk_4` (`type_id`),
  CONSTRAINT `boxes_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `Group` (`group_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `boxes_ibfk_2` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `boxes_ibfk_3` FOREIGN KEY (`group_id`) REFERENCES `Group` (`group_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `boxes_ibfk_4` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Boxes`
--

LOCK TABLES `Boxes` WRITE;
/*!40000 ALTER TABLE `Boxes` DISABLE KEYS */;
INSERT INTO `Boxes` VALUES (1,1,1,1,1,'2024-06-15'),(2,1,2,2,2,'2024-06-20'),(3,1,3,3,3,'2024-07-01'),(4,2,1,4,1,'2024-07-10'),(5,2,2,5,1,'2024-07-15'),(6,2,3,6,2,'2024-08-01'),(7,3,1,7,3,'2024-08-10'),(8,3,2,8,1,'2024-08-20'),(9,3,3,9,1,'2024-09-01');
/*!40000 ALTER TABLE `Boxes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DeletedDocuments`
--

DROP TABLE IF EXISTS `DeletedDocuments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DeletedDocuments` (
  `deleted_doc_id` int NOT NULL,
  `deleted_document_subject` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `deleted_doc_Supervisor_full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `student_id` int NOT NULL,
  `type_id` int NOT NULL,
  PRIMARY KEY (`deleted_doc_id`),
  KEY `deleteddocuments_ibfk_3` (`student_id`),
  KEY `deleteddocuments_ibfk_4` (`type_id`),
  CONSTRAINT `deleteddocuments_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `deleteddocuments_ibfk_2` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `deleteddocuments_ibfk_3` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `deleteddocuments_ibfk_4` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DeletedDocuments`
--

LOCK TABLES `DeletedDocuments` WRITE;
/*!40000 ALTER TABLE `DeletedDocuments` DISABLE KEYS */;
INSERT INTO `DeletedDocuments` VALUES (1,'Старая версия диплома','Скрыльников Дмитрий Константинович',1,1),(2,'курсовая 1','Нуралиева Ирина Евгеньевна',2,1),(3,'Предварительный отчет','Федусева Элла Юрьевна',3,2),(4,'Неактуальный реферат','Нуралиев Арсен Абдулжалилович',4,2),(5,'Дубликат диплома','Стрельцова Анна Федоровна',5,2),(6,'Устаревшая статья н11','Ермольчев Константин Васильевич',6,3),(7,'Отклоненный патент','Кирюхина Оксана Юрьевна',7,2),(8,'свидетельство о рождения','Дудник Наталья Борисовна',8,1),(9,'Просроченный сертификат','Попова Вероника Владимировна',9,1);
/*!40000 ALTER TABLE `DeletedDocuments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DeletedStudentsPersFiles`
--

DROP TABLE IF EXISTS `DeletedStudentsPersFiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DeletedStudentsPersFiles` (
  `deleted_pers_file_id` int NOT NULL,
  `deduction_year` date DEFAULT NULL,
  `reason` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `admission_year` date DEFAULT NULL,
  `student_id` int NOT NULL,
  PRIMARY KEY (`deleted_pers_file_id`),
  KEY `deletedstudentspersfiles_ibfk_2` (`student_id`),
  CONSTRAINT `deletedstudentspersfiles_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `deletedstudentspersfiles_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DeletedStudentsPersFiles`
--

LOCK TABLES `DeletedStudentsPersFiles` WRITE;
/*!40000 ALTER TABLE `DeletedStudentsPersFiles` DISABLE KEYS */;
INSERT INTO `DeletedStudentsPersFiles` VALUES (1,'2022-06-30','Отчисление','2020-09-01',1),(2,'2023-06-30','Перевод','2021-09-01',2),(3,'2022-12-30','Академический','2020-09-01',3),(4,'2023-06-30','Окончание','2019-09-01',4),(5,'2023-01-15','Отчисление','2021-09-01',5),(6,'2023-06-30','Окончание','2020-09-01',6),(7,'2022-09-01','Перевод','2019-09-01',7),(8,'2023-06-30','Окончание','2021-09-01',8),(9,'2023-02-28','Академический','2020-09-01',9);
/*!40000 ALTER TABLE `DeletedStudentsPersFiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Documents`
--

DROP TABLE IF EXISTS `Documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Documents` (
  `doc_id` int NOT NULL,
  `document_subject` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `type_id` int NOT NULL,
  `Supervisor_full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `student_id` int DEFAULT NULL,
  PRIMARY KEY (`doc_id`),
  KEY `documents_ibfk_3` (`type_id`),
  KEY `documents_ibfk_4` (`student_id`),
  CONSTRAINT `documents_ibfk_1` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `documents_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `documents_ibfk_3` FOREIGN KEY (`type_id`) REFERENCES `DocumentTypes` (`type_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `documents_ibfk_4` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Documents`
--

LOCK TABLES `Documents` WRITE;
/*!40000 ALTER TABLE `Documents` DISABLE KEYS */;
INSERT INTO `Documents` VALUES (1,'Разработка веб-приложения',1,'Скрыльников Дмитрий Константинович',1),(2,'Анализ алгоритмов',2,'Нуралиева Ирина Евгеньевна',2),(3,'Отчет ООО \"Техно\"',3,'Федусева Элла Юрьевна',3),(4,'История права',1,'Нуралиев Арсен Абдулжалилович',4),(5,'Машинное обучение',1,'Стрельцова Анна Федоровна',5),(6,'Квантовая физика',2,'Ермольчев Константин Васильевич',6),(7,'Органический синтез',2,'Кирюхина Оксана Юрьевна',7),(8,'Генетика человека',3,'Дудник Наталья Борисовна',8),(9,'Археология Гуси',2,'Попова Вероника Владимировна',9);
/*!40000 ALTER TABLE `Documents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DocumentTypes`
--

DROP TABLE IF EXISTS `DocumentTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DocumentTypes` (
  `type_id` int NOT NULL,
  `type_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DocumentTypes`
--

LOCK TABLES `DocumentTypes` WRITE;
/*!40000 ALTER TABLE `DocumentTypes` DISABLE KEYS */;
INSERT INTO `DocumentTypes` VALUES (1,'Дипломная работа'),(2,'Курсовая работа'),(3,'Отчет по практике');
/*!40000 ALTER TABLE `DocumentTypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Group`
--

DROP TABLE IF EXISTS `Group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Group` (
  `group_id` int NOT NULL,
  `group_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `formation_year` date DEFAULT NULL,
  `specialization` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`group_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Group`
--

LOCK TABLES `Group` WRITE;
/*!40000 ALTER TABLE `Group` DISABLE KEYS */;
INSERT INTO `Group` VALUES (1,'ИП3','2023-09-01','09.02.07 Информационные системы и программирование (квалификация: программист)'),(2,'ИС3-Б','2023-09-01','09.02.07 Информационные системы и программирование (квалификация: разработчик веб и мультимедийных приложений)'),(3,'Ф3-А','2023-09-01','33.02.01 Фармация (на базе 9 классов)'),(4,'Ф3-Б','2023-09-01','33.02.07 Фармация (на базе 11 классов)'),(5,'Э3','2023-09-01','38.02.01 Экономика и бухгалтерский учет (по отраслям)'),(6,'ПД3-Г','2023-09-01','40.02.02 Правоохранительная деятельность'),(7,'Т3-А','2023-09-01','43.02.13 Технология парикмахерского искусства'),(8,'Д3-В','2023-09-01','44.02.02 Дошкольное образование'),(9,'Н3-Д','2023-09-01','44.02.02 Преподавание в начальных классах');
/*!40000 ALTER TABLE `Group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Student`
--

DROP TABLE IF EXISTS `Student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Student` (
  `student_id` int NOT NULL,
  `full_name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `group_id` int NOT NULL,
  PRIMARY KEY (`student_id`),
  KEY `student_ibfk_1` (`group_id`),
  CONSTRAINT `student_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `Group` (`group_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Student`
--

LOCK TABLES `Student` WRITE;
/*!40000 ALTER TABLE `Student` DISABLE KEYS */;
INSERT INTO `Student` VALUES (1,'Иванов А.С.',1),(2,'Петров Б.В.',2),(3,'Сидорова Е.М.',3),(4,'Козлов Д.И.',4),(5,'Новикова О.П.',5),(6,'Смирнов К.Л.',6),(7,'Васильева Н.Т.',7),(8,'Морозов Р.Ю.',8),(9,'Лебедева Т.А.',9);
/*!40000 ALTER TABLE `Student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StudentsPersFiles`
--

DROP TABLE IF EXISTS `StudentsPersFiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StudentsPersFiles` (
  `pers_file_id` int NOT NULL,
  `deduction_year` date DEFAULT NULL,
  `reason` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `admission_year` date DEFAULT NULL,
  `student_id` int NOT NULL,
  PRIMARY KEY (`pers_file_id`),
  KEY `studentspersfiles_ibfk_1` (`student_id`),
  CONSTRAINT `studentspersfiles_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `Student` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StudentsPersFiles`
--

LOCK TABLES `StudentsPersFiles` WRITE;
/*!40000 ALTER TABLE `StudentsPersFiles` DISABLE KEYS */;
INSERT INTO `StudentsPersFiles` VALUES (1,NULL,NULL,'2024-09-01',1),(2,NULL,NULL,'2024-09-01',2),(3,NULL,NULL,'2024-09-01',3),(4,'2023-06-30','Окончание','2021-09-01',4),(5,NULL,NULL,'2024-09-01',5),(6,NULL,NULL,'2023-09-01',6),(7,'2023-06-30','Окончание','2021-09-01',7),(8,NULL,NULL,'2023-09-01',8),(9,NULL,NULL,'2023-09-01',9);
/*!40000 ALTER TABLE `StudentsPersFiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `User` (
  `id` int NOT NULL AUTO_INCREMENT,
  `FIO` varchar(150) CHARACTER SET armscii8 COLLATE armscii8_bin DEFAULT NULL,
  `role` enum('Admin','Employer') CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  `login` varchar(50) COLLATE armscii8_bin NOT NULL DEFAULT '',
  `password` varchar(50) COLLATE armscii8_bin NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `User`
--

LOCK TABLES `User` WRITE;
/*!40000 ALTER TABLE `User` DISABLE KEYS */;
/*!40000 ALTER TABLE `User` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-31  8:08:27
