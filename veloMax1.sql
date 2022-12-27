CREATE DATABASE IF NOT EXISTS VeloMax;
USE VeloMax;

DROP TABLE adhesion;
DROP TABLE clients;
DROP TABLE commande;
DROP TABLE vente_velo;
DROP TABLE vente_piece;

CREATE TABLE IF NOT EXISTS velo(
id_velo VARCHAR(50) NOT NULL, PRIMARY KEY (id_velo),
nom_velo VARCHAR(40) NOT NULL,
prix_velo VARCHAR(10) NOT NULL,
grandeur VARCHAR(40) NOT NULL,
ligne_velo VARCHAR (40) NOT NULL,
dateDebut_velo DATE NOT NULL,
dateFin_velo DATE,
stock_velo INT NOT NULL
);

CREATE TABLE IF NOT EXISTS adresse(
id_adresse INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_adresse),
rue VARCHAR (255) NOT NULL,
ville VARCHAR (50) NOT NULL,
code_postal INT NOT NULL,
province VARCHAR (50) NOT NULL
);

CREATE TABLE IF NOT EXISTS fournisseur(
id_siret INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_siret),
id_adresse INT NOT NULL, FOREIGN KEY (id_adresse) REFERENCES adresse(id_adresse),
nom_entreprise VARCHAR(40) NOT NULL,
contact_fournisseur VARCHAR(50) NOT NULL,
libelle_fournisseur VARCHAR(10)
);

CREATE TABLE IF NOT EXISTS piece(
id_piece VARCHAR(50) NOT NULL, PRIMARY KEY (id_piece),
id_siret INT NOT NULL,  FOREIGN KEY (id_siret) REFERENCES fournisseur(id_siret),
num_pieceFournisseur INT NOT NULL,
prix_piece VARCHAR(10) NOT NULL,
description_piece VARCHAR(255),
dateDebut_piece DATE NOT NULL,
dateFin_piece DATE,
delai_piece VARCHAR(40),
stock_piece INT NOT NULL
);
 
  CREATE TABLE IF NOT EXISTS fidelio(
 id_fidelio INT,  PRIMARY KEY (id_fidelio),
 description_fidelio VARCHAR(255),
 cout VARCHAR(10) NOT NULL,
 duree VARCHAR (10) NOT NULL,
 rabais VARCHAR(10)
 );

  CREATE TABLE IF NOT EXISTS clients(
 id_clients INT NOT NULL, PRIMARY KEY (id_clients),
 mdp_clients VARCHAR(50),
 nom_clients VARCHAR(40),
 prenom_clients VARCHAR(40),
 nom_boutique VARCHAR(40),
 id_adresse INT, FOREIGN KEY (id_adresse) REFERENCES adresse(id_adresse),
 contact_clients VARCHAR(10),
 couriel_clients VARCHAR(40),
 nb_achat INT,
 nb_cumul INT
 );
  
  CREATE TABLE IF NOT EXISTS adhesion(
 id_adhesion INT, primary key (id_adhesion),
 id_fidelio INT, FOREIGN KEY (id_fidelio) REFERENCES fidelio(id_fidelio),
 id_clients INT NOT NULL, FOREIGN KEY (id_clients) REFERENCES clients(id_clients),
 date_adhesion DATE
 );
 
  
 CREATE TABLE IF NOT EXISTS commande(
 id_commande INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_commande),
 id_clients INT NOT NULL,  FOREIGN KEY (id_clients) REFERENCES clients(id_clients),
 id_adresse INT, FOREIGN KEY (id_adresse) REFERENCES adresse(id_adresse),
 date_commande DATE,
 date_livraison DATE
 );
 
 CREATE TABLE IF NOT EXISTS vente_velo(
 id_commande INT NOT NULL, FOREIGN KEY (id_commande) REFERENCES commande(id_commande),
 id_velo INT,  FOREIGN KEY (id_velo) REFERENCES velo(id_velo),
 qte_velo INT
 );
 
  CREATE TABLE IF NOT EXISTS vente_piece(
 id_commande INT NOT NULL, FOREIGN KEY (id_commande) REFERENCES commande(id_commande),
 id_piece INT,  FOREIGN KEY (id_piece) REFERENCES piece(id_piece),
 qte_piece INT
 );
 

 
