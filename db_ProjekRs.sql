/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 10.4.21-MariaDB : Database - db_projekrs
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_projekrs` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_projekrs`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20220201172138_tb_dokter','5.0.13'),
('20220202040825_Tabel','5.0.13'),
('20220202082220_Tabel','5.0.13'),
('20220202123616_RumahSakit','5.0.13'),
('20220203074923_Tabel2','5.0.13'),
('20220204015128_TabelAnti','5.0.13'),
('20220204114523_Tb_Pemeriksaan','5.0.13'),
('20220204120138_Tb_Pemeriksaan','5.0.13'),
('20220204120754_Tb_Pemeriksaan','5.0.13'),
('20220204121316_Tb_Pemeriksaan','5.0.13');

/*Table structure for table `tb_dokter` */

DROP TABLE IF EXISTS `tb_dokter`;

CREATE TABLE `tb_dokter` (
  `Id` varchar(767) NOT NULL,
  `NamaD` text DEFAULT NULL,
  `Hp` text DEFAULT NULL,
  `Alamat` text DEFAULT NULL,
  `TanggalD` datetime NOT NULL,
  `Specialis` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_dokter` */

insert  into `tb_dokter`(`Id`,`NamaD`,`Hp`,`Alamat`,`TanggalD`,`Specialis`) values 
('DK-1','Kurnia','08562858599','Banyumas','2002-07-22 18:21:00','Saraf'),
('DK-2','Sitompul','08562858598','Bandung','2000-07-28 19:57:00','Jantung');

/*Table structure for table `tb_pasien` */

DROP TABLE IF EXISTS `tb_pasien`;

CREATE TABLE `tb_pasien` (
  `Id` varchar(767) NOT NULL,
  `NamaP` text DEFAULT NULL,
  `Jk` text DEFAULT NULL,
  `GolD` text DEFAULT NULL,
  `TempatL` text DEFAULT NULL,
  `TanggalL` datetime NOT NULL,
  `NamaIbu` text DEFAULT NULL,
  `StatusM` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_pasien` */

insert  into `tb_pasien`(`Id`,`NamaP`,`Jk`,`GolD`,`TempatL`,`TanggalL`,`NamaIbu`,`StatusM`) values 
('PS-1','Edwar','Laki-Laki','O','Sibolga','2001-08-18 18:09:00','Nisjuarni Bugis','Belum Menikah');

/*Table structure for table `tb_pemeriksaan` */

DROP TABLE IF EXISTS `tb_pemeriksaan`;

CREATE TABLE `tb_pemeriksaan` (
  `Id` varchar(767) NOT NULL,
  `TanggalB` datetime NOT NULL,
  `Keluhan` text DEFAULT NULL,
  `Diagnosis` text DEFAULT NULL,
  `Tindakan` text DEFAULT NULL,
  `PasienId` varchar(767) DEFAULT NULL,
  `DokterId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Tb_Pemeriksaan_DokterId` (`DokterId`),
  KEY `IX_Tb_Pemeriksaan_PasienId` (`PasienId`),
  CONSTRAINT `FK_Tb_Pemeriksaan_Tb_Dokter_DokterId` FOREIGN KEY (`DokterId`) REFERENCES `tb_dokter` (`Id`),
  CONSTRAINT `FK_Tb_Pemeriksaan_Tb_Pasien_PasienId` FOREIGN KEY (`PasienId`) REFERENCES `tb_pasien` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_pemeriksaan` */

insert  into `tb_pemeriksaan`(`Id`,`TanggalB`,`Keluhan`,`Diagnosis`,`Tindakan`,`PasienId`,`DokterId`) values 
('PM-1','2022-02-04 19:19:00','Batuk, Pusing','Demam','Obat','PS-1','DK-1');

/*Table structure for table `tb_roles` */

DROP TABLE IF EXISTS `tb_roles`;

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Name` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_roles` */

insert  into `tb_roles`(`Id`,`Name`) values 
('1','Admin'),
('2','User');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text NOT NULL,
  `Name` text NOT NULL,
  `Email` text NOT NULL,
  `RolesId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Username`),
  KEY `IX_Tb_User_RolesId` (`RolesId`),
  CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_user` */

insert  into `tb_user`(`Username`,`Password`,`Name`,`Email`,`RolesId`) values 
('anti','kurnia','Zulianti','kurnia22@gmail.com','1'),
('kurnia','zuli','Kurnia Zulianti','kurniazulianti22@gmail.com','2');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
