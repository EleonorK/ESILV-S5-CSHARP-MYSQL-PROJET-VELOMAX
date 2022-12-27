CREATE DATABASE IF NOT EXISTS VeloMax;
USE VeloMax;

DROP TABLE fidelio;
DROP TABLE adhesion;
DROP TABLE adresse;
DROP TABLE fournisseur;
DROP TABLE velo;
DROP TABLE piece;
DROP TABLE clients;
DROP TABLE commande;
DROP TABLE vente_velo;
DROP TABLE vente_piece;

CREATE TABLE IF NOT EXISTS velo(
id_velo INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_velo),
nom_velo VARCHAR(40) NOT NULL,
prix_velo VARCHAR(10) NOT NULL,
grandeur VARCHAR(40) NOT NULL,
ligne_velo VARCHAR (40) NOT NULL,
dateDebut_velo DATE NOT NULL,
dateFin_velo DATE,
stock_velo INT NOT NULL
);
ALTER TABLE velo AUTO_INCREMENT=100;

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
id_piece INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_piece),
id_siret INT NOT NULL,  FOREIGN KEY (id_siret) REFERENCES fournisseur(id_siret),
nom_piece VARCHAR(50) NOT NULL,
ref VARCHAR (50) NOT NULL, 
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
duree INT NOT NULL,
rabais VARCHAR(10) NOT NULL
);

CREATE TABLE IF NOT EXISTS clients(
id_clients INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_clients),
mdp_clients VARCHAR(50),
nom_clients VARCHAR(40),
prenom_clients VARCHAR(40),
nom_boutique VARCHAR(40),
id_adresse INT, FOREIGN KEY (id_adresse) REFERENCES adresse(id_adresse),
contact_clients VARCHAR(50),
couriel_clients VARCHAR(40),
adhesion BOOL NOT NULL,
nb_achat INT,
nb_cumul VARCHAR(10)
);
  
CREATE TABLE IF NOT EXISTS adhesion(
id_adhesion INT NOT NULL AUTO_INCREMENT, primary key (id_adhesion),
id_fidelio INT NOT NULL, FOREIGN KEY (id_fidelio) REFERENCES fidelio(id_fidelio),
id_clients INT NOT NULL, FOREIGN KEY (id_clients) REFERENCES clients(id_clients),
date_adhesion DATE,
date_expiration DATE
);
 
  
CREATE TABLE IF NOT EXISTS commande(
id_commande INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id_commande),
id_clients INT NOT NULL,  FOREIGN KEY (id_clients) REFERENCES clients(id_clients),
id_adresse INT, FOREIGN KEY (id_adresse) REFERENCES adresse(id_adresse),
date_commande DATE,
date_livraison DATE,
prix_commande VARCHAR(10) NOT NULL
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
 

INSERT INTO velo VALUES (101,'Kilimandjaro','569€','Adultes','VTT','2021/01/12','2025/01/12',12);
INSERT INTO velo VALUES (102,'NorthPole','329€','Adultes','VTT','2021/01/12','2025/01/12',50);
INSERT INTO velo VALUES (103,'MontBlanc','399€','Jeunes','VTT','2021/01/12','2025/01/12',2);
INSERT INTO velo VALUES (104,'Hooligan','199€','Jeunes','VTT','2021/01/12','2027/01/12',5);
INSERT INTO velo VALUES (105,'Orléans','229€','Hommes','Vélo de course','2021/01/12','2024/01/12',4);
INSERT INTO velo VALUES (106,'Orléans','229€','Dames','Vélo de course','2021/01/12','2029/01/12',21);
INSERT INTO velo VALUES (107,'BlueJay','349€','Hommes','Vélo de course','2021/01/12','2026/01/12',12);
INSERT INTO velo VALUES (108,'BlueJay','349€','Dames','Vélo de course','2021/01/12','2026/01/12',10);
INSERT INTO velo VALUES (109,'Trail Explorer','129€','Filles','Classique','2021/01/12','2023/01/12',7);
INSERT INTO velo VALUES (110,'Trail Explorer','129€','Garçons','Classique','2021/01/12','2028/01/12',2);
INSERT INTO velo VALUES (111,'Night Hawk','189€','Jeunes','Classique','2021/01/12','2021/01/12',1);
INSERT INTO velo VALUES (112,'Tierra Verde','199€','Hommes','Classique','2021/01/12','2029/01/12',3);
INSERT INTO velo VALUES (113,'Tierra Verde','199€','Dames','Classique','2021/01/12','2021/01/12',27);
INSERT INTO velo VALUES (114,'Mud Zinger I','199€','Jeunes','BMX','2021/01/12','2022/01/12',13);
INSERT INTO velo VALUES (115,'Mud Zinger II','279€','Adultes','BMX','2021/01/12','2021/01/12',1);



INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(1,'guidon','G7','1000','77€','2022/01/01','2022/10/01','5 jours',0);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(1,'Frein','F3','1001','89,99€','2022/01/01','2022/11/01','3 jours',6);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(1,'Dérailleur
Avant','DV7','1003','103,23€','2022/01/01','2022/10/025','9 jours',13);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(2,'guidon','G7','1004','68,63€','2022/01/01','2022/10/01','4 jours',3);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(2,'Roue avant','R45','1005','107,80€','2022/01/01','2022/10/01','6 jours',21);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(3,'cadre','C32','1006','121,98€','2022/01/01','2023/05/01','9 jours',1);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(3,'Réflecteurs','R02','1005','89,23€','2022/01/01','2022/12/01','4 jours',20);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(3,'ordinateur','O2','1006','280,32€','2022/01/01','2022/08/01','9 jours',2);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(2,'panier','G7','1007','36,78€','2022/01/01','2022/10/01','5 jours',6);
INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(1,'panier','S05','1008','25€','2022/01/01','2022/10/01','2 jours',4);INSERT INTO piece(id_siret,nom_piece,ref,num_pieceFournisseur,prix_piece,dateDebut_piece,dateFin_piece,delai_piece, stock_piece) VALUES(4,'ordinateur','O4','1009','189,65€','2022/01/01','2022/10/01','8 jours',3);

INSERT INTO fidelio VALUES(1,'Fidélio','15€',1,'5%');
INSERT INTO fidelio VALUES(2,'Fidélio Or','25€',2,'8%');
INSERT INTO fidelio VALUES(3,'Fidélio Platine','60€',2,'10%');
INSERT INTO fidelio VALUES(4,'Fidélio Max','100€',3,'12%');

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('2','2','2022/05/17','2022/05/20','123,98€');
insert into vente_piece values (1,5,3);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('3','3','2022/05/17','2022/05/20','302,98€');
insert into vente_piece values (2,4,2);
insert into vente_velo values (2,104,1);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('4','4','2022/05/17','2022/06/08','856,80€');
insert into vente_piece values (3,14,5);
insert into vente_velo values (3,110,3);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('9','9','2022/05/17','2022/06/01','1233,78€');
insert into vente_piece values (4,12,6);
insert into vente_velo values (4,108,8);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('7','7','2022/05/17','2022/05/22','236,00€');
insert into vente_velo values (5,102,2);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('2','2','2022/04/07','2022/04/16','156,00€');
insert into vente_velo values (6,101,1);

insert into commande (id_clients,id_adresse,date_commande,date_livraison,prix_commande) values ('1','1','2022/03/04','2022/03/13','1523,05€');
insert into vente_piece values (8,10,5);
insert into vente_piece values (8,6,4);
insert into vente_piece values (8,7,10);

update clients set nb_achat = 2 where id_clients = 2;
update clients set nb_cumul = '279,98€' where id_clients = 2;
update clients set nb_achat = 2 where id_clients = 7;
update clients set nb_cumul = '313,86€' where id_clients = 7;

update clients set nb_achat = 1 where id_clients = 9;
update clients set nb_cumul = '1233,78€' where id_clients = 9;

update commande set date_livraison='2022/05/29' where id_commande=10;

SELECT * FROM clients;
SELECT * FROM adresse;
SELECT * FROM piece;
SELECT * FROM velo;
SELECT * FROM fournisseur;
SELECT * FROM vente_piece;
SELECT * FROM adhesion;
SELECT * FROM fidelio;
SELECT * FROM commande