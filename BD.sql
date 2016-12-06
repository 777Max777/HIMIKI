-- phpMyAdmin SQL Dump
-- version 4.0.10.8
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Июл 03 2015 г., 23:24
-- Версия сервера: 5.5.40-MariaDB-cll-lve
-- Версия PHP: 5.4.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `crazy`
--

-- --------------------------------------------------------

--
-- Структура таблицы `game52`
--

CREATE TABLE IF NOT EXISTS `game52` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(70) NOT NULL,
  `username` varchar(70) NOT NULL,
  `item` text,
  `color` text,
  `value` text,
  `avatar` varchar(512) NOT NULL,
  `image` text NOT NULL,
  `from` text NOT NULL,
  `to` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Дамп данных таблицы `game52`
--

INSERT INTO `game52` (`id`, `userid`, `username`, `item`, `color`, `value`, `avatar`, `image`, `from`, `to`) VALUES
(1, '76561198085943895', 'Crazy-Random.ru скоро', 'MP9 | Ruby Poison Dart (Factory New)', 'D2D2D2', '0.76', 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/eb/ebe67afce7b2294770ca461b335a4ec541aed119_full.jpg', 'fWFc82js0fmoRAP-qOIPu5THSWqfSmTELLqcUywGkijVjZYMUrsm1j-9xgEObwgfEh_nvjlWhNzZCveCDfIBj98xqodQ2CZknz52JLqKMTpYfxSbPq5XSOc18w3iNis77893GoS3p7lTKAu84IHHYrd_ZoxJScCEU_bUb1j9u0ps0vcOe8ePpCi8jnz3ejBd58CRl1g', '0', '0.76');

-- --------------------------------------------------------

--
-- Структура таблицы `game53`
--

CREATE TABLE IF NOT EXISTS `game53` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(70) NOT NULL,
  `username` varchar(70) NOT NULL,
  `item` text,
  `color` text,
  `value` text,
  `avatar` varchar(512) NOT NULL,
  `image` text NOT NULL,
  `from` text NOT NULL,
  `to` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Структура таблицы `games`
--

CREATE TABLE IF NOT EXISTS `games` (
  `id` int(11) NOT NULL DEFAULT '0',
  `starttime` int(11) NOT NULL,
  `cost` float DEFAULT NULL,
  `winner` varchar(128) NOT NULL,
  `userid` varchar(70) NOT NULL,
  `percent` varchar(10) DEFAULT NULL,
  `itemsnum` int(11) NOT NULL,
  `module` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `games`
--

INSERT INTO `games` (`id`, `starttime`, `cost`, `winner`, `userid`, `percent`, `itemsnum`, `module`) VALUES
(52, 1435098148, 0.76, 'Crazy-Random.ru скоро', '76561198085943895', '100', 1, '0.978820851'),
(53, 2147483647, 0, '', '', NULL, 0, '');

-- --------------------------------------------------------

--
-- Структура таблицы `info`
--

CREATE TABLE IF NOT EXISTS `info` (
  `name` varchar(255) NOT NULL,
  `value` float NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `info`
--

INSERT INTO `info` (`name`, `value`) VALUES
('current_game', 53),
('state', 0),
('rake', 10),
('minbet', 0),
('maxitems', 40);

-- --------------------------------------------------------

--
-- Структура таблицы `items`
--

CREATE TABLE IF NOT EXISTS `items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `cost` float NOT NULL,
  `lastupdate` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=79 ;

--
-- Дамп данных таблицы `items`
--

INSERT INTO `items` (`id`, `name`, `cost`, `lastupdate`) VALUES
(13, 'Five-SeveN%20|%20Orange%20Peel%20(Field-Tested)', 0.06, '1433104160'),
(5, 'P250%20|%20Steel%20Disruption%20(Factory%20New)', 0.24, '1431774638'),
(51, 'UMP-45%20|%20Urban%20DDPAT%20(Field-Tested)', 0.03, '1434275578'),
(7, 'Nova%20|%20Ghost%20Camo%20(Factory%20New)', 0.28, '1431781594'),
(61, 'Operation%20Vanguard%20Weapon%20Case', 0.04, '1434387816'),
(49, 'Nova%20|%20Polar%20Mesh%20(Field-Tested)', 0.04, '1434275577'),
(62, 'MP7%20|%20Forest%20DDPAT%20(Field-Tested)', 0.04, '1434387816'),
(55, 'SSG%2008%20|%20Blue%20Spruce%20(Field-Tested)', 0.04, '1434275819'),
(12, 'M4A1-S%20|%20Boreal%20Forest%20(Battle-Scarred)', 0.18, '1433104160'),
(14, 'UMP-45%20|%20Urban%20DDPAT%20(Well-Worn)', 0.04, '1433104968'),
(77, 'Chroma%20Case', 0.03, '1435097007'),
(75, 'Operation%20Breakout%20Weapon%20Case', 0.03, '1435097007'),
(76, 'Operation%20Phoenix%20Weapon%20Case', 0.04, '1435097007'),
(18, 'MP9%20|%20Deadly%20Poison%20(Field-Tested)', 0.08, '1433153102'),
(19, 'SCAR-20%20|%20Grotto%20(Field-Tested)', 0.09, '1433153264'),
(20, 'MAG-7%20|%20Heaven%20Guard%20(Factory%20New)', 0.1, '1433153265'),
(21, 'Galil%20AR%20|%20Sandstorm%20(Field-Tested)', 0.12, '1433153265'),
(22, 'Glock-18%20|%20Catacombs%20(Minimal%20Wear)', 0.09, '1433155232'),
(23, 'Dual%20Berettas%20|%20Contractor%20(Field-Tested)', 0.04, '1433453290'),
(24, 'M249%20|%20Contrast%20Spray%20(Field-Tested)', 0.04, '1433503274'),
(25, 'Dual%20Berettas%20|%20Contractor%20(Minimal%20Wear)', 0.04, '1433503275'),
(26, 'SG%20553%20|%20Waves%20Perforated%20(Well-Worn)', 0.03, '1433503276'),
(27, 'P250%20|%20Sand%20Dune%20(Minimal%20Wear)', 0.04, '1433503276'),
(29, 'FAMAS%20|%20Colony%20(Field-Tested)', 0.03, '1433503277'),
(30, 'Sawed-Off%20|%20Origami%20(Minimal%20Wear)', 0.14, '1433503278'),
(31, 'P90%20|%20Module%20(Minimal%20Wear)', 0.13, '1433503279'),
(32, 'AK-47%20|%20Elite%20Build%20(Battle-Scarred)', 0.43, '1433506775'),
(33, 'CZ75-Auto%20|%20Pole%20Position%20(Battle-Scarred)', 0.38, '1433506775'),
(34, 'P250%20|%20Valence%20(Minimal%20Wear)', 0.29, '1433506776'),
(35, 'SG%20553%20|%20Army%20Sheen%20(Factory%20New)', 0.05, '1433508379'),
(36, 'MP9%20|%20Storm%20(Battle-Scarred)', 0.04, '1433508379'),
(37, 'MP9%20|%20Storm%20(Field-Tested)', 0.04, '1433508380'),
(38, 'SG%20553%20|%20Waves%20Perforated%20(Battle-Scarred)', 0.04, '1433508380'),
(39, 'M4A4%20|%20龍王%20(Dragon%20King)%20(Field-Tested)', 1.95, '1433520065'),
(41, 'P250%20|%20Sand%20Dune%20(Field-Tested)', 0.04, '1434273585'),
(42, 'P250%20|%20Boreal%20Forest%20(Well-Worn)', 0.04, '1434273607'),
(44, 'SCAR-20%20|%20Sand%20Mesh%20(Field-Tested)', 0.04, '1434273631'),
(45, 'Five-SeveN%20|%20Forest%20Night%20(Field-Tested)', 0.03, '1434273631'),
(46, 'CS:GO%20Weapon%20Case%203', 0.08, '1434273632'),
(47, 'XM1014%20|%20Blue%20Spruce%20(Well-Worn)', 0.04, '1434274158'),
(48, 'Huntsman%20Weapon%20Case', 0.12, '1434275201'),
(50, 'Nova%20|%20Predator%20(Minimal%20Wear)', 0.04, '1434275577'),
(52, 'AK-47%20|%20Blue%20Laminate%20(Factory%20New)', 1.61, '1434275691'),
(53, 'SG%20553%20|%20Army%20Sheen%20(Minimal%20Wear)', 0.04, '1434275818'),
(54, 'Desert%20Eagle%20|%20Mudder%20(Minimal%20Wear)', 0.06, '1434275819'),
(57, 'MP7%20|%20Army%20Recon%20(Field-Tested)', 0.04, '1434382735'),
(58, 'Galil%20AR%20|%20Sage%20Spray%20(Field-Tested)', 0.03, '1434383446'),
(59, 'Glock-18%20|%20Candy%20Apple%20(Minimal%20Wear)', 0.28, '1434384369'),
(60, 'P250%20|%20Sand%20Dune%20(Well-Worn)', 0.04, '1434387815'),
(63, 'SG%20553%20|%20Waves%20Perforated%20(Field-Tested)', 0.04, '1434387817'),
(64, 'Tec-9%20|%20Groundwater%20(Field-Tested)', 0.03, '1434387817'),
(65, 'StatTrak™%20P2000%20|%20Pulse%20(Field-Tested)', 0.26, '1434394171'),
(66, 'UMP-45%20|%20Carbon%20Fiber%20(Factory%20New)', 0.06, '1434394171'),
(67, 'Tec-9%20|%20Urban%20DDPAT%20(Field-Tested)', 0.04, '1434394172'),
(68, 'StatTrak™%20UMP-45%20|%20Corporal%20(Well-Worn)', 0.18, '1434394172'),
(69, 'G3SG1%20|%20VariCamo%20(Minimal%20Wear)', 0.06, '1434394173'),
(70, 'Tec-9%20|%20Red%20Quartz%20(Factory%20New)', 0.5, '1434394174'),
(71, 'G3SG1%20|%20Desert%20Storm%20(Field-Tested)', 0.04, '1434394177'),
(72, 'Tec-9%20|%20Groundwater%20(Well-Worn)', 0.04, '1434399141'),
(73, 'Nova%20|%20Polar%20Mesh%20(Minimal%20Wear)', 0.03, '1434399141'),
(74, 'Nova%20|%20Caged%20Steel%20(Factory%20New)', 0.06, '1434399333'),
(78, 'MP9%20|%20Ruby%20Poison%20Dart%20(Factory%20New)', 0.76, '1435098146');

-- --------------------------------------------------------

--
-- Структура таблицы `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(70) NOT NULL,
  `msg` text NOT NULL,
  `from` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=129 ;

--
-- Дамп данных таблицы `messages`
--

INSERT INTO `messages` (`id`, `userid`, `msg`, `from`) VALUES
(56, '76561198196254175', 'lost', 'SYSTEM'),
(57, '76561198196254175', 'Fresh_Meat выиграл 0.32$, с шансом 75%', 'Проигрыш');

-- --------------------------------------------------------

--
-- Структура таблицы `queue`
--

CREATE TABLE IF NOT EXISTS `queue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(70) NOT NULL,
  `token` varchar(128) NOT NULL,
  `items` text NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=53 ;

--
-- Дамп данных таблицы `queue`
--

INSERT INTO `queue` (`id`, `userid`, `token`, `items`, `status`) VALUES
(52, '76561198219736388', 'QMl04gvJ', 'MP9 | Ruby Poison Dart (Factory New)', 'sent');

-- --------------------------------------------------------

--
-- Структура таблицы `rakeitems`
--

CREATE TABLE IF NOT EXISTS `rakeitems` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=59 ;

--
-- Дамп данных таблицы `rakeitems`
--

INSERT INTO `rakeitems` (`id`, `item`) VALUES
(1, 'SCAR-20 | Sand Mesh (Field-Tested)'),
(2, 'Operation Breakout Weapon Case'),
(3, 'Huntsman Weapon Case'),
(4, 'Huntsman Weapon Case'),
(5, 'Huntsman Weapon Case'),
(6, 'CS:GO Weapon Case 3'),
(7, 'MP7 | Army Recon (Field-Tested)'),
(8, 'Huntsman Weapon Case'),
(9, 'Desert Eagle | Mudder (Minimal Wear)'),
(10, 'Operation Breakout Weapon Case'),
(11, 'Chroma Case'),
(12, 'SSG 08 | Blue Spruce (Field-Tested)'),
(13, 'P250 | Sand Dune (Field-Tested)'),
(14, 'Huntsman Weapon Case'),
(15, 'Huntsman Weapon Case'),
(16, 'SSG 08 | Blue Spruce (Field-Tested)'),
(17, 'Tec-9 | Groundwater (Field-Tested)'),
(18, 'Operation Breakout Weapon Case'),
(19, 'Tec-9 | Red Quartz (Factory New)'),
(20, 'G3SG1 | Desert Storm (Field-Tested)'),
(21, 'StatTrak™ P2000 | Pulse (Field-Tested)'),
(22, 'StatTrak™ UMP-45 | Corporal (Well-Worn)'),
(23, 'Huntsman Weapon Case'),
(24, 'UMP-45 | Urban DDPAT (Field-Tested)'),
(25, 'CS:GO Weapon Case 3'),
(26, 'Desert Eagle | Mudder (Minimal Wear)'),
(27, 'UMP-45 | Carbon Fiber (Factory New)'),
(28, 'G3SG1 | VariCamo (Minimal Wear)'),
(29, 'P250 | Boreal Forest (Well-Worn)'),
(30, 'MP7 | Forest DDPAT (Field-Tested)'),
(31, 'Chroma Case'),
(32, 'Five-SeveN | Forest Night (Field-Tested)'),
(33, 'Operation Breakout Weapon Case'),
(34, 'Operation Breakout Weapon Case'),
(35, 'Chroma Case'),
(36, 'Operation Breakout Weapon Case'),
(37, 'Operation Phoenix Weapon Case'),
(38, 'P250 | Sand Dune (Field-Tested)'),
(39, 'G3SG1 | VariCamo (Minimal Wear)'),
(40, 'Chroma Case'),
(41, 'CS:GO Weapon Case 3'),
(42, 'Huntsman Weapon Case'),
(43, 'Nova | Caged Steel (Factory New)'),
(44, 'Chroma Case'),
(45, 'Nova | Predator (Minimal Wear)'),
(46, 'SG 553 | Waves Perforated (Field-Tested)'),
(47, 'CS:GO Weapon Case 3'),
(48, 'UMP-45 | Urban DDPAT (Field-Tested)'),
(49, 'StatTrak™ UMP-45 | Corporal (Well-Worn)'),
(50, 'UMP-45 | Carbon Fiber (Factory New)'),
(51, 'Huntsman Weapon Case'),
(52, 'Desert Eagle | Mudder (Minimal Wear)'),
(53, 'Nova | Polar Mesh (Field-Tested)'),
(54, 'UMP-45 | Urban DDPAT (Field-Tested)'),
(55, 'StatTrak™ UMP-45 | Corporal (Well-Worn)'),
(56, 'CS:GO Weapon Case 3'),
(57, 'StatTrak™ UMP-45 | Corporal (Well-Worn)'),
(58, 'CS:GO Weapon Case 3');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `steamid` varchar(70) NOT NULL,
  `tlink` varchar(255) DEFAULT NULL,
  `won` float DEFAULT '0',
  `admin` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `avatar` varchar(255) NOT NULL,
  `games` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `steamid`, `tlink`, `won`, `admin`, `name`, `avatar`, `games`) VALUES
(10, '76561198085943895', 'https://steamcommunity.com/tradeoffer/new/?partner=125678167&token=72LIDiD7', 0.76, 0, 'Crazy-Random.ru скоро', 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/eb/ebe67afce7b2294770ca461b335a4ec541aed119_full.jpg', 1);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
