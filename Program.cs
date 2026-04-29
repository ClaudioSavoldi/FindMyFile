//- Permettere di passare come argomenti, in questo ordine:
//-la cartella in cui eseguire la ricerca (opzionale, altrimenti si prende quella corrente)
//- il filtro di ricerca (opzionale, se non inserito si cercano tutti i file)
//- Supportare filtri standard come filtri * e ? (es. *.pdf)
//- Procedere alla ricerca nella sola cartella indicata
//- Progressivamente visualizzare il percorso completo dei file trovati
//- Alla fine indicare il numero di file trovati
//-------------------------------
//Accettare o meno l'opzione -r
//- Se presente, eseguire la ricerca anche nelle sotto-cartelle (applicando lo stesso filtro)Accettare o meno l'opzione -r
//- Se presente, eseguire la ricerca anche nelle sotto-cartelle (applicando lo stesso filtro)


//prendo la cartella da args oppure uso quella corrente se non è stata passata
var path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
//il filtro sara args[1] se inserito, altrimenti cerco tutti i file
var searchPattern = args.Length > 1 ? args[1] : string.Empty; //oppure "*"

var searchOption = args.Contains("-r") ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

Console.WriteLine(path);
Console.WriteLine("-----------------------------");

//var files = Directory.GetFiles(path, searchPattern);
//Scelgo EnumarateFiles per evitare di caricare tutto in memoria, 
var files = Directory.EnumerateFiles(path, searchPattern,searchOption);

//i file vengono generati e consumati uno per volta nel foreach.
int counter = 0;
foreach (var file in files)
{
    Console.WriteLine(file);
    counter++;
}

//Non posso usare il .lenght perchè files non è piu un array
//Console.WriteLine(files.Count());
Console.WriteLine($"Numero di file trovati:{counter} ");