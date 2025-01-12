namespace WebScrapingTribunalFiscal;
public class DownloadPdf
{
    private const string URL = "https://www.mef.gob.pe/contenidos/tribu_fisc/Tribunal_Fiscal/PDFS/";

    private readonly string _path;

    public DownloadPdf(string path)
    {
        _path = path;
    }

    public async Task Download(string year, string sala, string name)
    {
        string urlWeb = $"{URL}{year}/{sala}/{name}.pdf";

        string localPath = Path.Combine(_path, $"{name}.pdf");


        using var client = new HttpClient();

        try
        {
            // Descargar el PDF desde la URL
            var pdfBytes = await client.GetByteArrayAsync(urlWeb);

            // Guardar el PDF en una ruta local
            await File.WriteAllBytesAsync(localPath, pdfBytes);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }
}
