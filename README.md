# ![main_full_cropped](https://github.com/user-attachments/assets/d9e9d56d-baff-47f6-aaf7-4c97e2a8ee79) C# Application Météo

Bienvenue dans ce mini-projet en C# (C-Sharp, C-Hash, .NET) qui se sert d'une API pour receuillir quelques données météo (reçues donc en JSON).

## Installation
- Pré-requis :
  - .NET (dotNET) : https://dotnet.microsoft.com/en-us/download *(redémarrage nécéssaire post-installation.)*

Exécutez ces deux lignes 
```bash
git clone https://github.com/MARQUESDINISJoaoGabriel/C-HASH_MeteoAPI
cd C-HASH_MeteoAPI/
```

## Utilisation
`dotnet run Program.cs`<br>

*Exécuter .\Program.cs\ est nécéssaire afin d'éviter les confusions avec le fichier `WeatherData.cs`*

# DOCUMENTATION SUPP. 

## API (Ver. 2.0)
Ce projet utilise l'API Open-Meteo.com (https://open-meteo.com/en/docs), compris en `string`, le lien comporte `&latitude=` et `&longitude=`, ces deux valeurs sont modifiée dans mon algorithme.<br> 

La réponse est parsée en différentes données : <br>
```
- current_weather     (Données actuelles de météo, incluant...)
  - temperature       (Température en °C)
  - wind_speed        (Vitesse du vent en km/h)
- isday               (Booléen Vrai ou Faux selon la donnée `timezone` qui interprète s'il fait jour ou nuit)
- precipitation       (Données de précipitations en mm (instantané, données de pluies en ajout pour la prochaine version (2.1))
- cloudcover          (Pourcentage de couverture nuageuse sur le point.)
```

*D'autres données plus spécifiques seront rajoutées dans les versions ultérieures.*

## MENU (Ver. 2.0)
En console, j'ai décidé de créer un menu de selection (donc en POO) avec (pour cette version 2.0) les choix suivants :<br>

```
\- (1)     Insertion de la latitude et longitude manuelle.
\- (2)     Utilisation simple dans une liste de quelques capitales (Paris, Londres, Lisbonne, Tokyo, ...)
\- (3)     Options (Pour la 3.0, contiendra les configurations pour obtenir : des données spécifiques ou non, changement de format (°C ou °F)
\- (4)     Quitter
```
