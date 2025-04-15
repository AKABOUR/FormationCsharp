// See https://aka.ms/new-console-template for more information

Console.WriteLine(string.Join(" ", NombresPairs()));

Console.ReadKey();

static IEnumerable<int> NombresPairs()
{
    yield return 1;
    yield return 2;
    yield return 3;
}