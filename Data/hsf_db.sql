-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 11-Maio-2023 às 22:33
-- Versão do servidor: 10.4.25-MariaDB
-- versão do PHP: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `hsf_db`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `atc`
--

CREATE TABLE `atc` (
  `Id` int(11) NOT NULL,
  `PacientName` varchar(80) NOT NULL,
  `Turno` varchar(20) NOT NULL,
  `ReceituarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `atm`
--

CREATE TABLE `atm` (
  `Id` int(11) NOT NULL,
  `PacientName` varchar(80) NOT NULL,
  `MedicUnity` varchar(40) NOT NULL,
  `CID` varchar(20) NOT NULL,
  `RestDays` int(11) NOT NULL,
  `ReceituarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `medicamentos`
--

CREATE TABLE `medicamentos` (
  `Id` int(11) NOT NULL,
  `MedicationName` varchar(80) NOT NULL,
  `MedicationDosage` varchar(20) NOT NULL,
  `MedicationMethodUse` varchar(20) NOT NULL,
  `UseTime` int(11) NOT NULL,
  `DoseTime` int(11) NOT NULL,
  `ReceituarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `receitas`
--

CREATE TABLE `receitas` (
  `Id` int(11) NOT NULL,
  `PacientName` varchar(80) NOT NULL,
  `DoctorName` varchar(80) NOT NULL,
  `DateOfMedicalAppoiment` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230511203026_Hsf_Database', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `atc`
--
ALTER TABLE `atc`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ATC_ReceituarioId` (`ReceituarioId`);

--
-- Índices para tabela `atm`
--
ALTER TABLE `atm`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ATM_ReceituarioId` (`ReceituarioId`);

--
-- Índices para tabela `medicamentos`
--
ALTER TABLE `medicamentos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Medicamentos_ReceituarioId` (`ReceituarioId`);

--
-- Índices para tabela `receitas`
--
ALTER TABLE `receitas`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `atc`
--
ALTER TABLE `atc`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `atm`
--
ALTER TABLE `atm`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `medicamentos`
--
ALTER TABLE `medicamentos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `receitas`
--
ALTER TABLE `receitas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `atc`
--
ALTER TABLE `atc`
  ADD CONSTRAINT `FK_ATC_Receitas_ReceituarioId` FOREIGN KEY (`ReceituarioId`) REFERENCES `receitas` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `atm`
--
ALTER TABLE `atm`
  ADD CONSTRAINT `FK_ATM_Receitas_ReceituarioId` FOREIGN KEY (`ReceituarioId`) REFERENCES `receitas` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `medicamentos`
--
ALTER TABLE `medicamentos`
  ADD CONSTRAINT `FK_Medicamentos_Receitas_ReceituarioId` FOREIGN KEY (`ReceituarioId`) REFERENCES `receitas` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
