// See https://aka.ms/new-console-template for more information

#region Valores Aleatorios

Console.WriteLine("Generador de Numeros Aleatorios!");
Console.WriteLine("Introduzca la cantidad de elementos por defecto 5: ");
int cantidadElementos = 5;

if (int.TryParse(Console.ReadLine(), out int cant))
{
    cantidadElementos = Math.Clamp(cant, 1, 20);
}

Random random = new Random();
HashSet<int> numGenerados = new HashSet<int>();

while (numGenerados.Count < cantidadElementos)
{
    int numAleatorio = random.Next(1, 101);
    numGenerados.Add(numAleatorio);
}

Console.WriteLine("Numeros aleatorios : ");

foreach (int num in numGenerados)
{
    Console.WriteLine(num);
}

#endregion

#region Numeros Primos

static bool EsNumeroPrimo(int numero)
{
    if (numero <= 1)
        return false;
    if (numero <= 3)
        return true;

    if (numero % 2 == 0 || numero % 3 == 0)
        return false;

    for (int i = 5; i * i <= numero; i += 6)
    {
        if (numero % i == 0 || numero % (i + 2) == 0)
            return false;
    }

    return true;
}


Console.WriteLine("Generador de números primos");
Console.Write("Introduce la cantidad de numeros primos a generar por defecto 9 : ");
int cantidadPrimos = 9;

if (int.TryParse(Console.ReadLine(), out int cantidades))
{
    cantidadPrimos = Math.Max(cantidades, 1);
}

Console.WriteLine($"Los primeros {cantidadPrimos} numeros primos son :");

int numero = 2;
int primosEncontrados = 0;

while (primosEncontrados < cantidadPrimos)
{
    if (EsNumeroPrimo(numero))
    {
        Console.Write(numero + " ");
        primosEncontrados++;
    }
    numero++;
}

Console.WriteLine();


#endregion


#region Emulador de Cajero Automatico

var denominaciones = new Dictionary<string, int>()
        {
            { "2000 pesos", 0 },
            { "1000 pesos", 0 },
            { "500 pesos", 0 },
            { "200 pesos", 0 },
            { "100 pesos", 0 },
            { "5000 pesos", 0 },
            { "2500 pesos", 0 },
            { "1300 pesos", 0 },
            { "900 pesos", 0 },
            { "600 pesos", 0 },
            { "2800 pesos", 0 },
            { "1500 pesos", 0 },
            { "800 pesos", 0 },
        };

Console.WriteLine("Cajero Automático");
Console.Write("Introduce la cantidad a retirar: ");
decimal cantidad = decimal.Parse(Console.ReadLine()!);

decimal cantidadRestante = cantidad;

foreach (var denominacion in denominaciones)
{
    if (cantidadRestante >= decimal.Parse(denominacion.Key.Split(' ')[0]))
    {
        int cantidadDenominacion = (int)(cantidadRestante / decimal.Parse(denominacion.Key.Split(' ')[0]));
        denominaciones[denominacion.Key] = cantidadDenominacion;
        cantidadRestante -= cantidadDenominacion * decimal.Parse(denominacion.Key.Split(' ')[0]);
    }
}

Console.WriteLine("\nCantidad de billetes y monedas:");
foreach (var denominacion in denominaciones)
{
    if (denominacion.Value > 0)
    {
        Console.WriteLine($"{denominacion.Value} | {denominacion.Key}");
    }
}

#endregion


#region Coincidencias

static bool EsNumPrimo(int numero)
{
    if (numero <= 1)
        return false;
    if (numero <= 3)
        return true;

    if (numero % 2 == 0 || numero % 3 == 0)
        return false;

    for (int i = 5; i * i <= numero; i += 6)
    {
        if (numero % i == 0 || numero % (i + 2) == 0)
            return false;
    }

    return true;
}


static List<int> GenerarNumerosPrimos(int cantidad)
{
    List<int> primos = new List<int>();
    int numero = 2;

    while (primos.Count < cantidad)
    {
        if (EsNumPrimo(numero))
        {
            primos.Add(numero);
        }
        numero++;
    }

    return primos;
}

static List<int> EncontrarCoincidencias(List<int> aleatorios, List<int> primos)
{
    List<int> coincidencias = new List<int>();

    foreach (int numeroAleatorio in aleatorios)
    {
        if (primos.Contains(numeroAleatorio))
        {
            coincidencias.Add(numeroAleatorio);
        }
    }

    return coincidencias;
}


static List<int> GenerarFibonacci(int cantidad)
{
    List<int> fibonacci = new List<int>();

    if (cantidad >= 1)
    {
        fibonacci.Add(0);
    }
    if (cantidad >= 2)
    {
        fibonacci.Add(1);
    }

    for (int i = 2; i < cantidad; i++)
    {
        int nextFibonacci = fibonacci[i - 1] + fibonacci[i - 2];
        fibonacci.Add(nextFibonacci);
    }

    return fibonacci;
}


// Generar numeros aleatorios 

List<int> aleatorios = new List<int>();

// Listado de numeros primos generados

List<int> primos = GenerarNumerosPrimos(100);

// Encuentra coincidencias entre numeros primos y aleatorios
List<int> coincidencias = EncontrarCoincidencias(aleatorios, primos);

if (coincidencias.Count > 0)
{
    // Encuentre el mayor valor entre las coincidencias
    int maxCoincidencia = coincidencias.Max();

    // Lista de numeros Fibonacci con la cantidad de elementos igual al maximo valor de coincidencia
    List<int> fibonacci = GenerarFibonacci(maxCoincidencia);

    Console.WriteLine("Numeros primos contenidos en el conjunto de numeros aleatorios:");
    foreach (int primo in coincidencias)
    {
        Console.Write($"{primo} ");
    }

    Console.WriteLine("\nLista de numeros Fibonacci con la cantidad de elementos igual al mayor valor de coincidencia:");
    foreach (int fib in fibonacci)
    {
        Console.Write($"{fib} ");
    }
}
else
{
    Console.WriteLine("No hay coincidencias entre numeros primos y aleatorios.");
}




#endregion


Console.ReadLine();