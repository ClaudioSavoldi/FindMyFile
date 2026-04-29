//STAGE1
//- Permettere di passare come argomenti, in questo ordine:
//-la cartella in cui eseguire la ricerca (opzionale, altrimenti si prende quella corrente)
//- il filtro di ricerca (opzionale, se non inserito si cercano tutti i file)
//- Supportare filtri standard come filtri * e ? (es. *.pdf)
//- Procedere alla ricerca nella sola cartella indicata
//- Progressivamente visualizzare il percorso completo dei file trovati
//- Alla fine indicare il numero di file trovati
//-------------------------------

//STAGE2
//Accettare o meno l'opzione -r
//  - Se presente, eseguire la ricerca anche nelle sotto-cartelle (applicando lo stesso filtro)Accettare o meno     l'opzione -r
//- Se presente, eseguire la ricerca anche nelle sotto-cartelle (applicando lo stesso filtro)
//---------------------------------

//STAGE3
//- Accettare l'opzione -h per stampare una breve guida dell'uso dell'applicazione
//- Visualizzare un errore se vi sono altri argomenti... visualizzare a sua volta la guida- Accettare l'opzione -h per stampare una breve guida dell'uso dell'applicazione
//- Visualizzare un errore se vi sono altri argomenti... visualizzare a sua volta la guida
//---------------------------------


// Se viene passato -h mostro la guida e termino il programma
if (args.Contains("-h"))
{
    PrintHelp();
    return;
}

Console.WriteLine("Modalità di ricerca");
Console.WriteLine("====================================");

// Recupero path, filtro e opzione dagli argomenti
var path = GetPath(args);
var searchPattern = GetSearchPattern(args);
var searchOption = GetSearchOption(args);

// Verifico che la cartella esista prima di eseguire la ricerca
if (!Directory.Exists(path))
{
    Console.WriteLine($"Errore: la cartella '{path}' non esiste.");
    PrintHelp();
    return;
}

// Avvio ricerca file secondo i parametri selezionati
SearchFiles(path, searchPattern, searchOption);

//-----------------Metodi-----------------------------
void PrintHelp()
{
    Console.WriteLine("""
    Guida utilizzo:

    FindMyFile [cartella] [filtro] [-r]
    FindMyFile -h

    cartella    opzionale: cartella in cui cercare
    filtro      opzionale: filtro tipo *.txt, *.pdf, file?.docx
    -r          opzionale: cerca anche nelle sottocartelle
    -h          mostra questa guida
    """);
}
//-----------------------------------------------------
string GetPath(string[] args)
{
    return args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
}

string GetSearchPattern(string[] args)
{
    return args.Length > 1 ? args[1] : string.Empty;
}

SearchOption GetSearchOption(string[] args)
{
    return args.Contains("-r")
        ? SearchOption.AllDirectories
        : SearchOption.TopDirectoryOnly;
}
//-----------------------------------------------------
void SearchFiles(string path, string searchPattern, SearchOption searchOption)
{
 
    Console.WriteLine($"Cartella: {path}");
    Console.WriteLine($"Filtro: {searchPattern}");
    Console.WriteLine($"Ricorsiva: {searchOption == SearchOption.AllDirectories}");
    Console.WriteLine("-----------------------------");

    // EnumerateFiles restituisce i file progressivamente senza caricarli tutti in memoria
    var files = Directory.EnumerateFiles(path, searchPattern, searchOption);

    int counter = 0;

    foreach (var file in files)
    {
        Console.WriteLine(file);
        counter++;
    }

    Console.WriteLine("-----------------------------");
    Console.WriteLine($"Numero di file trovati: {counter}");
}
