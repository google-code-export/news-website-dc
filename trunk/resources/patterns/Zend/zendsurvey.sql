/*
SQLyog Community Edition- MySQL GUI v7.15 
MySQL - 5.0.51a-community-nt : Database - zendsurvey
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`zendsurvey` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;

USE `zendsurvey`;

/*Table structure for table `answers` */

DROP TABLE IF EXISTS `answers`;

CREATE TABLE `answers` (
  `id` int(11) NOT NULL auto_increment,
  `user_id` int(11) NOT NULL,
  `question_option_id` int(11) NOT NULL,
  `answer_numeric` int(11) default NULL,
  `answer_text` varchar(255) collate utf8_unicode_ci default NULL,
  `answer_yn` tinyint(1) default NULL,
  `unit_of_measure_id` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `answers` */

/*Table structure for table `input_types` */

DROP TABLE IF EXISTS `input_types`;

CREATE TABLE `input_types` (
  `id` int(11) NOT NULL auto_increment,
  `input_type_name` varchar(80) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `input_types` */

/*Table structure for table `option_choices` */

DROP TABLE IF EXISTS `option_choices`;

CREATE TABLE `option_choices` (
  `id` int(11) NOT NULL auto_increment,
  `option_group_id` int(11) NOT NULL,
  `option_choice_name` varchar(45) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `option_choices` */

/*Table structure for table `option_groups` */

DROP TABLE IF EXISTS `option_groups`;

CREATE TABLE `option_groups` (
  `id` int(11) NOT NULL auto_increment,
  `option_group_name` varchar(45) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `option_groups` */

/*Table structure for table `organizations` */

DROP TABLE IF EXISTS `organizations`;

CREATE TABLE `organizations` (
  `id` int(11) NOT NULL auto_increment,
  `organization_name` varchar(80) character set utf8 NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `organizations` */

/*Table structure for table `question_options` */

DROP TABLE IF EXISTS `question_options`;

CREATE TABLE `question_options` (
  `id` int(11) NOT NULL auto_increment,
  `question_id` int(11) NOT NULL,
  `option_choice_id` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `question_options` */

/*Table structure for table `questions` */

DROP TABLE IF EXISTS `questions`;

CREATE TABLE `questions` (
  `id` int(11) NOT NULL auto_increment,
  `survey_section_id` int(11) NOT NULL,
  `input_type_id` int(11) NOT NULL,
  `question_name` varchar(255) collate utf8_unicode_ci NOT NULL,
  `question_subtext` varchar(500) collate utf8_unicode_ci default NULL,
  `answer_required_yn` tinyint(1) default NULL,
  `option_group_id` int(11) default NULL,
  `allow_multiple_option_answers_yn` tinyint(1) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `questions` */

/*Table structure for table `survey_comments` */

DROP TABLE IF EXISTS `survey_comments`;

CREATE TABLE `survey_comments` (
  `id` int(11) NOT NULL auto_increment,
  `survey_header_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `comments` varchar(4096) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `survey_comments` */

/*Table structure for table `survey_headers` */

DROP TABLE IF EXISTS `survey_headers`;

CREATE TABLE `survey_headers` (
  `id` int(11) NOT NULL auto_increment,
  `organization_id` int(11) NOT NULL,
  `survey_name` varchar(80) character set utf8 default NULL,
  `instructions` varchar(4096) character set utf8 default NULL,
  `other_header_info` varchar(255) character set utf8 default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `survey_headers` */

/*Table structure for table `survey_sections` */

DROP TABLE IF EXISTS `survey_sections`;

CREATE TABLE `survey_sections` (
  `id` int(11) NOT NULL auto_increment,
  `survey_header_id` int(11) default NULL,
  `section_name` varchar(80) collate utf8_unicode_ci default NULL,
  `section_title` varchar(45) collate utf8_unicode_ci default NULL,
  `section_subheading` varchar(45) collate utf8_unicode_ci default NULL,
  `section_required_yn` tinyint(1) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `survey_sections` */

/*Table structure for table `unit_of_measures` */

DROP TABLE IF EXISTS `unit_of_measures`;

CREATE TABLE `unit_of_measures` (
  `id` int(11) NOT NULL auto_increment,
  `unit_of_measure_name` varchar(80) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `unit_of_measures` */

/*Table structure for table `user_survey_sections` */

DROP TABLE IF EXISTS `user_survey_sections`;

CREATE TABLE `user_survey_sections` (
  `id` int(11) NOT NULL auto_increment,
  `user_id` int(11) NOT NULL,
  `survey_section_id` int(11) NOT NULL,
  `completed_on` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `user_survey_sections` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) NOT NULL auto_increment,
  `username` varchar(80) collate utf8_unicode_ci NOT NULL,
  `password_hashed` varchar(255) collate utf8_unicode_ci default NULL,
  `email` varchar(45) collate utf8_unicode_ci NOT NULL,
  `admin` tinyint(1) default NULL,
  `invite_dt` datetime default NULL,
  `last_login_dt` datetime default NULL,
  `inviter_user_id` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `users` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
