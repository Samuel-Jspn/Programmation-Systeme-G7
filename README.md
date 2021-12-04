# Easy Save Groupe 7

[![C#](https://img.shields.io/badge/c%23%20-%23239120.svg?&style=for-the-badge&logo=c-sharp&logoColor=white)](C#) [![Markdown](https://img.shields.io/badge/markdown-%23000000.svg?&style=for-the-badge&logo=markdown&logoColor=white)](Markdown) [![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](.NET) [![GitHub](https://img.shields.io/badge/github%20-%23121011.svg?&style=for-the-badge&logo=github&logoColor=white)](GitHub) [![VisualStudio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?&style=for-the-badge&logo=visual-studio&logoColor=white)](VisualStudio)

Ce fichier fera office de document utilisateur pour notre projet. Il va permettre à n'importe quel utilisateur de comprendre l'utilisation de notre application. 

1. [Features](#Features)
2. [Installation](#Installation)
3. [Utilisation](#Utilisation)
    1. [Backup_Infos](#Backup_Infos)
4. [Release_Notes](#Release_Notes)

## Features

- Choix de la langue (Français ou anglais)
- Choix de sauvegarde
-- Dossier ou Fichier
-- Full ou Différentielle
- Fichiers de logs journaliers

>Chacun des étapes est décrite dans la console si jamais vous ne savez plus comment faire.

## Installation

Il faut vous rendre sur notre [repository Github](https://github.com/Samuel-Jspn/Programmation-Systeme-G7) et télécharger le code de la branche main.
Sur votre machine, il faut installer Visual studio et .NET (les liens sont en haut de la page)

## Utilisation

Lors du lancement du programme, il vou sera demandé de choisir entre Français et Anglais.
Par la suite il vous sera demandé d'entrer les informations nécessaire à la Sauvegarde.

### Backup_Infos

L'utilisateur devra  remplir dans l'ordre :

1. Fichier ou Dossier (à sauvegarder)
2. Nom de la backup
3. Lien du fichier ou dossier a sauvegarder
4. Destination de la sauvegarde
5. Type de sauvegarde (Full ou différentielle)

Une fois toutes ces informations rentrées, le programme effectue la sauvegarde puis vous notifie du succès ou non de cette dernière.

# Release_Notes

## [2.1] - 23-11-2021
### Modification
- Finalisation des logs d'état et journaliers

## [2.0] - 23-11-2021
### Ajout
- Logs d'état et journaliers
- Ajout Multilingue (Anglais - Français)

## [1.2] - 22-11-2021
### Ajout
- Recupération de l'extension de fichier
- Ajout fonctionnalité de sauvegarde de **dossier**
- Ajout d'une limite du nombre de sauvegardes

## [1.1] - 22-11-2021
### Ajout
- Verification chemin d'origine et de destination
- Choix du type de sauvegarde
- Création sauvegarde complète

### Projet Programmation Système par Elise, Sam & Amaury
[![Cesi](https://www.cesi.fr/wp-content/uploads/2018/11/logo-CESI.png)](https://www.cesi.fr)
