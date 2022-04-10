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
('20220204121316_Tb_Pemeriksaan','5.0.13'),
('20220407190507_TabelBaru','5.0.13'),
('20220407190954_TabelAnti','5.0.13'),
('20220409200512_TabelTabel','5.0.13');

/*Table structure for table `tb_departemen` */

DROP TABLE IF EXISTS `tb_departemen`;

CREATE TABLE `tb_departemen` (
  `Id` varchar(767) NOT NULL,
  `NamaDep` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_departemen` */

insert  into `tb_departemen`(`Id`,`NamaDep`) values 
('DP-1','Jantung'),
('DP-2','Paru-Paru'),
('DP-3','Bedah'),
('DP-4','Umum');

/*Table structure for table `tb_dokter` */

DROP TABLE IF EXISTS `tb_dokter`;

CREATE TABLE `tb_dokter` (
  `Id` varchar(767) NOT NULL,
  `NamaD` text DEFAULT NULL,
  `Hp` text DEFAULT NULL,
  `Alamat` text DEFAULT NULL,
  `TempatD` text DEFAULT NULL,
  `TanggalD` datetime NOT NULL,
  `Image` text DEFAULT NULL,
  `Departemen` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_dokter` */

insert  into `tb_dokter`(`Id`,`NamaD`,`Hp`,`Alamat`,`TempatD`,`TanggalD`,`Image`,`Departemen`) values 
('DK-1','Kurnia','08562858597','Banyumas','Banyumas','2022-03-28 03:18:00','/namaFoldernya/twenty-five-twenty-one-episode-15-back-do.jpg','DP-2'),
('DK-2','Sitompul','08562858599','Bandung','Banyumas','2022-04-02 03:19:00','/namaFoldernya/600xauto-result-1032-photo.jpg','DP-3');

/*Table structure for table `tb_pasien` */

DROP TABLE IF EXISTS `tb_pasien`;

CREATE TABLE `tb_pasien` (
  `Id` varchar(767) NOT NULL,
  `NamaP` text DEFAULT NULL,
  `TempatL` text DEFAULT NULL,
  `TanggalL` datetime NOT NULL,
  `Alamat` text DEFAULT NULL,
  `NoHp` text DEFAULT NULL,
  `Image` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_pasien` */

insert  into `tb_pasien`(`Id`,`NamaP`,`TempatL`,`TanggalL`,`Alamat`,`NoHp`,`Image`) values 
('PS-1','Anti','Banyumas','2022-03-27 03:20:00','Banyumas','085289823481','/namaFoldernya/PXL_20220312_102519343.MP.jpg'),
('PS-2','Edwar','Sibolga','2022-03-31 03:20:00','Bandung','0885627615246','/namaFoldernya/PXL_20220312_112858318.MP.jpg');

/*Table structure for table `tb_rawatinap` */

DROP TABLE IF EXISTS `tb_rawatinap`;

CREATE TABLE `tb_rawatinap` (
  `Id` varchar(767) NOT NULL,
  `Pasien` text DEFAULT NULL,
  `Dokter` text DEFAULT NULL,
  `Departemen` text DEFAULT NULL,
  `Ruangan` text DEFAULT NULL,
  `BiayaInap` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_rawatinap` */

insert  into `tb_rawatinap`(`Id`,`Pasien`,`Dokter`,`Departemen`,`Ruangan`,`BiayaInap`) values 
('RN-1','PS-2','DK-2','D-3','IGD','300000');

/*Table structure for table `tb_rawatjalan` */

DROP TABLE IF EXISTS `tb_rawatjalan`;

CREATE TABLE `tb_rawatjalan` (
  `Id` varchar(767) NOT NULL,
  `Pasien` text DEFAULT NULL,
  `Dokter` text DEFAULT NULL,
  `Departemen` text DEFAULT NULL,
  `Biaya` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_rawatjalan` */

insert  into `tb_rawatjalan`(`Id`,`Pasien`,`Dokter`,`Departemen`,`Biaya`) values 
('RJ-1','PS-1','DK-1','DP-1','50000');

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
('Anti','nia','Zulianti Anti','kurniazul22@gmail.com','2'),
('Kurnia','zuli','Kurnia Zulianti','kurniazulianti22@gmail.com','1');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
