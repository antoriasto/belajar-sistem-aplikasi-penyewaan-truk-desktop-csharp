-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.38 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for truck_db
DROP DATABASE IF EXISTS `truck_db`;
CREATE DATABASE IF NOT EXISTS `truck_db` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `truck_db`;


-- Dumping structure for table truck_db.customer
DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `CUSTOMER_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_CUSTOMER` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_CUSTOMER` varchar(155) NOT NULL,
  `TELEPON_CUSTOMER` varchar(15) NOT NULL,
  PRIMARY KEY (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.harga_truk_rute
DROP TABLE IF EXISTS `harga_truk_rute`;
CREATE TABLE IF NOT EXISTS `harga_truk_rute` (
  `HARGA_TRUK_RUTE_ID` varchar(15) NOT NULL DEFAULT '',
  `RUTE_ID` varchar(15) NOT NULL,
  `TRUK_ID` varchar(15) NOT NULL,
  `HARGA` decimal(17,0) DEFAULT NULL,
  `HARGA_SUPIR` decimal(17,0) DEFAULT NULL,
  PRIMARY KEY (`HARGA_TRUK_RUTE_ID`),
  KEY `RUTE_ID` (`RUTE_ID`),
  KEY `TRUK_ID` (`TRUK_ID`),
  CONSTRAINT `truk_rute` FOREIGN KEY (`RUTE_ID`) REFERENCES `rute` (`RUTE_ID`),
  CONSTRAINT `truk_rute2` FOREIGN KEY (`TRUK_ID`) REFERENCES `truk` (`TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.invoice
DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `INVOICE_ID` varchar(15) NOT NULL,
  `TANGGAL_INVOICE` date NOT NULL DEFAULT '0000-00-00',
  `SURAT_JALAN_ID` varchar(15) NOT NULL,
  PRIMARY KEY (`INVOICE_ID`),
  KEY `SURAT_JALAN_ID` (`SURAT_JALAN_ID`),
  CONSTRAINT `invoice_ibfk_1` FOREIGN KEY (`SURAT_JALAN_ID`) REFERENCES `surat_jalan` (`SURAT_JALAN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.jenis_truk
DROP TABLE IF EXISTS `jenis_truk`;
CREATE TABLE IF NOT EXISTS `jenis_truk` (
  `JENIS_TRUK_ID` varchar(5) NOT NULL DEFAULT '',
  `NAMA_JENIS_TRUK` varchar(55) NOT NULL DEFAULT '',
  `KUBIKASI` int(5) NOT NULL,
  `TONASE` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`JENIS_TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.kernet
DROP TABLE IF EXISTS `kernet`;
CREATE TABLE IF NOT EXISTS `kernet` (
  `KERNET_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_KERNET` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_KERNET` varchar(100) DEFAULT NULL,
  `NOMOR_HP_KERNET` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`KERNET_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.kwitansi_supir
DROP TABLE IF EXISTS `kwitansi_supir`;
CREATE TABLE IF NOT EXISTS `kwitansi_supir` (
  `KWITANSI_SUPIR_ID` varchar(15) NOT NULL DEFAULT '',
  `SEWA_ID` varchar(15) NOT NULL,
  `TANGGAL_KWITANSI_SUPIR` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`KWITANSI_SUPIR_ID`),
  KEY `SEWA_ID` (`SEWA_ID`),
  CONSTRAINT `kwitansi_supir` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.rute
DROP TABLE IF EXISTS `rute`;
CREATE TABLE IF NOT EXISTS `rute` (
  `RUTE_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_RUTE` varchar(55) NOT NULL DEFAULT '',
  PRIMARY KEY (`RUTE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.sewa
DROP TABLE IF EXISTS `sewa`;
CREATE TABLE IF NOT EXISTS `sewa` (
  `SEWA_ID` varchar(15) NOT NULL DEFAULT '',
  `TANGGAL_SEWA` date NOT NULL,
  `HARGA_TOTAL` decimal(11,0) NOT NULL,
  `CUSTOMER_ID` varchar(15) NOT NULL DEFAULT '0',
  `HARGA_TOTAL_SUPIR` decimal(11,0) NOT NULL DEFAULT '0',
  PRIMARY KEY (`SEWA_ID`),
  KEY `CUSTOMER_ID` (`CUSTOMER_ID`),
  CONSTRAINT `sewa` FOREIGN KEY (`CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.sewa_detail
DROP TABLE IF EXISTS `sewa_detail`;
CREATE TABLE IF NOT EXISTS `sewa_detail` (
  `SEWA_ID` varchar(15) NOT NULL DEFAULT '0',
  `HARGA` decimal(11,0) NOT NULL,
  `HARGA_TRUK_RUTE_ID` varchar(15) NOT NULL DEFAULT '0',
  `NO_REF_DN` varchar(255) NOT NULL,
  `HARGA_SUPIR` decimal(11,0) NOT NULL DEFAULT '0',
  KEY `SEWA_ID` (`SEWA_ID`),
  KEY `HARGA_TRUK_RUTE_ID` (`HARGA_TRUK_RUTE_ID`),
  CONSTRAINT `sewa_detail` FOREIGN KEY (`HARGA_TRUK_RUTE_ID`) REFERENCES `harga_truk_rute` (`HARGA_TRUK_RUTE_ID`),
  CONSTRAINT `sewa_detail2` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.supir
DROP TABLE IF EXISTS `supir`;
CREATE TABLE IF NOT EXISTS `supir` (
  `SUPIR_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_SUPIR` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_SUPIR` varchar(100) DEFAULT NULL,
  `NOMOR_HP_SUPIR` varchar(15) DEFAULT NULL,
  `KERNET_ID` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`SUPIR_ID`),
  KEY `KERNET_ID` (`KERNET_ID`),
  CONSTRAINT `supir` FOREIGN KEY (`KERNET_ID`) REFERENCES `kernet` (`KERNET_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.surat_jalan
DROP TABLE IF EXISTS `surat_jalan`;
CREATE TABLE IF NOT EXISTS `surat_jalan` (
  `SURAT_JALAN_ID` varchar(15) NOT NULL,
  `TANGGAL_SURAT_JALAN` date NOT NULL DEFAULT '0000-00-00',
  `SEWA_ID` varchar(15) NOT NULL,
  PRIMARY KEY (`SURAT_JALAN_ID`),
  KEY `SEWA_ID` (`SEWA_ID`),
  CONSTRAINT `surat_jalan_ibfk_1` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.


-- Dumping structure for table truck_db.truk
DROP TABLE IF EXISTS `truk`;
CREATE TABLE IF NOT EXISTS `truk` (
  `TRUK_ID` varchar(15) NOT NULL DEFAULT '',
  `NOMOR_POLISI` varchar(55) NOT NULL,
  `SUPIR_ID` varchar(15) DEFAULT '',
  `JENIS_TRUK_ID` varchar(15) DEFAULT '',
  `STATUS` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`TRUK_ID`),
  KEY `JENIS_TRUK_ID` (`JENIS_TRUK_ID`),
  KEY `SUPIR_ID` (`SUPIR_ID`),
  CONSTRAINT `truk` FOREIGN KEY (`SUPIR_ID`) REFERENCES `supir` (`SUPIR_ID`),
  CONSTRAINT `truk2` FOREIGN KEY (`JENIS_TRUK_ID`) REFERENCES `jenis_truk` (`JENIS_TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
