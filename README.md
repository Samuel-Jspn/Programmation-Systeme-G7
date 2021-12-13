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

Vous pouvez basculer entre Anglais et Français à tout moment grâce aux drapeaux situés à gauche de l'interface.
Dans les paramètres vous pouvez choisir le type de fichier à crypter (txt seulement actuellement).
Définir un logiciel métier qui va bloquer les sauvegarde si il est lancé.

→ Pour sauvegarder un fichier, vous pourrez choisir entre une sauvegazrde complète ou séquentielle.
→ Sauvegarder un fichier ou un dossier.
→ Sélectionner le chemin de source (fichier ou dossier) du document 
→ Séléctionner le chemin de destination du document

### Backup_Infos

L'utilisateur devra  remplir dans l'ordre :

1. Type de sauvegarde (Full ou différentielle)
2. Fichier ou Dossier (à sauvegarder)
3. Nom de la backup
4. Lien du fichier ou dossier a sauvegarder
5. Destination de la sauvegarde

Une fois toutes ces informations rentrées, le programme effectue la sauvegarde puis vous notifie du succès ou non de cette dernière.

# Release_Notes

## [2.2] - 13-12-2021
### Modification
- Modification checkBox. permet une seule CheckBox séléctionnée
- Ajout choix Dossier
- Chemin à séléctionner adaptatif en fonction de la checkBox cochée.

## [2.1] - 08-12-2021
### Ajout
- Bouton OpenFile, permet la selection d'un fichier sans rentrer le chemin à la main

## [2.0] - 06-12-2021
### Ajout
- Release Version 2.0

## [1.3] - 05-12-2021
### Modification
- Modification infos des logs
- Modification des boutons sur l'écran principal

### Ajout
- Ajout des pages paramètres, page principale, page de sauvegardes

## [1.2] - 04-12-2021
### Ajout
- Logiciel de Cryptographie
- Menu principal V1
- Multilingue complet sur les pages existantes (avec les drapeaux)

## [1.1] - 23-11-2021
### Modification
- Finalisation des logs d'état et journaliers

## [1.0] - 23-11-2021
### Ajout
- Release Version 1.0
- Logs d'état et journaliers
- Ajout Multilingue (Anglais - Français)

## [0.2] - 22-11-2021
### Ajout
- Recupération de l'extension de fichier
- Ajout fonctionnalité de sauvegarde de **dossier**
- Ajout d'une limite du nombre de sauvegardes

## [0.1] - 22-11-2021
### Ajout
- Verification chemin d'origine et de destination
- Choix du type de sauvegarde
- Création sauvegarde complète

### Projet Programmation Système par Elise, Sam & Amaury
[![Cesi](https://www.cesi.fr/wp-content/uploads/2018/11/logo-CESI.png)](https://www.cesi.fr)
