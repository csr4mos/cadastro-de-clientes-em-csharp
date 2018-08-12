/*
SQLyog Community v11.31 (32 bit)
MySQL - 5.5.16 : Database - pfcsharp
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pfcsharp` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `pfcsharp`;

/*Table structure for table `cadclientes` */

DROP TABLE IF EXISTS `cadclientes`;

CREATE TABLE `cadclientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data_cad` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cad_ativo` enum('S','N') DEFAULT 'S',
  `nome_fantasia` varchar(255) DEFAULT NULL,
  `razao_social` varchar(255) DEFAULT NULL,
  `cnpj` varchar(25) DEFAULT NULL,
  `cpf` varchar(25) DEFAULT NULL,
  `tel_comercial` varchar(25) DEFAULT NULL,
  `email_comercial` varchar(150) DEFAULT NULL,
  `contato` varchar(150) DEFAULT NULL,
  `email_contato` varchar(150) DEFAULT NULL,
  `cel_contato` varchar(25) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `numero` varbinary(25) DEFAULT NULL,
  `cep` varchar(25) DEFAULT NULL,
  `bairro` varchar(150) DEFAULT NULL,
  `cidade` varchar(150) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  `produto` varchar(255) DEFAULT NULL,
  `news` enum('SIM','NÃO') DEFAULT 'SIM',
  `ultima_visita` datetime DEFAULT NULL,
  `proxima_visita` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `cadclientes` */

LOCK TABLES `cadclientes` WRITE;

insert  into `cadclientes`(`id`,`data_cad`,`cad_ativo`,`nome_fantasia`,`razao_social`,`cnpj`,`cpf`,`tel_comercial`,`email_comercial`,`contato`,`email_contato`,`cel_contato`,`endereco`,`numero`,`cep`,`bairro`,`cidade`,`estado`,`produto`,`news`,`ultima_visita`,`proxima_visita`) values (1,'2014-10-12 14:59:46','S','DADADA','','(   .   .    /','(    .   . ','(  )     -','','dadada','','(  )     -','','','     -','','','','','SIM','0000-00-00 00:00:00','0000-00-00 00:00:00'),(2,'2014-10-12 15:10:10','S','FDASFDAFSDSD','fadsfdsfasdads','(   .   .    /','(    .   . ','(  )     -','qfdafdsadsasda','fasdfsdfasdafsda','fdasfadsfasads','(  )     -','','','     -','','','','','SIM','0000-00-00 00:00:00','0000-00-00 00:00:00'),(3,'2014-10-12 15:29:05','S','JULIO FLORES','PSTU','( 16.161.616 /','( 161.616.1','(16) 1616-','julioflores@pstu.com.br','Julio','julioflores@pstu.com.br','(16) 1616-','RUA DO PARTIDO SOCIALISTA DOS TRABALHADORES','16','16161-616','DEMOCRACIA','PORTO ALEGRE','RS','SITE DA CAMPANHA 2014','SIM','0000-00-00 00:00:00','0000-00-00 00:00:00'),(4,'2014-10-12 15:34:36','S','BAR DO JOAO','Joao da Silva ME','( 21.212.121 / 2121-','( 171.171.171-17','(17) 1171-717','','','','(  )     -','','','     -','','','','','SIM','0000-00-00 00:00:00','0000-00-00 00:00:00'),(5,'2014-10-12 15:37:22','S','ASASASDFDDDF','dffdf','( 21.212.221 / 1212-11 )','( 878.787.878-77 )','(21) 2111-1111','','','','(51) 5151-15','','','15151-515','','','','','SIM','0000-00-00 00:00:00','0000-00-00 00:00:00');

UNLOCK TABLES;

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(255) DEFAULT NULL,
  `empresa` varchar(255) DEFAULT NULL,
  `funcao` varchar(150) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `senha` varchar(10) DEFAULT NULL,
  `dataCad` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `userAdm` enum('s','n') NOT NULL DEFAULT 's',
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `login` */

LOCK TABLES `login` WRITE;

insert  into `login`(`id`,`usuario`,`empresa`,`funcao`,`email`,`senha`,`dataCad`,`userAdm`) values (1,'Cristiano Ramos','K6 Tecnologia','Programador Jr.','csramos.poa@gmail.com','010203','2014-10-10 00:00:00','s'),(2,'qwert','qwert','System.Windows.Forms.TextBox, Text: qwert','qwert','qwert','2014-10-11 17:15:04','s'),(3,'wert','wert','System.Windows.Forms.TextBox, Text: wert','wert','wert','2014-10-11 17:21:39','s'),(4,'ASSA','ASSA','System.Windows.Forms.TextBox, Text: ASSA','AS','AS','2014-10-11 17:25:37','s'),(5,'loren','loren','System.Windows.Forms.TextBox, Text: loren','loren','loren','2014-10-11 17:32:22','s'),(6,'zx','zx','System.Windows.Forms.TextBox, Text: x','zx','zx','2014-10-11 17:45:29','s'),(7,'','','System.Windows.Forms.TextBox, Text: ','','','2014-10-11 17:47:28','s');

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
