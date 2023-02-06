# Dekra-Testing

Exercice 1 : [Algo][C#] Analyse et transformation d'algorithme JS vers C#
Question => Que fait l'algorithme JS ?
Réponse 1 => L'algorithme JS permet de retourner la liste
des gammes de Véhicules avec leur score ordonné du plus grand au plus petit correspondant à un Véhicule
=> Voir Solution dekra-coding-game-1


Exercice 2 : [DDD][C#] consistance ValueObject
Question => Ce Value Object n'est pas consistant. Proposer le correctif.
Réponse => Une proposition de l'implémentation d'une Value Objects est la classe Abstraite ValueObject qui est héritée par EmailAddress
           au sein de la classe EmailAddress
=> Voir Solution dekra-coding-game-2


Exercice 3 : [Perf][Maintenabilité][C#] optimisation de code
Situation => La méthode GetAllMyPayloads peut etre optimisée. Détailler les problemes identifiés, proposer une réponse C# optimisée.
Détails des problème => 
  1- La ligne 37 est marquée par une erreur : var values = myRepo.getAll();
  2- La ligne 37 est marquée par une erreur : var filteredList = new List<MyObject>;
  
Proposition de solution optimisée :
// Utilisation de Linq pour optimiser la requête
var filteredList = values.Where(x => x.Payload.SomefilterableString == filter).ToList();

// A la place de :
var filteredList = new List<MyObject>();
foreach (var value in values)
{
    if (value.Payload.SomefilterableString == filter)
        filteredList.Add(value);
}
=> Voir Solution dekra-coding-game-3


Exercice 4 : [DDD][C#] Construction from scratch
Question 
Proposer une représentation DDD en utilisant le langage C# pour materialiser une réponse a cet énoncé.
=> Voir solution dekra-coding-game-4


Exercice 5: Exercice 5 : [Test unitaire][C#] pertinence de test
=> Voir Solution dekra-coding-game-5
