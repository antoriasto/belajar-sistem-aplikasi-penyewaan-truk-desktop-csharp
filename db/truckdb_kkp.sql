# Host: localhost  (Version: 5.1.30-community)
# Date: 2014-06-25 03:12:40
# Generator: MySQL-Front 5.3  (Build 4.113)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "customer"
#

DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer` (
  `CUSTOMER_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_CUSTOMER` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_CUSTOMER` varchar(155) NOT NULL,
  `TELEPON_CUSTOMER` varchar(15) NOT NULL,
  PRIMARY KEY (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "customer"
#


#
# Structure for table "jenis_truk"
#

DROP TABLE IF EXISTS `jenis_truk`;
CREATE TABLE `jenis_truk` (
  `JENIS_TRUK_ID` varchar(5) NOT NULL DEFAULT '',
  `NAMA_JENIS_TRUK` varchar(55) NOT NULL DEFAULT '',
  `KUBIKASI` int(5) NOT NULL,
  `TONASE` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`JENIS_TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "jenis_truk"
#

INSERT INTO `jenis_truk` VALUES ('J0001','Container',5,50.00),('J0002','Van',6,100.00),('J0003','Engkle',7,200.00),('J0004','Jumbo',8,300.00);

#
# Structure for table "kernet"
#

DROP TABLE IF EXISTS `kernet`;
CREATE TABLE `kernet` (
  `KERNET_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_KERNET` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_KERNET` varchar(100) DEFAULT NULL,
  `NOMOR_HP_KERNET` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`KERNET_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

#
# Data for table "kernet"
#

INSERT INTO `kernet` VALUES ('K0001','Fey','MAMPANG','0213'),('K0002','sad','MAMPANG','021'),('K0003','ROY','MAMPANG','02134'),('K0004','JON','MAMPANG','021345');

#
# Structure for table "rute"
#

DROP TABLE IF EXISTS `rute`;
CREATE TABLE `rute` (
  `RUTE_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_RUTE` varchar(55) NOT NULL DEFAULT '',
  PRIMARY KEY (`RUTE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "rute"
#

INSERT INTO `rute` VALUES ('R0001','Jakarta'),('R0002','Bandung'),('R0003','Fasdas'),('R0004','Surabaya'),('R0005','Dadasd');

#
# Structure for table "sewa"
#

DROP TABLE IF EXISTS `sewa`;
CREATE TABLE `sewa` (
  `SEWA_ID` varchar(15) NOT NULL DEFAULT '',
  `TANGGAL_SEWA` date NOT NULL,
  `HARGA_TOTAL` decimal(11,0) NOT NULL,
  `CUSTOMER_ID` varchar(15) NOT NULL DEFAULT '0',
  PRIMARY KEY (`SEWA_ID`),
  KEY `CUSTOMER_ID` (`CUSTOMER_ID`),
  CONSTRAINT `sewa` FOREIGN KEY (`CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "sewa"
#


#
# Structure for table "supir"
#

DROP TABLE IF EXISTS `supir`;
CREATE TABLE `supir` (
  `SUPIR_ID` varchar(15) NOT NULL DEFAULT '',
  `NAMA_SUPIR` varchar(55) NOT NULL DEFAULT '',
  `ALAMAT_SUPIR` varchar(100) DEFAULT NULL,
  `NOMOR_HP_SUPIR` varchar(15) DEFAULT NULL,
  `KERNET_ID` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`SUPIR_ID`),
  KEY `KERNET_ID` (`KERNET_ID`),
  CONSTRAINT `supir` FOREIGN KEY (`KERNET_ID`) REFERENCES `kernet` (`KERNET_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "supir"
#

INSERT INTO `supir` VALUES ('S0001','JONI','MAMPANG','02134',NULL),('S0002','SONI','MAMPANG','0213456','K0002'),('S0003','SURYO','ACEH','021674','K0003'),('S0004','DARMA','GROGOL','021647','K0004'),('S0005','234324','adasd','4234234',NULL);

#
# Structure for table "truk"
#

DROP TABLE IF EXISTS `truk`;
CREATE TABLE `truk` (
  `TRUK_ID` varchar(15) NOT NULL DEFAULT '',
  `NOMOR_POLISI` varchar(55) NOT NULL,
  `SUPIR_ID` varchar(15) DEFAULT NULL,
  `JENIS_TRUK_ID` varchar(15) DEFAULT NULL,
  `STATUS` varchar(15) NOT NULL DEFAULT '',
  PRIMARY KEY (`TRUK_ID`),
  KEY `SUPIR_ID` (`SUPIR_ID`),
  KEY `JENIS_TRUK_ID` (`JENIS_TRUK_ID`),
  CONSTRAINT `truk` FOREIGN KEY (`SUPIR_ID`) REFERENCES `supir` (`SUPIR_ID`),
  CONSTRAINT `truk2` FOREIGN KEY (`JENIS_TRUK_ID`) REFERENCES `jenis_truk` (`JENIS_TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "truk"
#

INSERT INTO `truk` VALUES ('T0002','B3213VAN','S0002','J0004','Tersedia'),('T0004','B4313JUM','S0004','J0004','Tersedia');

#
# Structure for table "sewa_detail"
#

DROP TABLE IF EXISTS `sewa_detail`;
CREATE TABLE `sewa_detail` (
  `HARGA` decimal(11,0) NOT NULL,
  `TRUK_ID` varchar(15) NOT NULL DEFAULT '0',
  `SEWA_ID` varchar(15) NOT NULL DEFAULT '0',
  KEY `TRUK_ID` (`TRUK_ID`),
  KEY `SEWA_ID` (`SEWA_ID`),
  CONSTRAINT `sewa_detail` FOREIGN KEY (`TRUK_ID`) REFERENCES `truk` (`TRUK_ID`),
  CONSTRAINT `sewa_detail2` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "sewa_detail"
#


#
# Structure for table "harga_truk_rute"
#

DROP TABLE IF EXISTS `harga_truk_rute`;
CREATE TABLE `harga_truk_rute` (
  `HARGA_TRUK_RUTE_ID` varchar(15) NOT NULL DEFAULT '',
  `RUTE_ID` varchar(15) NOT NULL,
  `TRUK_ID` varchar(15) NOT NULL,
  `HARGA` decimal(17,0) DEFAULT NULL,
  PRIMARY KEY (`HARGA_TRUK_RUTE_ID`),
  KEY `RUTE_ID` (`RUTE_ID`),
  KEY `TRUK_ID` (`TRUK_ID`),
  CONSTRAINT `truk_rute` FOREIGN KEY (`RUTE_ID`) REFERENCES `rute` (`RUTE_ID`),
  CONSTRAINT `truk_rute2` FOREIGN KEY (`TRUK_ID`) REFERENCES `truk` (`TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "harga_truk_rute"
#

INSERT INTO `harga_truk_rute` VALUES ('H0001','R0001','T0002',0),('H0002','R0002','T0002',0),('H0003','R0003','T0002',0),('H0004','R0004','T0002',0);
