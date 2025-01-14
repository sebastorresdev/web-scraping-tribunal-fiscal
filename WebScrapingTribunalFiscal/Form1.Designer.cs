namespace WebScrapingTribunalFiscal;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelUrl = new Label();
        textBoxUrl = new TextBox();
        labelYear = new Label();
        comboBoxYear = new ComboBox();
        labelSala = new Label();
        comboBoxSala = new ComboBox();
        buttonDownload = new Button();
        progressBar = new ProgressBar();
        labelDestination = new Label();
        textBoxDestination = new TextBox();
        buttonBrowse = new Button();
        folderBrowserDialog = new FolderBrowserDialog();
        textBoxLog = new TextBox();
        SuspendLayout();
        // 
        // labelUrl
        // 
        labelUrl.AutoSize = true;
        labelUrl.Location = new Point(30, 30);
        labelUrl.Name = "labelUrl";
        labelUrl.Size = new Size(31, 15);
        labelUrl.TabIndex = 0;
        labelUrl.Text = "URL:";
        // 
        // textBoxUrl
        // 
        textBoxUrl.Location = new Point(80, 27);
        textBoxUrl.Name = "textBoxUrl";
        textBoxUrl.Size = new Size(400, 23);
        textBoxUrl.TabIndex = 1;
        // 
        // labelYear
        // 
        labelYear.AutoSize = true;
        labelYear.Location = new Point(30, 70);
        labelYear.Name = "labelYear";
        labelYear.Size = new Size(32, 15);
        labelYear.TabIndex = 2;
        labelYear.Text = "Año:";
        // 
        // comboBoxYear
        // 
        comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxYear.FormattingEnabled = true;
        comboBoxYear.Items.AddRange(new object[] { "2024", "2023", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002", "2001", "2000", "1999", "1998", "1997", "1996", "1995", "1994", "1993", "1992", "1991", "1990", "1989", "1988", "1987", "1986", "1985", "1984", "1983", "1982", "1981", "1980", "1979", "1978", "1977", "1976", "1975", "1974", "1973", "1972", "1971", "1970", "1969", "1968", "1967", "1966", "1965", "1964" });
        comboBoxYear.Location = new Point(80, 67);
        comboBoxYear.Name = "comboBoxYear";
        comboBoxYear.Size = new Size(121, 23);
        comboBoxYear.TabIndex = 3;
        // 
        // labelSala
        // 
        labelSala.AutoSize = true;
        labelSala.Location = new Point(230, 70);
        labelSala.Name = "labelSala";
        labelSala.Size = new Size(31, 15);
        labelSala.TabIndex = 4;
        labelSala.Text = "Sala:";
        // 
        // comboBoxSala
        // 
        comboBoxSala.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSala.FormattingEnabled = true;
        comboBoxSala.Items.AddRange(new object[] { "A", "Q", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });
        comboBoxSala.Location = new Point(280, 67);
        comboBoxSala.Name = "comboBoxSala";
        comboBoxSala.Size = new Size(121, 23);
        comboBoxSala.TabIndex = 5;
        // 
        // buttonDownload
        // 
        buttonDownload.Location = new Point(490, 67);
        buttonDownload.Name = "buttonDownload";
        buttonDownload.Size = new Size(120, 30);
        buttonDownload.TabIndex = 9;
        buttonDownload.Text = "Descargar PDFs";
        buttonDownload.UseVisualStyleBackColor = true;
        buttonDownload.Click += ButtonDownload_Click;
        // 
        // progressBar
        // 
        progressBar.Location = new Point(30, 260);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(580, 22);
        progressBar.TabIndex = 10;
        // 
        // labelDestination
        // 
        labelDestination.AutoSize = true;
        labelDestination.Location = new Point(30, 110);
        labelDestination.Name = "labelDestination";
        labelDestination.Size = new Size(52, 15);
        labelDestination.TabIndex = 6;
        labelDestination.Text = "Guardar:";
        // 
        // textBoxDestination
        // 
        textBoxDestination.Location = new Point(90, 107);
        textBoxDestination.Name = "textBoxDestination";
        textBoxDestination.ReadOnly = true;
        textBoxDestination.Size = new Size(310, 23);
        textBoxDestination.TabIndex = 7;
        // 
        // buttonBrowse
        // 
        buttonBrowse.Location = new Point(410, 106);
        buttonBrowse.Name = "buttonBrowse";
        buttonBrowse.Size = new Size(70, 25);
        buttonBrowse.TabIndex = 8;
        buttonBrowse.Text = "Examinar";
        buttonBrowse.UseVisualStyleBackColor = true;
        buttonBrowse.Click += ButtonBrowse_Click;
        // 
        // textBoxLog
        // 
        textBoxLog.Location = new Point(30, 140);
        textBoxLog.Multiline = true;
        textBoxLog.Name = "textBoxLog";
        textBoxLog.ReadOnly = true;
        textBoxLog.ScrollBars = ScrollBars.Vertical;
        textBoxLog.Size = new Size(580, 101);
        textBoxLog.TabIndex = 11;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(650, 303);
        Controls.Add(textBoxLog);
        Controls.Add(labelUrl);
        Controls.Add(textBoxUrl);
        Controls.Add(labelYear);
        Controls.Add(comboBoxYear);
        Controls.Add(labelSala);
        Controls.Add(comboBoxSala);
        Controls.Add(labelDestination);
        Controls.Add(textBoxDestination);
        Controls.Add(buttonBrowse);
        Controls.Add(buttonDownload);
        Controls.Add(progressBar);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Descargador de PDFs - Tribunal Fiscal";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelUrl;
    private TextBox textBoxUrl;
    private Label labelYear;
    private ComboBox comboBoxYear;
    private Label labelSala;
    private ComboBox comboBoxSala;
    private Label labelDestination;
    private TextBox textBoxDestination;
    private Button buttonBrowse;
    private Button buttonDownload;
    private ProgressBar progressBar;
    private FolderBrowserDialog folderBrowserDialog;
    private TextBox textBoxLog;
}
