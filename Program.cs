using System.Linq;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
//PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

Console.WriteLine("------------------------------------------------------------------------------------------");

Eruption primeraErupcionChile = eruptions.Where(p => p.Location == "Chile").OrderBy(a => a.Year).First();
PrintEachObjeto(primeraErupcionChile, "La primera erupción volcánica en Chile ocurrió en");

Console.WriteLine("------------------------------------------------------------------------------------------");

Eruption primeraErupcionHawaii = eruptions.Where(p => p.Location == "Hawaiian Is").OrderBy(a => a.Year).FirstOrDefault(a => a.Location != "" || a.Location == "");
PrintEachObjeto(primeraErupcionHawaii, "La primera erupción volcánica en Hawaii ocurrió en", "No se ha encontrado ninguna erupción en Hawaiian Is");

Console.WriteLine("------------------------------------------------------------------------------------------");

Eruption primeraErupcionNuevaZelanda = eruptions.Where(p => p.Location == "New Zealand").OrderBy(a => a.Year > 1900).First();
PrintEachObjeto(primeraErupcionNuevaZelanda, "El año donde ocurrió la primera erupción en Nueva Zelanda posterior a 1900", "No se ha encontrado ninguna erupción en Nueva Zelanda posterior a 1900");

Console.WriteLine("------------------------------------------------------------------------------------------");

IEnumerable<Eruption> alturaVolcanes = eruptions.Where(al => al.ElevationInMeters > 2000).ToList();
PrintEach(alturaVolcanes, "Volcanes con erupciones de más de 2000 metros de altura.");

Console.WriteLine("------------------------------------------------------------------------------------------");

IEnumerable<Eruption> listaVolcanesL = eruptions.Where(n => n.Volcano.Contains("L")).ToList();
int cantidadL = listaVolcanesL.Count();
PrintEach(listaVolcanesL, "Volcanes que empiecen con L", "Cantidad de erupciones volcánicas encontradas", cantidadL);

Console.WriteLine("------------------------------------------------------------------------------------------");

int volcanMasAlto = eruptions.Max(al => al.ElevationInMeters);
PrintEachEntero(volcanMasAlto, "El volcán más alto tiene una altura de");

Console.WriteLine("------------------------------------------------------------------------------------------");

var nombreVolcan = eruptions.Where(al => al.ElevationInMeters == volcanMasAlto).Select(volcan => new { volcan.Volcano, volcan.ElevationInMeters });
PrintEachVolcan(nombreVolcan);

Console.WriteLine("------------------------------------------------------------------------------------------");

IEnumerable<string> listaVolcanes = eruptions.OrderBy(n => n.Volcano).Select(n => n.Volcano);
PrintEachVolcan(listaVolcanes, "Lista de todos los volcanes", "Nombre del Volcán");

Console.WriteLine("------------------------------------------------------------------------------------------");

IEnumerable<Eruption> erupcionAntesMil = eruptions.Where(a => a.Year < 1000).OrderBy(n => n.Volcano);
PrintEach(erupcionAntesMil, "Lista erupciones volcánicas antes del año 1000");

Console.WriteLine("------------------------------------------------------------------------------------------");

IEnumerable<string> erupcionAntesMilNombre = erupcionAntesMil.Select(n => n.Volcano);
PrintEachVolcan(erupcionAntesMilNombre, "Lista erupciones volcánicas antes del año 1000", "Nombre del Volcán");

Console.WriteLine("------------------------------------------------------------------------------------------");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "", string? msg2 = "", int? cantidad = 0)
{
    if (cantidad == 0)
    {
        Console.WriteLine("\n" + msg);
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }
    else
    {
        Console.WriteLine("\n" + msg);
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine($"{msg2}: {cantidad}");

    }
}

static void PrintEachObjeto(Eruption item, string msg = "", string? msg2 = "")
{
    if (item != null)
    {
        Console.WriteLine($"{msg} {item.Volcano} en el año {item.Year}");
    }
    else
    {
        Console.WriteLine($"{msg2}");
    }
}

static void PrintEachEntero(int cantidad, string msg = "")
{
    Console.WriteLine($"{msg}: {cantidad} metros");
}

static void PrintEachVolcan(IEnumerable<dynamic> items, string? msg = "", string? msg2 = "")
{
    if (items.Count() > 1)
    {
        Console.WriteLine($"\n{msg}\n");
        foreach (var item in items)
        {
            Console.WriteLine($"{msg2}: {item.ToString()}");
        }
    }
    else
    {
        Console.WriteLine($"El volcán más alto se llama {items.Select(n => n.Volcano).First()} y tiene una altura de {items.Select(n => n.ElevationInMeters).First()} metros");
    }
}

