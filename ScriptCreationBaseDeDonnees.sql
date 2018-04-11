USE mysql;
DROP DATABASE IF EXISTS AGSE_Manager;
CREATE DATABASE AGSE_Manager;
USE AGSE_Manager;

CREATE TABLE Dossier
(
	id INT AUTO_INCREMENT,
	modifiable TINYINT(1),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE TABLE Sinistre
(
	id INT AUTO_INCREMENT,
	type VARCHAR(100),
	adresse VARCHAR(100),
	ville VARCHAR(50),
	codePostal VARCHAR(5),
	dateSurvenance DATE,
	causesEtCirconstances VARCHAR(1000),
	origine VARCHAR(50),
	rdf VARCHAR(50),
	origineSinistre VARCHAR(1000),

	idEntrepriseRdf INT,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;


CREATE TABLE Mission
(
	id INT AUTO_INCREMENT,
	dateReception DATE,
	dateConfirmationReception DATE,
	moyenMissionnement VARCHAR(100),
	idClient INT,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE TABLE Contrat
(
	id int AUTO_INCREMENT,
	type varchar(100),
	formule varchar(100),
	effetDu date,
	numeroContrat varchar(100),
	numeroCg varchar(100),
	intercalaire varchar(100),
	franchise numeric(9,2),				-- ???
	detailFranchise varchar(100),
	indiceSouscription numeric(9,2),	-- ???
	indiceIndemnisation numeric(9,2),	-- ???
	optionUn varchar(100),
	optionDeux varchar(100),
	optionTrois varchar(100),
	detailOptionUn varchar(100),
	detailOptionDeux varchar(100),
	detailOptionTrois varchar(100),

	idCompagnie int,
	idAssureur int,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Intervenant
(
	id int AUTO_INCREMENT,
	nom varchar(100),
	prenom varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	telephone varchar(10),
	mail varchar(100),
	statut TINYINT(1),
	presence TINYINT(1),
	qualite varchar(100),
	typeLieu varchar(100),
	utilite varchar(100),
	etat varchar(100),
	etage varchar(100),
	remarque varchar(100),
	numeroContrat varchar(100),
	numeroSinistre varchar(100),

	idRepresentant int,
	idCompagnie int,
	idAssureur int,
	idExpert int,
	idDossier int,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Risque
(
	id int AUTO_INCREMENT,
	type varchar(100),
	dateConstruction varchar(100),   -- enum -2 +2 +10
	anneeConstruction int,
	typeMur varchar(100),
	anneeConstructionMur int,
	typeCouverture varchar(100),
	anneeConstructionCouverture int,
	utilite varchar(100),
	batimentClasse TINYINT(1),
	etat varchar(100),
	piecePrincipaleAuContrat varchar(100),
	piecePrincipaleConstatee varchar(100),
	dependanceAuContrat varchar(100),
	dependanceConstatee varchar(100),
	details varchar(100),
	conformite TINYINT(1),
	motif varchar(100),
	amiante varchar(100),
	assuranceDommageOuvrage TINYINT(1),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Representant
(
	id int AUTO_INCREMENT,
	nom varchar(100),
	prenom varchar(100),
	telephone varchar(100),
	mail varchar(100),
	qualite varchar(100),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Client
(
	id int AUTO_INCREMENT,
	idClientExistant int DEFAULT 0,
	nom varchar(100),
	prenom varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	telephone varchar(10),
	mail varchar(100),

	raisonSociale varchar(100),
	adresseSiegeSocial varchar(100),
	villeSiegeSocial varchar(100),
	codePostalSiegeSocial varchar(100),
	telephoneProfessionnel varchar(10),
	idRepresentant int,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Compagnie
(
	id int AUTO_INCREMENT,
	raisonSociale varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Assureur
(
	id int AUTO_INCREMENT,
	raisonSociale varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	telephone varchar(100),
	mail varchar(100),

	idRepresentant int,
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table EntrepriseRdf
(
	id int AUTO_INCREMENT,
	raisonSociale varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE table Expert
(
	id int AUTO_INCREMENT,
	nom varchar(100),
	prenom varchar(100),
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	telephone varchar(10),
	mail varchar(100),
	numeroDossier varchar(100),
	primary key(id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE TABLE AssuranceDommageOuvrage
(
	id int auto_increment,
	raisonSociale varchar(100) default null,
	adresse varchar(100),
	ville varchar(100),
	codePostal varchar(100),
	numeroContrat varchar(100),
	effetDu date,
	PRIMARY KEY(Id)
)ENGINE=INNODB CHARACTER SET utf8;

CREATE TABLE ComboBoxItems
(
	id int AUTO_INCREMENT,
	categorie varchar(40),
	libelle varchar(100),
	PRIMARY KEY(Id)
)ENGINE=INNODB CHARACTER SET utf8;

-- source C:/Users/vivij/OneDrive/Documents/Visual Studio 2015/Projects/AGSE-Manager/ScriptCreationBaseDeDonnees.sql



insert into ComboBoxItems(categorie, libelle) values ("sinistre","BRIS DE GLACE");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","CATASTROPHE NATURELLE");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","DEGAT DES EAUX");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","DETERIORATIONS IMMOBILIERES");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","INCENDIE");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","INONDATION");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","PROTECTION JURIDIQUE");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","TEMPETE");
insert into ComboBoxItems(categorie, libelle) values ("sinistre","VOL");

insert into ComboBoxItems(categorie, libelle) values ("qualite","Copropriétaire Occupant");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Copropriétaire Non Occupant");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Locataire");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Propriétaire");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Occupant à titre gracieux");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Propriétaire Bailleur");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Propriétaire Non Occupant");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Sous Locataire");
insert into ComboBoxItems(categorie, libelle) values ("qualite","Syndic de copropriété");

insert into ComboBoxItems(categorie, libelle) values ("usage","de Résidence Principale");
insert into ComboBoxItems(categorie, libelle) values ("usage","de Résidence Secondaire");
insert into ComboBoxItems(categorie, libelle) values ("usage","Locatif d'habitation");
insert into ComboBoxItems(categorie, libelle) values ("usage","Locatif professionnel");
insert into ComboBoxItems(categorie, libelle) values ("usage","d'Immeuble d'habitation");
insert into ComboBoxItems(categorie, libelle) values ("usage","d'Immeuble mixte");
insert into ComboBoxItems(categorie, libelle) values ("usage","Professionnel");

insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Appartement");
insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Bâtiment");
insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Immeuble");
insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Local Professionnel");
insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Loge de Gardien");
insert into ComboBoxItems(categorie, libelle) values ("typeLieu","Maison");

insert into ComboBoxItems(categorie, libelle) values ("etat","(…)");
insert into ComboBoxItems(categorie, libelle) values ("etat","Loué");
insert into ComboBoxItems(categorie, libelle) values ("etat","Loué (Meublé)");
insert into ComboBoxItems(categorie, libelle) values ("etat","Occupé");
insert into ComboBoxItems(categorie, libelle) values ("etat","Vacant");
insert into ComboBoxItems(categorie, libelle) values ("etat","Vacant (en rénovation)");

insert into ComboBoxItems(categorie, libelle) values ("piece","(Néant)");
insert into ComboBoxItems(categorie, libelle) values ("piece","Arrière cuisine");
insert into ComboBoxItems(categorie, libelle) values ("piece","Atelier");
insert into ComboBoxItems(categorie, libelle) values ("piece","Balcon");
insert into ComboBoxItems(categorie, libelle) values ("piece","Buanderie");
insert into ComboBoxItems(categorie, libelle) values ("piece","Bureau");
insert into ComboBoxItems(categorie, libelle) values ("piece","Bureau 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cage d'ascenseur");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cage d'escalier");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cagibi");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cave");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cellier");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre 1");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre 3");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre 4");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chambre 5");
insert into ComboBoxItems(categorie, libelle) values ("piece","Chaufferie");
insert into ComboBoxItems(categorie, libelle) values ("piece","Combles");
insert into ComboBoxItems(categorie, libelle) values ("piece","Couloir");
insert into ComboBoxItems(categorie, libelle) values ("piece","Cuisine");
insert into ComboBoxItems(categorie, libelle) values ("piece","Dégagement");
insert into ComboBoxItems(categorie, libelle) values ("piece","Dressing");
insert into ComboBoxItems(categorie, libelle) values ("piece","Dressing 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Entrée");
insert into ComboBoxItems(categorie, libelle) values ("piece","Gaine technique");
insert into ComboBoxItems(categorie, libelle) values ("piece","Garage");
insert into ComboBoxItems(categorie, libelle) values ("piece","Garage");
insert into ComboBoxItems(categorie, libelle) values ("piece","Garage à vélo");
insert into ComboBoxItems(categorie, libelle) values ("piece","Hall d'entrée");
insert into ComboBoxItems(categorie, libelle) values ("piece","Local technique");
insert into ComboBoxItems(categorie, libelle) values ("piece","Loggia");
insert into ComboBoxItems(categorie, libelle) values ("piece","Mezzanine");
insert into ComboBoxItems(categorie, libelle) values ("piece","Palier");
insert into ComboBoxItems(categorie, libelle) values ("piece","Parkings souterrains");
insert into ComboBoxItems(categorie, libelle) values ("piece","Placard");
insert into ComboBoxItems(categorie, libelle) values ("piece","Placard 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Placard 3");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle à manger");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle à manger 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle de bains");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle de bains 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle de jeux");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salle d'eau");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salon");
insert into ComboBoxItems(categorie, libelle) values ("piece","Salon 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Sas");
insert into ComboBoxItems(categorie, libelle) values ("piece","Sas 2");
insert into ComboBoxItems(categorie, libelle) values ("piece","Séchoir");
insert into ComboBoxItems(categorie, libelle) values ("piece","Terrasse");
insert into ComboBoxItems(categorie, libelle) values ("piece","Toiture");
insert into ComboBoxItems(categorie, libelle) values ("piece","Véranda");
insert into ComboBoxItems(categorie, libelle) values ("piece","Wc");
insert into ComboBoxItems(categorie, libelle) values ("piece","Wc 2");

insert into ComboBoxItems(categorie, libelle) values ("travaux","Assèchement (travaux d')");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Barre de seuil (dépose / pose / fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Barre de seuil (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Barre de seuil (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Echafaudage");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Electricité (mise en sécurité d'installation)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Electricité (travaux d')");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Enduits complémentaires");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Faux plafond type BA13");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Faux plafond type BA13 et ossature");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Lambris (dépose / pose / fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Lambris (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Lambris (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Maçonnerie");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Manutention de mobilier");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Menuiseries Aluminium");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Menuiseries Bois");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Menuiseries Pvc");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Papiers peints (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Papiers peints (fourniture Rlx)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Parquet (ponçage / Traitement)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Parquet flottant (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Parquet flottant (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Parquet massif (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Parquet massif (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Peinture (forfait)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Peinture (mise en teinte)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Peinture (préparation + 2 couches)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Peinture décorarative");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plâtrerie");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plâtrerie (forfait)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plâtrerie (reprise partielle de)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plinthes (dépose / pose / fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plinthes (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plinthes (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Plinthes (mise en peinture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Recherche de fuite");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Recherche de fuite (remise en état)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol CISAL (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol CISAL (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol JONC DE MER (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol JONC DE MER (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol PVC (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol PVC (forfait)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Revêtement de sol PVC (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Tissus tendu (dépose / pose)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Tissus tendu (fourniture)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Toile de verre (forfait)");
insert into ComboBoxItems(categorie, libelle) values ("travaux","Toile de verre et mise en peinture");

insert into ComboBoxItems(categorie, libelle) values ("etage","Rez-de-Chaussée");
insert into ComboBoxItems(categorie, libelle) values ("etage","Rez-de-Jardin");
insert into ComboBoxItems(categorie, libelle) values ("etage","1er étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","3ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","2ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","4ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","5ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","6ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","7ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","8ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","9ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","10ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","11ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","12ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","13ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","14ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","15ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","16ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","17ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","18ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","19ème étage");
insert into ComboBoxItems(categorie, libelle) values ("etage","Sous sol");
insert into ComboBoxItems(categorie, libelle) values ("etage","1er Sous sol");
insert into ComboBoxItems(categorie, libelle) values ("etage","2ème Sous sol");
insert into ComboBoxItems(categorie, libelle) values ("etage","1er étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","2ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","3ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","4ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","5ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","6ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","7ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","8ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","9ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","10ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","11ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","12ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","13ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","14ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","15ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","16ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","17ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","18ème étage (Palier)");
insert into ComboBoxItems(categorie, libelle) values ("etage","19ème étage (Palier)");