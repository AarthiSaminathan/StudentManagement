-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.20-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table aarthi.cities
DROP TABLE IF EXISTS `cities`;
CREATE TABLE IF NOT EXISTS `cities` (
  `Id` int(11) NOT NULL,
  `city` longtext NOT NULL,
  `city_ascii` longtext NOT NULL,
  `lat` longtext NOT NULL,
  `lng` longtext NOT NULL,
  `country` longtext NOT NULL,
  `iso2` longtext NOT NULL,
  `iso3` longtext NOT NULL,
  `admin_name` longtext NOT NULL,
  `capital` longtext NOT NULL,
  `population` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aarthi.cities: ~8 rows (approximately)
INSERT INTO `cities` (`Id`, `city`, `city_ascii`, `lat`, `lng`, `country`, `iso2`, `iso3`, `admin_name`, `capital`, `population`) VALUES
	(1076532519, 'São Paulo', 'Sao Paulo', '-23.5500', '-46.6333', 'Brazil', 'BR', 'BRA', 'São Paulo', 'admin', '23086000'),
	(1156073548, 'Shanghai', 'Shanghai', '31.1667', '121.4667', 'China', 'CN', 'CHN', 'Shanghai', 'admin', '24073000'),
	(1156237133, 'Guangzhou', 'Guangzhou', '23.1300', '113.2600', 'China', 'CN', 'CHN', 'Guangdong', 'admin', '26940000'),
	(1356226629, 'Mumbai', 'Mumbai', '19.0761', '72.8775', 'India', 'IN', 'IND', 'Maharashtra', 'admin', '24973000'),
	(1356872604, 'Delhi', 'Delhi', '28.6100', '77.2300', 'India', 'IN', 'IND', 'Delhi', 'admin', '32226000'),
	(1360771077, 'Jakarta', 'Jakarta', '-6.1750', '106.8275', 'Indonesia', 'ID', 'IDN', 'Jakarta', 'primary', '33756000'),
	(1392685764, 'Tokyo', 'Tokyo', '35.6897', '139.6922', 'Japan', 'JP', 'JPN', 'Tokyo', 'primary', '37732000'),
	(1608618140, 'Manila', 'Manila', '14.5958', '120.9772', 'Philippines', 'PH', 'PHL', 'Manila', 'primary', '24922000');

-- Dumping structure for table aarthi.marks
DROP TABLE IF EXISTS `marks`;
CREATE TABLE IF NOT EXISTS `marks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StudentId` int(11) NOT NULL,
  `TermId` int(11) NOT NULL,
  `Tamil` int(11) NOT NULL,
  `English` int(11) NOT NULL,
  `Maths` int(11) NOT NULL,
  `Physics` int(11) NOT NULL,
  `Chemistry` int(11) NOT NULL,
  `ComputerScience` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Marks_StudentId` (`StudentId`),
  KEY `IX_Marks_TermId` (`TermId`),
  CONSTRAINT `FK_Marks_Students_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `students` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Marks_Terms_TermId` FOREIGN KEY (`TermId`) REFERENCES `terms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Dumping data for table aarthi.marks: ~12 rows (approximately)
INSERT INTO `marks` (`Id`, `StudentId`, `TermId`, `Tamil`, `English`, `Maths`, `Physics`, `Chemistry`, `ComputerScience`) VALUES
	(1, 1, 1, 85, 80, 89, 90, 88, 82),
	(2, 1, 2, 89, 82, 83, 90, 85, 82),
	(3, 1, 3, 68, 65, 60, 67, 70, 72),
	(4, 1, 4, 75, 78, 80, 77, 76, 70),
	(5, 1, 5, 90, 85, 80, 82, 84, 86),
	(6, 1, 6, 95, 95, 92, 86, 89, 98),
	(7, 2, 1, 89, 80, 82, 82, 84, 81),
	(8, 2, 2, 70, 69, 72, 71, 74, 68),
	(9, 2, 3, 68, 56, 72, 60, 67, 65),
	(10, 2, 4, 68, 56, 72, 60, 67, 65),
	(11, 2, 5, 58, 56, 50, 53, 49, 65),
	(12, 2, 6, 89, 80, 90, 82, 86, 90);

-- Dumping structure for table aarthi.students
DROP TABLE IF EXISTS `students`;
CREATE TABLE IF NOT EXISTS `students` (
  `Id` int(11) NOT NULL,
  `RollNo` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Standard` int(11) NOT NULL,
  `AcademicYear` int(11) NOT NULL,
  `Gender` char(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RollNo` (`RollNo`)
) ENGINE=InnoDB AUTO_INCREMENT=6004 DEFAULT CHARSET=latin1;

-- Dumping data for table aarthi.students: ~2 rows (approximately)
INSERT INTO `students` (`Id`, `RollNo`, `Name`, `Standard`, `AcademicYear`, `Gender`) VALUES
	(1, 6001, 'Aarthi.S', 12, 2023, 'F'),
	(2, 6003, 'Ravi', 12, 2023, 'M');

-- Dumping structure for table aarthi.terms
DROP TABLE IF EXISTS `terms`;
CREATE TABLE IF NOT EXISTS `terms` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TermName` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table aarthi.terms: ~6 rows (approximately)
INSERT INTO `terms` (`Id`, `TermName`) VALUES
	(1, '1st Mid Term'),
	(2, 'Quarterly'),
	(3, '2nd Mid Tmer'),
	(4, 'Half-yearly'),
	(5, '3rd Mid Term'),
	(6, 'Annual');

-- Dumping structure for table aarthi.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aarthi.__efmigrationshistory: ~84 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20230403053245_MyFirstMigration', '6.0.15'),
	('20230403073335_MyFirstMigration', '6.0.15'),
	('20230404045335_MyFirstMigration', '6.0.15'),
	('20230404050227_MyFirstMigration', '6.0.15'),
	('20230404050818_MyFirstMigration', '6.0.15'),
	('20230404072339_MyFirstMigration', '6.0.15'),
	('20230404093622_MyFirstMigration', '6.0.15'),
	('20230404095446_MyFirstMigration', '6.0.15'),
	('20230410052948_MyFirstMigration', '6.0.15'),
	('20230410053204_MyFirstMigration', '6.0.15'),
	('20230410072350_MyFirstMigration', '6.0.15'),
	('20230410091629_MyFirstMigration', '6.0.15'),
	('20230410122016_MyFirstMigration', '6.0.15'),
	('20230411051207_MyFirstMigration', '6.0.15'),
	('20230411052714_MyFirstMigration', '6.0.15'),
	('20230411063634_MyFirstMigration', '6.0.15'),
	('20230411063920_MyFirstMigration', '6.0.15'),
	('20230411065828_MyFirstMigration', '6.0.15'),
	('20230411070348_MyFirstMigration', '6.0.15'),
	('20230411072644_MyFirstMigration', '6.0.15'),
	('20230411072932_MyFirstMigration', '6.0.15'),
	('20230411092801_MyFirstMigration', '6.0.15'),
	('20230411100314_MyFirstMigration', '6.0.15'),
	('20230411100801_MyFirstMigration', '6.0.15'),
	('20230411113340_MyFirstMigration', '6.0.15'),
	('20230411113621_MyFirstMigration', '6.0.15'),
	('20230411113810_MyFirstMigration', '6.0.15'),
	('20230411114852_MyFirstMigration', '6.0.15'),
	('20230411120515_MyFirstMigration', '6.0.15'),
	('20230411121243_MyFirstMigration', '6.0.15'),
	('20230411122046_MyFirstMigration', '6.0.15'),
	('20230411123015_MyFirstMigration', '6.0.15'),
	('20230411153505_MyFirstMigration', '6.0.15'),
	('20230411155015_MyFirstMigration', '6.0.15'),
	('20230411155421_MyFirstMigration', '6.0.15'),
	('20230411155952_MyFirstMigration', '6.0.15'),
	('20230412040523_MyFirstMigration', '6.0.15'),
	('20230412051357_MyFirstMigration', '6.0.15'),
	('20230412062523_MyFirstMigration', '6.0.15'),
	('20230412100045_MyFirstMigration', '6.0.15'),
	('20230412101338_MyFirstMigration', '6.0.15'),
	('20230412104738_MyFirstMigration', '6.0.15'),
	('20230412110727_MyFirstMigration', '6.0.15'),
	('20230412112648_MyFirstMigration', '6.0.15'),
	('20230412112942_MyFirstMigration', '6.0.15'),
	('20230412113110_MyFirstMigration', '6.0.15'),
	('20230412120316_MyFirstMigration', '6.0.15'),
	('20230412120600_MyFirstMigration', '6.0.15'),
	('20230412172508_MyFirstMigration', '6.0.15'),
	('20230412175503_MyFirstMigration', '6.0.15'),
	('20230412175903_MyFirstMigration', '6.0.15'),
	('20230412180055_MyFirstMigration', '6.0.15'),
	('20230412180309_MyFirstMigration', '6.0.15'),
	('20230412183559_MyFirstMigration', '6.0.15'),
	('20230412191557_MyFirstMigration', '6.0.15'),
	('20230420112233_MyFirstMigration', '6.0.16'),
	('20230421041918_MyFirstMigration', '6.0.16'),
	('20230421043231_MyFirstMigration', '6.0.16'),
	('20230421111044_MyFirstMigration', '6.0.15'),
	('20230428081218_MyFirstMigration', '6.0.15'),
	('20230428082036_MyFirstMigration', '6.0.15'),
	('20230428085411_MyFirstMigration', '6.0.15'),
	('20230428102506_MyFirstMigration', '6.0.15'),
	('20230502045344_MyFirstMigration', '6.0.15'),
	('20230502050518_MyFirstMigration', '6.0.15'),
	('20230502073052_MyFirstMigration', '6.0.15'),
	('20230502084829_MyFirstMigration', '6.0.15'),
	('20230502093047_MyFirstMigration', '6.0.15'),
	('20230502102944_MyFirstMigration', '6.0.15'),
	('20230502162401_MyFirstMigration', '6.0.15'),
	('20230502173618_MyFirstMigration', '6.0.15'),
	('20230503053030_MyFirstMigration', '6.0.15'),
	('20230503053623_MyFirstMigration', '6.0.15'),
	('20230503070114_MyFirstMigration', '6.0.15'),
	('20230503070725_MyFirstMigration', '6.0.15'),
	('20230503071053_MyFirstMigration', '6.0.15'),
	('20230503071809_MyFirstMigration', '6.0.15'),
	('20230504085339_MyFirstMigration', '6.0.15'),
	('20230504085919_MyFirstMigration', '6.0.15'),
	('20230505043110_MyFirstMigration', '6.0.15'),
	('20230505045504_MyFirstMigration', '6.0.15'),
	('20230505050423_MyFirstMigration', '6.0.15'),
	('20230505052006_MyFirstMigration', '6.0.15'),
	('20230505052531_MyFirstMigration', '6.0.15');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
