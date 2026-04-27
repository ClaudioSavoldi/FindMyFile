//- Permettere di passare come argomenti, in questo ordine:
//-la cartella in cui eseguire la ricerca (opzionale, altrimenti si prende quella corrente)
//  - il filtro di ricerca (opzionale, se non inserito si cercano tutti i file)
//- Supportare filtri standard come filtri * e ? (es. *.pdf)
//- Procedere alla ricerca nella sola cartella indicata
//- Progressivamente visualizzare il percorso completo dei file trovati
//- Alla fine indicare il numero di file trovati

var path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
var searchPattern = args.Length > 1 ? args[1] : string.Empty;

Console.WriteLine(path);
Console.WriteLine("-----------------------------");

var files = Directory.GetFiles(path, searchPattern);

//Directory.EnumerateFiles

foreach (var file in files)
{
    Console.WriteLine(file);
}

Console.WriteLine(files.Length);