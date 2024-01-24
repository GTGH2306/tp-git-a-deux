# tp-git-a-deux

## Comment utiliser le programme:
Il suffit d'executer src/Program.cs avec une console supportant .NET
La version que nous avons utilisé est .NET 6.0

## Dépendances
La seule dépendance est Newtonsoft.json

## Execution
Lorsque vous lancerez le programme dans une console, celui-ci vous demandera les noms est prénoms de plusieurs personnes.
La saisie ne peut être identique à une personne déjà saisie.
Le minimum de personnes à saisir est 3 par défaut, vous pouvez changer ça en modifiant la variable minPeople de la fonction SaisieListeConsole.
Une fois le minimum de personnes à ajouter atteint, le programme demandera si vous souhaitez continuer.
Le programme va vous demander si vous souhaitez trier la liste par noms ou par prenoms.
Le programme va vous demander si vous souhaitez sauvegarder la liste sous forme d'un fichier JSON
Le cas échéant le fichier JSON ce retrouvera dans ./src/bin/Debug/net6.0/save.json