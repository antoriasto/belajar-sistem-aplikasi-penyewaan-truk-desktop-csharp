# Host: localhost  (Version: 5.1.30-community)
# Date: 2014-07-14 01:58:06
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

INSERT INTO `customer` VALUES ('C0001','Joni','Jl. Piodsd','90232323');

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

INSERT INTO `jenis_truk` VALUES ('J0001','Container',5,50.00),('J0002','Van',6,100.00),('J0003','Engkle',7,200.00),('J0004','Jumbo',8,300.00),('J0005','Yankee',6,1.00);

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

INSERT INTO `kernet` VALUES ('K0001','Roy','rebo','12112'),('K0002','gaps','bayoran','42314321'),('K0003','david','kebon','43243'),('K0004','ucok','kebon','0214424'),('K0005','jon','bayoran','02143243');

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

INSERT INTO `rute` VALUES ('R0001','Jakarta'),('R0002','bekasi'),('R0003','bogor'),('R0004','depok'),('R0005','tanggerang');

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

INSERT INTO `sewa` VALUES ('SE0000000000001','2014-07-13',1350000,'C0001'),('SE0000000000002','2014-07-13',750000,'C0001'),('SE0000000000003','2014-07-13',1200000,'C0001');

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

INSERT INTO `supir` VALUES ('S0001','Panjul','petukangan','7897897','K0001'),('S0002','Karno','Kemanggisan','123123123','K0002'),('S0003','Robet','cinangka','321455','K0003'),('S0004','roni','kebon jeruk','02143543','K0004'),('S0005','boni','tanggerang','0214354','K0005');

#
# Structure for table "surat_jalan"
#

DROP TABLE IF EXISTS `surat_jalan`;
CREATE TABLE `surat_jalan` (
  `SURAT_JALAN_ID` varchar(15) NOT NULL,
  `TANGGAL_SURAT_JALAN` date NOT NULL DEFAULT '0000-00-00',
  `SEWA_ID` varchar(15) NOT NULL,
  PRIMARY KEY (`SURAT_JALAN_ID`),
  KEY `SEWA_ID` (`SEWA_ID`),
  CONSTRAINT `surat_jalan_ibfk_1` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "surat_jalan"
#

INSERT INTO `surat_jalan` VALUES ('SJ0000000000001','2014-07-13','SE0000000000001'),('SJ0000000000002','2014-07-13','SE0000000000002'),('SJ0000000000003','2014-07-13','SE0000000000003');

#
# Structure for table "invoice"
#

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE `invoice` (
  `INVOICE_ID` varchar(15) NOT NULL,
  `TANGGAL_INVOICE` date NOT NULL DEFAULT '0000-00-00',
  `SURAT_JALAN_ID` varchar(15) NOT NULL,
  PRIMARY KEY (`INVOICE_ID`),
  KEY `SURAT_JALAN_ID` (`SURAT_JALAN_ID`),
  CONSTRAINT `invoice_ibfk_1` FOREIGN KEY (`SURAT_JALAN_ID`) REFERENCES `surat_jalan` (`SURAT_JALAN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "invoice"
#

INSERT INTO `invoice` VALUES ('IN0000000000001','2014-07-14','SJ0000000000001');

#
# Structure for table "truk"
#

DROP TABLE IF EXISTS `truk`;
CREATE TABLE `truk` (
  `TRUK_ID` varchar(15) NOT NULL DEFAULT '',
  `NOMOR_POLISI` varchar(55) NOT NULL,
  `SUPIR_ID` varchar(15) DEFAULT '',
  `JENIS_TRUK_ID` varchar(15) DEFAULT '',
  `STATUS` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`TRUK_ID`),
  KEY `SUPIR_ID` (`SUPIR_ID`),
  KEY `JENIS_TRUK_ID` (`JENIS_TRUK_ID`),
  CONSTRAINT `truk` FOREIGN KEY (`SUPIR_ID`) REFERENCES `supir` (`SUPIR_ID`),
  CONSTRAINT `truk2` FOREIGN KEY (`JENIS_TRUK_ID`) REFERENCES `jenis_truk` (`JENIS_TRUK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "truk"
#

INSERT INTO `truk` VALUES ('T0001','B940234','S0001','J0003','Tersedia'),('T0002','B6523VAN','S0002','J0002','Tersedia'),('T0003','B4321JUM','S0003','J0004','Tersedia'),('T0004','B3124YAN','S0005','J0005','Tersedia'),('T0005','B7545CON','S0004','J0001','Tersedia');

#
# Structure for table "sewa_detail"
#

DROP TABLE IF EXISTS `sewa_detail`;
CREATE TABLE `sewa_detail` (
  `SEWA_ID` varchar(15) NOT NULL DEFAULT '0',
  `HARGA` decimal(11,0) NOT NULL,
  `TRUK_ID` varchar(15) NOT NULL DEFAULT '0',
  `KETERANGAN` varchar(255) DEFAULT NULL,
  KEY `TRUK_ID` (`TRUK_ID`),
  KEY `SEWA_ID` (`SEWA_ID`),
  CONSTRAINT `sewa_detail` FOREIGN KEY (`TRUK_ID`) REFERENCES `truk` (`TRUK_ID`),
  CONSTRAINT `sewa_detail2` FOREIGN KEY (`SEWA_ID`) REFERENCES `sewa` (`SEWA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "sewa_detail"
#

INSERT INTO `sewa_detail` VALUES ('SE0000000000001',450000,'T0005','PT Kemana ,jl poris siti'),('SE0000000000001',200000,'T0003','PT ALFAMART , bekasi utara siti'),('SE0000000000001',700000,'T0002','PT INDOMART , jl kebagusan siti'),('SE0000000000002',50000,'T0004','GANDARIA siti'),('SE0000000000002',700000,'T0001','PIM'),('SE0000000000003',700000,'T0002','bekasi barat'),('SE0000000000003',500000,'T0001','priok');

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

INSERT INTO `harga_truk_rute` VALUES ('H0001','R0001','T0001',500000),('H0002','R0002','T0001',600000),('H0003','R0003','T0001',700000),('H0004','R0004','T0001',800000),('H0005','R0005','T0001',900000),('H0006','R0001','T0002',600000),('H0007','R0002','T0002',700000),('H0008','R0003','T0002',800000),('H0009','R0004','T0002',900000),('H0010','R0005','T0002',1000000),('H0011','R0001','T0003',100000),('H0012','R0002','T0003',200000),('H0013','R0003','T0003',300000),('H0014','R0004','T0003',400000),('H0015','R0005','T0003',500000),('H0016','R0001','T0004',50000),('H0017','R0002','T0004',60000),('H0018','R0003','T0004',70000),('H0019','R0004','T0004',80000),('H0020','R0005','T0004',90000),('H0021','R0001','T0005',100000),('H0022','R0002','T0005',200000),('H0023','R0003','T0005',300000),('H0024','R0004','T0005',400000),('H0025','R0005','T0005',450000);
