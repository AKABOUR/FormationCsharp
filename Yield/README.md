# Qu’est-ce que yield en C# ?  
Le mot-clé yield permet de retourner les éléments d'une collection un par un, à la demande, sans allouer de mémoire supplémentaire pour une liste intermédiaire.

Il est utilisé dans les méthodes d’itération, c’est-à-dire qui retournent IEnumerable ou IEnumerator.

1. Il existe deux variantes :  
- ✅ yield return : pour retourner un élément  
- ⛔ yield break : pour arrêter l’itération

2. Historique  
- Introduit avec C# 2.0 (2005).
- Avant cela, il fallait manuellement créer des classes d’itérateurs.
- L’objectif était de simplifier l’implémentation de collections personnalisées ou de parcours paresseux (lazy evaluation).

3. Avantages de yield  
Avantage : Description  
✅ Lazy loading : Les éléments sont produits à la volée
✅ Mémoire optimisée :	Pas besoin de liste temporaire
✅ Code simplifié : Évite d’écrire des classes d’itération complexes
✅ Lisibilité accrue : Code linéaire plus simple à maintenir

4. Limitations  
- Ne peut être utilisé que dans des méthodes retournant IEnumerable ou IEnumerator
- Pas possible dans des lambdas ou des méthodes anonymes
- Moins performant si tu veux accéder plusieurs fois aux mêmes éléments (pas de cache automatique)

# Résumé
Élément :	Description
- yield return :	Retourne un élément paresseusement
- yield break :	Interrompt l’itération
- Avantages :	Simple, mémoire efficace, lecture fluide
- Depuis :	C# 2.0 (2005)
- Utilisé pour :	Parcours personnalisé, traitement paresseux, transformation de collections


# 🎨 Schéma illustré de yield return

Imaginons cette méthode :  

`public static IEnumerable<int> CompterJusqua3()
{
    yield return 1;
    yield return 2;
    yield return 3;
}
`   
Et ce code d’appel :  

`foreach (var n in CompterJusqua3())
{
    Console.WriteLine(n);
}
`  

🔄 Illustration étape par étape :  

Appel de la méthode CompterJusqua3() => crée un itérateur     
         ↓  
Appel MoveNext() (1er passage)  
         ↓  
➡ yield return 1 → retourne 1  
         ↓  
Appel MoveNext() (2e passage)  
         ↓  
➡ yield return 2 → retourne 2  
         ↓  
Appel MoveNext() (3e passage)  
         ↓  
➡ yield return 3 → retourne 3  
         ↓  
Appel MoveNext() (fin) → termine l’itération  

⚠️ Le code n'est pas exécuté d’un coup : chaque yield return reprend là où il s’était arrêté !  

# yield return vs LINQ .Where().Select()
🔍 Objectif : retourner les carrés des nombres pairs
✅ Avec yield
`public static IEnumerable<int> CarresDesPairs(IEnumerable<int> source)
{
    foreach (var n in source)
    {
        if (n % 2 == 0)
            yield return n * n;
    }
}`  

✅ Avec LINQ  
`var result = source.Where(n => n % 2 == 0)
                   .Select(n => n * n);`  

Caractéristique :	yield return :	LINQ .Where().Select()  
✅ Lisibilité :	Moyenne pour gros traitements	: Très lisible et expressif  
✅ Contrôle :	Plus de contrôle (logique complexe) :	Moins de contrôle  
✅ Performance : 	Légèrement plus rapide (moins d'allocs) :	Peut être plus lent  
✅ Lazy / Paresseux :	Oui :	Oui  
✅ Chaînage facile :	Moins facile :	Oui, très facile  

## 💻 Petit exercice interactif (en console)
On va créer un générateur de nombres Fibonacci paresseux avec yield return.  

`public static IEnumerable<int> Fibonacci()
{
    int a = 0;
    int b = 1;  
    while (true)
    {
        yield return a;
        int temp = a;
        a = b;
        b = temp + b;
    }
}
`  

Et l’utiliser :

`
foreach (var n in Fibonacci())
{
    if (n > 100) break;
    Console.Write(n + " ");
}`  

💡 Résultat : 0 1 1 2 3 5 8 13 21 34 55 89