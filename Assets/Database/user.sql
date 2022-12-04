-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2022 at 05:04 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `book_project`
--

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(250) DEFAULT NULL,
  `to_read_shelf` int(11) DEFAULT NULL,
  `reading_shelf` int(11) DEFAULT NULL,
  `read_shelf` int(11) DEFAULT NULL,
  `favorite_shelf` int(11) DEFAULT NULL,
  `recommendation_shelf` int(11) DEFAULT NULL,
  `userData` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `email`, `to_read_shelf`, `reading_shelf`, `read_shelf`, `favorite_shelf`, `recommendation_shelf`, `userData`) VALUES
('ana', '72019bbac0b3dac88beac9ddfef0ca808919104f', 'ana', NULL, NULL, NULL, NULL, NULL, '{\"_data\":{\"_userName\":\"ana\",\"_password\":\"ana\",\"_email\":\"\",\"_favoriteBooksIds\":[],\"_customShelves\":[{\"type\":0,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":1720,\"m_PathID\":0}}],\"ids\":[\"135\"]},{\"type\":1,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":1562,\"m_PathID\":0}},{\"_data\":{\"m_FileID\":1568,\"m_PathID\":0}},{\"_data\":{\"m_FileID\":1570,\"m_PathID\":0}}],\"ids\":[\"1\",\"2\",\"21\",\"21\",\"21\"]},{\"type\":2,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":0,\"m_PathID\":0}},{\"_data\":{\"m_FileID\":1720,\"m_PathID\":0}}],\"ids\":[\"23\",\"135\"]},{\"type\":3,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":4,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":5,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]}]}}'),
('johndoe', '6c074fa94c98638dfe3e3b74240573eb128b3d16', 'johndoe@gmail.com', 2, 3, 1, 4, 5, '{\"_data\":{\"_userName\":\"johndoe\",\"_password\":\"johndoe\",\"_email\":\"\",\"_favoriteBooksIds\":[],\"_customShelves\":[{\"type\":0,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[\"\",\"18\"]},{\"type\":1,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":1398,\"m_PathID\":0}}],\"ids\":[\"\",\"1\",\"21\"]},{\"type\":2,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[\"\",\"1\",\"13\"]},{\"type\":3,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[\"\"]},{\"type\":4,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[\"\"]},{\"type\":5,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":0,\"m_PathID\":0}}],\"ids\":[\"\"]}]}}'),
('johnsmith', '3b842bcd6faab4047ab49f9a99fa0704b9c9d2d7', 'johnsmith@gmail.com', 7, 6, 8, 9, 10, '{\"_data\":{\"_userName\":\"johnsmith\",\"_password\":\"johnsmith\",\"_email\":\"\",\"_favoriteBooksIds\":[],\"_customShelves\":[{\"type\":0,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":1,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":2,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":3,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":4,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":5,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]}]}}'),
('mariana', '0dcc3cc42445680eb0908b2b10b825b6ac5bb7c8', 'mariana', 1, 1, 1, 1, 1, '{\"_data\":{\"_userName\":\"mariana\",\"_password\":\"mariana\",\"_email\":\"\",\"_favoriteBooksIds\":[],\"_customShelves\":[{\"type\":0,\"shelfName\":\"\",\"booksHeld\":[{\"_data\":{\"m_FileID\":1562,\"m_PathID\":0}}],\"ids\":[\"1\"]},{\"type\":1,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":2,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":3,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":4,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]},{\"type\":5,\"shelfName\":\"\",\"booksHeld\":[],\"ids\":[]}]}}');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `User_FK` FOREIGN KEY (`to_read_shelf`) REFERENCES `shelf` (`shelf_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `User_FK_1` FOREIGN KEY (`reading_shelf`) REFERENCES `shelf` (`shelf_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `User_FK_2` FOREIGN KEY (`read_shelf`) REFERENCES `shelf` (`shelf_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `User_FK_3` FOREIGN KEY (`favorite_shelf`) REFERENCES `shelf` (`shelf_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `User_FK_4` FOREIGN KEY (`recommendation_shelf`) REFERENCES `shelf` (`shelf_id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
