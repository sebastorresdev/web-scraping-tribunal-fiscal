namespace WebScrapingTribunalFiscal;
using HtmlAgilityPack;
using System.Diagnostics;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void ButtonBrowse_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxDestination.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private async void ButtonDownload_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxUrl.Text))
        {
            MessageBox.Show("Ingrese una URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(comboBoxYear.Text))
        {
            MessageBox.Show("Seleccione un año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(comboBoxSala.Text))
        {
            MessageBox.Show("Seleccione una sala", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(textBoxDestination.Text))
        {
            MessageBox.Show("Seleccione una carpeta de destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        progressBar.Minimum = 0;
        progressBar.Value = 0;

        UpdateLog("Obteniendo nombres...");
        progressBar.Style = ProgressBarStyle.Marquee;

        var names = await GetNames();

        UpdateLog($"{names.Count} nombres encontrados");

        progressBar.Style = ProgressBarStyle.Continuous;
        progressBar.Maximum = names.Count;

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        UpdateLog("Iniciando descarga...");

        try
        {
            await DownloadPdf(names);

            stopwatch.Stop();

            var time = stopwatch.Elapsed;

            // Formateando el tiempo transcurrido (hh:mm:ss)
            string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);

            UpdateLog($"Completado en {formattedTime}");

            MessageBox.Show("Descarga completada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            UpdateLog($"Error:  {ex}");
        }
    }

    private async Task DownloadPdf(List<string> names)
    {
        var downloadPdf = new DownloadPdf(textBoxDestination.Text);

        var semaphore = new SemaphoreSlim(5); // Limita la concurrencia a 5 tareas

        var downloadTasks = names.Select(async name =>
        {
            await semaphore.WaitAsync();
            try
            {
                await downloadPdf.Download(comboBoxYear.Text, comboBoxSala.Text, name);
                Invoke(new Action(() =>
                {
                    progressBar.Value++;
                }));
            }
            catch (Exception ex)
            {
                UpdateLog($"Error: {ex.Message}");
            }
            finally
            {
                semaphore.Release();
            }
        }).ToList();

        await Task.WhenAll(downloadTasks);
    }

    private void UpdateLog(string message)
    {
        // Asegurarse de que el mensaje se agregue en una nueva línea
        textBoxLog.AppendText(message + Environment.NewLine);

        // Desplazar automáticamente hacia abajo el scroll
        textBoxLog.SelectionStart = textBoxLog.Text.Length;
        textBoxLog.ScrollToCaret();
    }

    public async Task<List<string>> GetNames()
    {
        HashSet<string> names = [];

        string baseUrl = "https://apps4.mineco.gob.pe/ServiciosTF/";
        // URL de la página web pública
        string? url = baseUrl + textBoxUrl.Text;

        // Crear HttpClient para obtener el contenido HTML
        var httpClient = new HttpClient();

        while (!string.IsNullOrEmpty(url))
        {
            var html = await httpClient.GetStringAsync(url);

            // Cargar el HTML en HtmlAgilityPack
            var htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            // Seleccionar todos los nodos <a> con la clase "links1"
            var nodes = htmlDoc.DocumentNode.SelectNodes("//td[@class='txtres0']//a[@class='links1']");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    string extractedValue = node.InnerText.Trim();

                    names.Add(extractedValue);
                }
            }

            // Seleccionar el segundo grupo
            var secondGroup = htmlDoc.DocumentNode.SelectNodes("//div[@align='center']")[1];

            if (secondGroup != null)
            {
                // Dentro del segundo grupo, seleccionar el segundo enlace
                var linkNext = secondGroup.SelectNodes(".//a[@class='links1']");

                if (linkNext is not null)
                {
                    var link = linkNext[^1];

                    string hrefValue = link.GetAttributeValue("href", "");

                    if (hrefValue.Contains("nuevo_busq_rtf"))
                    {
                        url = baseUrl + hrefValue;
                    }
                    else
                    {
                        url = null;
                    }
                }

            }
        }

        return [.. names];
    }
}
