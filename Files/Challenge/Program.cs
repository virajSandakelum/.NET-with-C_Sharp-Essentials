const string folder = "FileCollection";
const string outputFile = "results.txt";

long EXCELFileCount = 0;
long WORDFileCount = 0;
long POWERPOINTFileCount = 0;
long EXCELFileSize = 0;
long WORDFileSize = 0;
long POWERPOINTFileSize = 0;
long totalFiles = 0;
long totalSize = 0;

bool IsOfficeFile(string filename)
{
    if (filename.EndsWith(".xlsx") || filename.EndsWith(".docx")
        || filename.EndsWith(".pptx"))
        return true;
    return false;
}

DirectoryInfo di = new DirectoryInfo(folder);

foreach (FileInfo fi in di.EnumerateFiles())
{
    if (IsOfficeFile(fi.Name))
    {
        totalFiles++;
        totalSize += fi.Length;
        if (fi.Name.EndsWith(".xlsx"))
        {
            EXCELFileCount++;
            EXCELFileSize += fi.Length;
        }
        if (fi.Name.EndsWith(".docx"))
        {
            WORDFileCount++;
            WORDFileSize += fi.Length;
        }
        if (fi.Name.EndsWith(".pptx"))
        {
            POWERPOINTFileCount++;
            POWERPOINTFileSize += fi.Length;
        }
    }
}


using (StreamWriter sw = File.CreateText(outputFile))
{
    sw.WriteLine($"Total Files: {totalFiles}");
    sw.WriteLine($"Excel Count: {EXCELFileCount}");
    sw.WriteLine($"Word Count: {WORDFileCount}");
    sw.WriteLine($"PowerPoint Count: {POWERPOINTFileCount}");
    sw.WriteLine($"Total Size: {totalSize:N0}");
    sw.WriteLine($"Excel Size: {EXCELFileSize:N0}");
    sw.WriteLine($"Word Size: {WORDFileSize:N0}");
    sw.WriteLine($"PowerPoint Size: {POWERPOINTFileSize:N0}");
}
