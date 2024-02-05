-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 05, 2024 at 05:44 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `formula1`
--

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

CREATE TABLE `drivers` (
  `rajtszam` int(11) NOT NULL,
  `nev` varchar(45) NOT NULL,
  `csapat` varchar(45) NOT NULL,
  `szuletesiev` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`rajtszam`, `nev`, `csapat`, `szuletesiev`) VALUES
(1, 'Max Verstappen', 'Red Bull Racing', 1997),
(5, 'Sergio Pérez', 'Red Bull Racing', 1989),
(14, 'Fernando Alonso', 'Aston Martin Cognizant F1 Team', 1981),
(16, 'Charles Leclerc', 'Scuderia Ferrari', 1997),
(44, 'Sir Lewis Carl Davidson Hamilton', 'Mercedes-AMG PETRONAS F1 Team', 1985),
(63, 'George Russel', 'Mercedes-AMG PETRONAS F1 Team', 1998);

-- --------------------------------------------------------

--
-- Table structure for table `userok`
--

CREATE TABLE `userok` (
  `userName` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userok`
--

INSERT INTO `userok` (`userName`, `password`, `admin`) VALUES
('asd', 'World of thanks', 1),
('asd2', 'World of thanks', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `drivers`
--
ALTER TABLE `drivers`
  ADD PRIMARY KEY (`rajtszam`),
  ADD UNIQUE KEY `nev` (`nev`);

--
-- Indexes for table `userok`
--
ALTER TABLE `userok`
  ADD PRIMARY KEY (`userName`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
