# Mastermind - Exo récap

## Objectif
Réaliser une application console pour permettre de jouer au mastermind.

## Fonctionnement du jeu
Le programme génère un ensemble de 4 valeurs numériques (de 0 à 9) que l'utilisateur doit trouver en un maximum de 12 essais.

Après chaque proposition, le programme indique à l'utilisateur la correspondance avec l'ensemble a trouvé : 
- Aucune valeur correcte
- X valeur sont corrects mais mal placé
- X valeur sont corrects et bien placé
- Toutes les valeurs sont corrects et bien placées 🎉

Si toutes les valeurs sont trouvées, le jeu s'arrête et le score du joueur est indiqué. Si les valeurs ne sont pas trouvées après les 12 essais, celui-ci a perdu et le programme affiche l'ensemble de valeur qui était attendu.

## Bonus
Ajouter des modes de difficulté : 
- Facile : 4 éléments / 6 valeurs / pas de limite d'essai
- Normal : 4 éléments / 10 valeurs / 12 essais
- Difficile : 5 éléments / 16 valeurs / 10 essais
- Custom : Tous les paramètres peuvent être modifiés par l'utilisateur.