-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Hôte : mariadb
-- Généré le : lun. 25 avr. 2022 à 06:48
-- Version du serveur : 10.7.3-MariaDB-1:10.7.3+maria~focal
-- Version de PHP : 8.0.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Base de données : `dotsafedb`
--

-- --------------------------------------------------------

--
-- Structure de la table `Contributions`
--


--
-- Déchargement des données de la table `Contributions`
--

INSERT INTO `Contributions` (`Id`, `name`, `UserId`, `TechnoId`, `ProjectId`) VALUES
(1, 'contribution11', 1, 1, 1),
(2, 'contribution12', 1, 2, 1),
(3, 'contribution13', 2, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `Projects`
--

--
-- Déchargement des données de la table `Projects`
--

INSERT INTO `Projects` (`Id`, `name`) VALUES
(1, 'project1'),
(2, 'project2');

-- --------------------------------------------------------

--
-- Structure de la table `Technos`
--

--
-- Déchargement des données de la table `Technos`
--

INSERT INTO `Technos` (`Id`, `name`) VALUES
(1, 'techno1'),
(2, 'techno2'),
(3, 'techno3'),
(4, 'techno4');

-- --------------------------------------------------------

--
-- Structure de la table `Users`
--

--
-- Déchargement des données de la table `Users`
--

INSERT INTO `Users` (`Id`, `username`, `email`, `roles`, `password`) VALUES
(1, 'username1', 'username1@username.fr', NULL, NULL),
(2, 'username2', 'username2@username.fr', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `__EFMigrationsHistory`
--

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Contributions`
--
ALTER TABLE `Contributions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Contributions_ProjectId` (`ProjectId`),
  ADD KEY `IX_Contributions_TechnoId` (`TechnoId`),
  ADD KEY `IX_Contributions_UserId` (`UserId`);

--
-- Index pour la table `Projects`
--
ALTER TABLE `Projects`
  ADD PRIMARY KEY (`Id`);

--
-- Index pour la table `Technos`
--
ALTER TABLE `Technos`
  ADD PRIMARY KEY (`Id`);

--
-- Index pour la table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- Index pour la table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `Contributions`
--
ALTER TABLE `Contributions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `Projects`
--
ALTER TABLE `Projects`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `Technos`
--
ALTER TABLE `Technos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `Contributions`
--
ALTER TABLE `Contributions`
  ADD CONSTRAINT `FK_Contributions_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`),
  ADD CONSTRAINT `FK_Contributions_Technos_TechnoId` FOREIGN KEY (`TechnoId`) REFERENCES `Technos` (`Id`),
  ADD CONSTRAINT `FK_Contributions_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`);
COMMIT;
