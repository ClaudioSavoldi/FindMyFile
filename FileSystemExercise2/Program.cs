


// Cartella base su cui lavorare
var basePath = @"C:\Users\ClaudioSavoldi\Desktop\test2";

// Creo i percorsi delle sottocartelle
var inputPath = Path.Combine(basePath, "input");
var backupPath = Path.Combine(basePath, "backup");
var archivePath = Path.Combine(basePath, "archive");

Console.WriteLine($"Base path: {basePath}");
Console.WriteLine($"Input: {inputPath}");
Console.WriteLine($"Backup: {backupPath}");
Console.WriteLine($"Archive: {archivePath}");

// Creo la struttura delle cartelle
CreateFolders(inputPath, backupPath, archivePath);

// Creo due file di esempio nella cartella input
CreateSampleFiles(inputPath);

// Copio i file dalla cartella input alla cartella backup
CopyFiles(inputPath, backupPath);

// Sposto i file dalla cartella input alla cartella archive
MoveFiles(inputPath, archivePath);

void CreateFolders(string inputPath, string backupPath, string archivePath)
{
    Directory.CreateDirectory(inputPath);
    Directory.CreateDirectory(backupPath);
    Directory.CreateDirectory(archivePath);

    Console.WriteLine("Cartelle create correttamente.");
}

void CreateSampleFiles(string inputPath)
{
    File.WriteAllText(Path.Combine(inputPath, "documento1.txt"), "Primo file di prova");
    File.WriteAllText(Path.Combine(inputPath, "documento2.txt"), "Secondo file di prova");

    Console.WriteLine("File creati nella cartella input.");
}

void CopyFiles(string inputPath, string backupPath)
{
    // Recupero tutti i file txt presenti nella cartella input
    var files = Directory.EnumerateFiles(inputPath, "*.txt");

    foreach (var file in files)
    {
        // Costruisco il percorso finale mantenendo il nome originale del file
        var destination = Path.Combine(backupPath, Path.GetFileName(file));
        File.Copy(file, destination, true);
    }

    Console.WriteLine("File copiati in backup.");
}

void MoveFiles(string inputPath, string archivePath)
{
    // Recupero nuovamente i file ancora presenti in input
    var files = Directory.EnumerateFiles(inputPath, "*.txt");

    foreach (var file in files)
    {
        // Sposto ogni file nella cartella archive
        var destination = Path.Combine(archivePath, Path.GetFileName(file));
        File.Move(file, destination, true);
    }

    Console.WriteLine("File spostati in archive.");
}