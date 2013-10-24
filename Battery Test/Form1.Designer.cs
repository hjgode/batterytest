namespace Battery_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timerLoopSecond = new System.Windows.Forms.Timer();
            this.timerSnapPhoto = new System.Windows.Forms.Timer();
            this.timerScanBarcode = new System.Windows.Forms.Timer();
            this.timerFTPSession = new System.Windows.Forms.Timer();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemStart = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.timerPhotoSnap = new System.Windows.Forms.Timer();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelFTPSessions = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelFTPBytesSent = new System.Windows.Forms.Label();
            this.labelAnzahlPhotosSnapped = new System.Windows.Forms.Label();
            this.labelAnzahlBarcodeScans = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelAkkulevel = new System.Windows.Forms.Label();
            this.labelTestdauer = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelStartzeit = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.tabPageConfig1 = new System.Windows.Forms.TabPage();
            this.buttonPresetIntern3 = new System.Windows.Forms.Button();
            this.buttonPresetBelade2 = new System.Windows.Forms.Button();
            this.buttonPresetBelade1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeFTPBulkSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeFTPSessionSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBeladeFTPSessions = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeSnapPhotoDurationSekunden = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBeladeSnapPhotos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeScanBarcodeDurationSekunden = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeScanBarcodes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownBeladeLaufzeitStunden = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageConfig0 = new System.Windows.Forms.TabPage();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.radioButtonPassive = new System.Windows.Forms.RadioButton();
            this.checkBoxLogFTP = new System.Windows.Forms.CheckBox();
            this.textBoxTestFTP = new System.Windows.Forms.TextBox();
            this.buttonTestFTP = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.textBoxDataKennwort = new System.Windows.Forms.TextBox();
            this.textBoxDataBenutzer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDataServer = new System.Windows.Forms.TextBox();
            this.tabPageConfig2 = new System.Windows.Forms.TabPage();
            this.numericUpDownTourGPSIntervalSekunden = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownTourFTPSessionSize = new System.Windows.Forms.NumericUpDown();
            this.buttonPresetTour2 = new System.Windows.Forms.Button();
            this.buttonPresetTour1 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.numericUpDownTourCycleIntervalMinuten = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.numericUpDownTourCycleFTPSessionSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTourFTPSessionIntervalSekunden = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.numericUpDownTourSnapPhotoDurationSekunden = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTourSnapPhotos = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.numericUpDownTourCycleScanBarcodeDurationSekunden = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.numericUpDownTourCycleScanBarcodes = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.numericUpDownTourLaufzeitStunden = new System.Windows.Forms.NumericUpDown();
            this.timerPositionGPS = new System.Windows.Forms.Timer();
            this.timerCycleInterval = new System.Windows.Forms.Timer();
            this.timerFixPositionGPS = new System.Windows.Forms.Timer();
            this.tabPageOutput.SuspendLayout();
            this.tabPageConfig1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageConfig0.SuspendLayout();
            this.tabPageConfig2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLoopSecond
            // 
            this.timerLoopSecond.Interval = 1000;
            this.timerLoopSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // timerSnapPhoto
            // 
            this.timerSnapPhoto.Tick += new System.EventHandler(this.timerPhoto_Tick);
            // 
            // timerScanBarcode
            // 
            this.timerScanBarcode.Tick += new System.EventHandler(this.timerScan_Tick);
            // 
            // timerFTPSession
            // 
            this.timerFTPSession.Tick += new System.EventHandler(this.timerData_Tick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemStart);
            this.mainMenu1.MenuItems.Add(this.menuItemExit);
            // 
            // menuItemStart
            // 
            this.menuItemStart.Text = "Start";
            this.menuItemStart.Click += new System.EventHandler(this.menuItemStart_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // timerPhotoSnap
            // 
            this.timerPhotoSnap.Tick += new System.EventHandler(this.timerSnapPhotoSnap_Tick);
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.buttonClearLog);
            this.tabPageOutput.Controls.Add(this.labelFTPSessions);
            this.tabPageOutput.Controls.Add(this.label18);
            this.tabPageOutput.Controls.Add(this.pictureBox1);
            this.tabPageOutput.Controls.Add(this.textBoxLog);
            this.tabPageOutput.Controls.Add(this.labelFTPBytesSent);
            this.tabPageOutput.Controls.Add(this.labelAnzahlPhotosSnapped);
            this.tabPageOutput.Controls.Add(this.labelAnzahlBarcodeScans);
            this.tabPageOutput.Controls.Add(this.label15);
            this.tabPageOutput.Controls.Add(this.label14);
            this.tabPageOutput.Controls.Add(this.label13);
            this.tabPageOutput.Controls.Add(this.label12);
            this.tabPageOutput.Controls.Add(this.labelAkkulevel);
            this.tabPageOutput.Controls.Add(this.labelTestdauer);
            this.tabPageOutput.Controls.Add(this.label10);
            this.tabPageOutput.Controls.Add(this.label11);
            this.tabPageOutput.Controls.Add(this.labelStartzeit);
            this.tabPageOutput.Controls.Add(this.buttonStop);
            this.tabPageOutput.Location = new System.Drawing.Point(0, 0);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Size = new System.Drawing.Size(446, 658);
            this.tabPageOutput.Text = "Output";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(265, 382);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(201, 41);
            this.buttonClearLog.TabIndex = 42;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelFTPSessions
            // 
            this.labelFTPSessions.Location = new System.Drawing.Point(266, 250);
            this.labelFTPSessions.Name = "labelFTPSessions";
            this.labelFTPSessions.Size = new System.Drawing.Size(200, 41);
            this.labelFTPSessions.Text = "...";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(15, 250);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(200, 41);
            this.label18.Text = "FTP (Sessions)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 294);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(15, 429);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(452, 220);
            this.textBoxLog.TabIndex = 25;
            // 
            // labelFTPBytesSent
            // 
            this.labelFTPBytesSent.Location = new System.Drawing.Point(266, 209);
            this.labelFTPBytesSent.Name = "labelFTPBytesSent";
            this.labelFTPBytesSent.Size = new System.Drawing.Size(200, 41);
            this.labelFTPBytesSent.Text = "...";
            // 
            // labelAnzahlPhotosSnapped
            // 
            this.labelAnzahlPhotosSnapped.Location = new System.Drawing.Point(266, 168);
            this.labelAnzahlPhotosSnapped.Name = "labelAnzahlPhotosSnapped";
            this.labelAnzahlPhotosSnapped.Size = new System.Drawing.Size(200, 41);
            this.labelAnzahlPhotosSnapped.Text = "...";
            // 
            // labelAnzahlBarcodeScans
            // 
            this.labelAnzahlBarcodeScans.Location = new System.Drawing.Point(266, 128);
            this.labelAnzahlBarcodeScans.Name = "labelAnzahlBarcodeScans";
            this.labelAnzahlBarcodeScans.Size = new System.Drawing.Size(200, 41);
            this.labelAnzahlBarcodeScans.Text = "...";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(14, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(200, 41);
            this.label15.Text = "FTP (Bytes)";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(14, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(200, 41);
            this.label14.Text = "Photos";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(14, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 41);
            this.label13.Text = "Scans";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 41);
            this.label12.Text = "Akku %";
            // 
            // labelAkkulevel
            // 
            this.labelAkkulevel.Location = new System.Drawing.Point(266, 89);
            this.labelAkkulevel.Name = "labelAkkulevel";
            this.labelAkkulevel.Size = new System.Drawing.Size(200, 41);
            this.labelAkkulevel.Text = "...";
            // 
            // labelTestdauer
            // 
            this.labelTestdauer.Location = new System.Drawing.Point(266, 48);
            this.labelTestdauer.Name = "labelTestdauer";
            this.labelTestdauer.Size = new System.Drawing.Size(200, 41);
            this.labelTestdauer.Text = "...";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(14, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 41);
            this.label10.Text = "Testdauer";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 41);
            this.label11.Text = "Startzeit";
            // 
            // labelStartzeit
            // 
            this.labelStartzeit.Location = new System.Drawing.Point(266, 8);
            this.labelStartzeit.Name = "labelStartzeit";
            this.labelStartzeit.Size = new System.Drawing.Size(200, 41);
            this.labelStartzeit.Text = "...";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(265, 294);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(201, 41);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Test";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // tabPageConfig1
            // 
            this.tabPageConfig1.Controls.Add(this.buttonPresetIntern3);
            this.tabPageConfig1.Controls.Add(this.buttonPresetBelade2);
            this.tabPageConfig1.Controls.Add(this.buttonPresetBelade1);
            this.tabPageConfig1.Controls.Add(this.label9);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeFTPBulkSize);
            this.tabPageConfig1.Controls.Add(this.label7);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeFTPSessionSize);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeFTPSessions);
            this.tabPageConfig1.Controls.Add(this.label6);
            this.tabPageConfig1.Controls.Add(this.label5);
            this.tabPageConfig1.Controls.Add(this.label4);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeSnapPhotoDurationSekunden);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeSnapPhotos);
            this.tabPageConfig1.Controls.Add(this.label3);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeScanBarcodeDurationSekunden);
            this.tabPageConfig1.Controls.Add(this.label2);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeScanBarcodes);
            this.tabPageConfig1.Controls.Add(this.label1);
            this.tabPageConfig1.Controls.Add(this.numericUpDownBeladeLaufzeitStunden);
            this.tabPageConfig1.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfig1.Name = "tabPageConfig1";
            this.tabPageConfig1.Size = new System.Drawing.Size(446, 658);
            this.tabPageConfig1.Text = "Belade";
            // 
            // buttonPresetIntern3
            // 
            this.buttonPresetIntern3.Location = new System.Drawing.Point(286, 592);
            this.buttonPresetIntern3.Name = "buttonPresetIntern3";
            this.buttonPresetIntern3.Size = new System.Drawing.Size(160, 40);
            this.buttonPresetIntern3.TabIndex = 53;
            this.buttonPresetIntern3.Text = "Preset 1.3";
            this.buttonPresetIntern3.Click += new System.EventHandler(this.buttonPresetBeladeIntern3_Click);
            // 
            // buttonPresetBelade2
            // 
            this.buttonPresetBelade2.Location = new System.Drawing.Point(286, 528);
            this.buttonPresetBelade2.Name = "buttonPresetBelade2";
            this.buttonPresetBelade2.Size = new System.Drawing.Size(160, 40);
            this.buttonPresetBelade2.TabIndex = 27;
            this.buttonPresetBelade2.Text = "Preset 1.2";
            this.buttonPresetBelade2.Click += new System.EventHandler(this.buttonPreset2_Click);
            // 
            // buttonPresetBelade1
            // 
            this.buttonPresetBelade1.Location = new System.Drawing.Point(286, 465);
            this.buttonPresetBelade1.Name = "buttonPresetBelade1";
            this.buttonPresetBelade1.Size = new System.Drawing.Size(160, 40);
            this.buttonPresetBelade1.TabIndex = 26;
            this.buttonPresetBelade1.Text = "Preset 1.1";
            this.buttonPresetBelade1.Click += new System.EventHandler(this.buttonPreset1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(14, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 41);
            this.label9.Text = "FTP Bulkgröße (MB)";
            // 
            // numericUpDownBeladeFTPBulkSize
            // 
            this.numericUpDownBeladeFTPBulkSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Location = new System.Drawing.Point(286, 411);
            this.numericUpDownBeladeFTPBulkSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Name = "numericUpDownBeladeFTPBulkSize";
            this.numericUpDownBeladeFTPBulkSize.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeFTPBulkSize.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(40, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 41);
            this.label7.Text = "Größe (Bytes)";
            // 
            // numericUpDownBeladeFTPSessionSize
            // 
            this.numericUpDownBeladeFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessionSize.Location = new System.Drawing.Point(286, 354);
            this.numericUpDownBeladeFTPSessionSize.Maximum = new decimal(new int[] {
            1038576,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessionSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessionSize.Name = "numericUpDownBeladeFTPSessionSize";
            this.numericUpDownBeladeFTPSessionSize.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeFTPSessionSize.TabIndex = 17;
            this.numericUpDownBeladeFTPSessionSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // numericUpDownBeladeFTPSessions
            // 
            this.numericUpDownBeladeFTPSessions.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessions.Location = new System.Drawing.Point(286, 298);
            this.numericUpDownBeladeFTPSessions.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessions.Name = "numericUpDownBeladeFTPSessions";
            this.numericUpDownBeladeFTPSessions.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeFTPSessions.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 41);
            this.label6.Text = "Anzahl FTP";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(40, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 41);
            this.label5.Text = "Dauer (Sekunden)";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 41);
            this.label4.Text = "Anzahl Photos";
            // 
            // numericUpDownBeladeSnapPhotoDurationSekunden
            // 
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Location = new System.Drawing.Point(286, 243);
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Name = "numericUpDownBeladeSnapPhotoDurationSekunden";
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeSnapPhotoDurationSekunden.TabIndex = 9;
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBeladeSnapPhotos
            // 
            this.numericUpDownBeladeSnapPhotos.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotos.Location = new System.Drawing.Point(286, 186);
            this.numericUpDownBeladeSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotos.Name = "numericUpDownBeladeSnapPhotos";
            this.numericUpDownBeladeSnapPhotos.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeSnapPhotos.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 41);
            this.label3.Text = "Dauer (Sekunden)";
            // 
            // numericUpDownBeladeScanBarcodeDurationSekunden
            // 
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Location = new System.Drawing.Point(286, 130);
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Name = "numericUpDownBeladeScanBarcodeDurationSekunden";
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeScanBarcodeDurationSekunden.TabIndex = 5;
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 41);
            this.label2.Text = "Anzahl Scans";
            // 
            // numericUpDownBeladeScanBarcodes
            // 
            this.numericUpDownBeladeScanBarcodes.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Location = new System.Drawing.Point(286, 71);
            this.numericUpDownBeladeScanBarcodes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Name = "numericUpDownBeladeScanBarcodes";
            this.numericUpDownBeladeScanBarcodes.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeScanBarcodes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 41);
            this.label1.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownBeladeLaufzeitStunden
            // 
            this.numericUpDownBeladeLaufzeitStunden.Location = new System.Drawing.Point(286, 18);
            this.numericUpDownBeladeLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBeladeLaufzeitStunden.Name = "numericUpDownBeladeLaufzeitStunden";
            this.numericUpDownBeladeLaufzeitStunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownBeladeLaufzeitStunden.TabIndex = 0;
            this.numericUpDownBeladeLaufzeitStunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageConfig0);
            this.tabControl1.Controls.Add(this.tabPageConfig1);
            this.tabControl1.Controls.Add(this.tabPageConfig2);
            this.tabControl1.Controls.Add(this.tabPageOutput);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 696);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageConfig0
            // 
            this.tabPageConfig0.Controls.Add(this.radioButtonActive);
            this.tabPageConfig0.Controls.Add(this.radioButtonPassive);
            this.tabPageConfig0.Controls.Add(this.checkBoxLogFTP);
            this.tabPageConfig0.Controls.Add(this.textBoxTestFTP);
            this.tabPageConfig0.Controls.Add(this.buttonTestFTP);
            this.tabPageConfig0.Controls.Add(this.label16);
            this.tabPageConfig0.Controls.Add(this.label47);
            this.tabPageConfig0.Controls.Add(this.label46);
            this.tabPageConfig0.Controls.Add(this.textBoxDataKennwort);
            this.tabPageConfig0.Controls.Add(this.textBoxDataBenutzer);
            this.tabPageConfig0.Controls.Add(this.label8);
            this.tabPageConfig0.Controls.Add(this.textBoxDataServer);
            this.tabPageConfig0.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfig0.Name = "tabPageConfig0";
            this.tabPageConfig0.Size = new System.Drawing.Size(480, 652);
            this.tabPageConfig0.Text = "Config";
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.Checked = true;
            this.radioButtonActive.Location = new System.Drawing.Point(259, 242);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(200, 40);
            this.radioButtonActive.TabIndex = 64;
            this.radioButtonActive.Text = "Aktiv (PORT)";
            this.radioButtonActive.CheckedChanged += new System.EventHandler(this.radioButtonActive_CheckedChanged);
            // 
            // radioButtonPassive
            // 
            this.radioButtonPassive.Location = new System.Drawing.Point(259, 196);
            this.radioButtonPassive.Name = "radioButtonPassive";
            this.radioButtonPassive.Size = new System.Drawing.Size(200, 40);
            this.radioButtonPassive.TabIndex = 63;
            this.radioButtonPassive.TabStop = false;
            this.radioButtonPassive.Text = "Passiv (PASV)";
            this.radioButtonPassive.CheckedChanged += new System.EventHandler(this.radioButtonPassive_CheckedChanged);
            // 
            // checkBoxLogFTP
            // 
            this.checkBoxLogFTP.Location = new System.Drawing.Point(7, 196);
            this.checkBoxLogFTP.Name = "checkBoxLogFTP";
            this.checkBoxLogFTP.Size = new System.Drawing.Size(200, 40);
            this.checkBoxLogFTP.TabIndex = 58;
            this.checkBoxLogFTP.Text = "Log Sessions";
            this.checkBoxLogFTP.CheckStateChanged += new System.EventHandler(this.checkBoxLogFTP_CheckStateChanged);
            // 
            // textBoxTestFTP
            // 
            this.textBoxTestFTP.Location = new System.Drawing.Point(7, 293);
            this.textBoxTestFTP.Multiline = true;
            this.textBoxTestFTP.Name = "textBoxTestFTP";
            this.textBoxTestFTP.ReadOnly = true;
            this.textBoxTestFTP.Size = new System.Drawing.Size(452, 356);
            this.textBoxTestFTP.TabIndex = 57;
            // 
            // buttonTestFTP
            // 
            this.buttonTestFTP.Location = new System.Drawing.Point(7, 242);
            this.buttonTestFTP.Name = "buttonTestFTP";
            this.buttonTestFTP.Size = new System.Drawing.Size(200, 40);
            this.buttonTestFTP.TabIndex = 56;
            this.buttonTestFTP.Text = "Test";
            this.buttonTestFTP.Click += new System.EventHandler(this.buttonTestFTP_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(7, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(240, 41);
            this.label16.Text = "FTP Sessions";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(7, 149);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(240, 41);
            this.label47.Text = "Kennwort";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(7, 102);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(240, 41);
            this.label46.Text = "Benutzer";
            // 
            // textBoxDataKennwort
            // 
            this.textBoxDataKennwort.Location = new System.Drawing.Point(259, 149);
            this.textBoxDataKennwort.Name = "textBoxDataKennwort";
            this.textBoxDataKennwort.Size = new System.Drawing.Size(200, 41);
            this.textBoxDataKennwort.TabIndex = 54;
            this.textBoxDataKennwort.Text = "ftp";
            this.textBoxDataKennwort.LostFocus += new System.EventHandler(this.textBoxDataKennwort_LostFocus);
            // 
            // textBoxDataBenutzer
            // 
            this.textBoxDataBenutzer.Location = new System.Drawing.Point(259, 102);
            this.textBoxDataBenutzer.Name = "textBoxDataBenutzer";
            this.textBoxDataBenutzer.Size = new System.Drawing.Size(200, 41);
            this.textBoxDataBenutzer.TabIndex = 53;
            this.textBoxDataBenutzer.Text = "ftp";
            this.textBoxDataBenutzer.LostFocus += new System.EventHandler(this.textBoxDataBenutzer_LostFocus);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 41);
            this.label8.Text = "Serveradresse";
            // 
            // textBoxDataServer
            // 
            this.textBoxDataServer.Location = new System.Drawing.Point(259, 55);
            this.textBoxDataServer.Name = "textBoxDataServer";
            this.textBoxDataServer.Size = new System.Drawing.Size(200, 41);
            this.textBoxDataServer.TabIndex = 52;
            this.textBoxDataServer.LostFocus += new System.EventHandler(this.textBoxDataServer_LostFocus);
            // 
            // tabPageConfig2
            // 
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourGPSIntervalSekunden);
            this.tabPageConfig2.Controls.Add(this.label17);
            this.tabPageConfig2.Controls.Add(this.label20);
            this.tabPageConfig2.Controls.Add(this.label19);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourFTPSessionSize);
            this.tabPageConfig2.Controls.Add(this.buttonPresetTour2);
            this.tabPageConfig2.Controls.Add(this.buttonPresetTour1);
            this.tabPageConfig2.Controls.Add(this.label37);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourCycleIntervalMinuten);
            this.tabPageConfig2.Controls.Add(this.label39);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourCycleFTPSessionSize);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourFTPSessionIntervalSekunden);
            this.tabPageConfig2.Controls.Add(this.label40);
            this.tabPageConfig2.Controls.Add(this.label41);
            this.tabPageConfig2.Controls.Add(this.label42);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourSnapPhotoDurationSekunden);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourSnapPhotos);
            this.tabPageConfig2.Controls.Add(this.label43);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourCycleScanBarcodeDurationSekunden);
            this.tabPageConfig2.Controls.Add(this.label44);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourCycleScanBarcodes);
            this.tabPageConfig2.Controls.Add(this.label45);
            this.tabPageConfig2.Controls.Add(this.numericUpDownTourLaufzeitStunden);
            this.tabPageConfig2.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfig2.Name = "tabPageConfig2";
            this.tabPageConfig2.Size = new System.Drawing.Size(446, 658);
            this.tabPageConfig2.Text = "Tour";
            // 
            // numericUpDownTourGPSIntervalSekunden
            // 
            this.numericUpDownTourGPSIntervalSekunden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Location = new System.Drawing.Point(292, 238);
            this.numericUpDownTourGPSIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Name = "numericUpDownTourGPSIntervalSekunden";
            this.numericUpDownTourGPSIntervalSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourGPSIntervalSekunden.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(14, 238);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(297, 41);
            this.label17.Text = "Interval GPS (Sekunden)";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(14, 275);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(240, 41);
            this.label20.Text = "Auslieferung:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(46, 191);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(240, 41);
            this.label19.Text = "Größe (Bytes)";
            // 
            // numericUpDownTourFTPSessionSize
            // 
            this.numericUpDownTourFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionSize.Location = new System.Drawing.Point(292, 196);
            this.numericUpDownTourFTPSessionSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionSize.Name = "numericUpDownTourFTPSessionSize";
            this.numericUpDownTourFTPSessionSize.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourFTPSessionSize.TabIndex = 57;
            this.numericUpDownTourFTPSessionSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPresetTour2
            // 
            this.buttonPresetTour2.Location = new System.Drawing.Point(292, 576);
            this.buttonPresetTour2.Name = "buttonPresetTour2";
            this.buttonPresetTour2.Size = new System.Drawing.Size(160, 40);
            this.buttonPresetTour2.TabIndex = 27;
            this.buttonPresetTour2.Text = "Preset 1.2";
            this.buttonPresetTour2.Click += new System.EventHandler(this.buttonPresetTour2_Click);
            // 
            // buttonPresetTour1
            // 
            this.buttonPresetTour1.Location = new System.Drawing.Point(292, 512);
            this.buttonPresetTour1.Name = "buttonPresetTour1";
            this.buttonPresetTour1.Size = new System.Drawing.Size(160, 40);
            this.buttonPresetTour1.TabIndex = 26;
            this.buttonPresetTour1.Text = "Preset 1.1";
            this.buttonPresetTour1.Click += new System.EventHandler(this.buttonPresetTour1_Click);
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(14, 316);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(240, 41);
            this.label37.Text = "Interval (Minuten)";
            // 
            // numericUpDownTourCycleIntervalMinuten
            // 
            this.numericUpDownTourCycleIntervalMinuten.Location = new System.Drawing.Point(292, 320);
            this.numericUpDownTourCycleIntervalMinuten.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTourCycleIntervalMinuten.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourCycleIntervalMinuten.Name = "numericUpDownTourCycleIntervalMinuten";
            this.numericUpDownTourCycleIntervalMinuten.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourCycleIntervalMinuten.TabIndex = 23;
            this.numericUpDownTourCycleIntervalMinuten.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(14, 442);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(240, 41);
            this.label39.Text = "FTP Größe (Bytes)";
            // 
            // numericUpDownTourCycleFTPSessionSize
            // 
            this.numericUpDownTourCycleFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownTourCycleFTPSessionSize.Location = new System.Drawing.Point(292, 446);
            this.numericUpDownTourCycleFTPSessionSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numericUpDownTourCycleFTPSessionSize.Name = "numericUpDownTourCycleFTPSessionSize";
            this.numericUpDownTourCycleFTPSessionSize.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourCycleFTPSessionSize.TabIndex = 17;
            this.numericUpDownTourCycleFTPSessionSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownTourFTPSessionIntervalSekunden
            // 
            this.numericUpDownTourFTPSessionIntervalSekunden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionIntervalSekunden.Location = new System.Drawing.Point(292, 154);
            this.numericUpDownTourFTPSessionIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionIntervalSekunden.Name = "numericUpDownTourFTPSessionIntervalSekunden";
            this.numericUpDownTourFTPSessionIntervalSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourFTPSessionIntervalSekunden.TabIndex = 16;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(14, 150);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(297, 41);
            this.label40.Text = "Interval FTP (Sekunden)";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(46, 107);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(240, 41);
            this.label41.Text = "Dauer (Sekunden)";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(14, 66);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(240, 41);
            this.label42.Text = "Anzahl Photos";
            // 
            // numericUpDownTourSnapPhotoDurationSekunden
            // 
            this.numericUpDownTourSnapPhotoDurationSekunden.Location = new System.Drawing.Point(292, 108);
            this.numericUpDownTourSnapPhotoDurationSekunden.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotoDurationSekunden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotoDurationSekunden.Name = "numericUpDownTourSnapPhotoDurationSekunden";
            this.numericUpDownTourSnapPhotoDurationSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourSnapPhotoDurationSekunden.TabIndex = 9;
            this.numericUpDownTourSnapPhotoDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownTourSnapPhotos
            // 
            this.numericUpDownTourSnapPhotos.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotos.Location = new System.Drawing.Point(292, 66);
            this.numericUpDownTourSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotos.Name = "numericUpDownTourSnapPhotos";
            this.numericUpDownTourSnapPhotos.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourSnapPhotos.TabIndex = 8;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(46, 399);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(240, 41);
            this.label43.Text = "Dauer (Sekunden)";
            // 
            // numericUpDownTourCycleScanBarcodeDurationSekunden
            // 
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Location = new System.Drawing.Point(292, 404);
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Name = "numericUpDownTourCycleScanBarcodeDurationSekunden";
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.TabIndex = 5;
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(14, 358);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(240, 41);
            this.label44.Text = "Anzahl Scans";
            // 
            // numericUpDownTourCycleScanBarcodes
            // 
            this.numericUpDownTourCycleScanBarcodes.Location = new System.Drawing.Point(292, 362);
            this.numericUpDownTourCycleScanBarcodes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTourCycleScanBarcodes.Name = "numericUpDownTourCycleScanBarcodes";
            this.numericUpDownTourCycleScanBarcodes.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourCycleScanBarcodes.TabIndex = 2;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(14, 18);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(240, 41);
            this.label45.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownTourLaufzeitStunden
            // 
            this.numericUpDownTourLaufzeitStunden.Location = new System.Drawing.Point(292, 18);
            this.numericUpDownTourLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTourLaufzeitStunden.Name = "numericUpDownTourLaufzeitStunden";
            this.numericUpDownTourLaufzeitStunden.Size = new System.Drawing.Size(160, 36);
            this.numericUpDownTourLaufzeitStunden.TabIndex = 0;
            this.numericUpDownTourLaufzeitStunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timerPositionGPS
            // 
            this.timerPositionGPS.Tick += new System.EventHandler(this.timerPositionGPS_Tick);
            // 
            // timerCycleInterval
            // 
            this.timerCycleInterval.Tick += new System.EventHandler(this.timerCycleInterval_Tick);
            // 
            // timerFixPositionGPS
            // 
            this.timerFixPositionGPS.Interval = 10000;
            this.timerFixPositionGPS.Tick += new System.EventHandler(this.timerFixPositionGPS_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 696);
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(0, 52);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "trans-o-flex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageOutput.ResumeLayout(false);
            this.tabPageConfig1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageConfig0.ResumeLayout(false);
            this.tabPageConfig2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLoopSecond;
        private System.Windows.Forms.Timer timerSnapPhoto;
        private System.Windows.Forms.Timer timerScanBarcode;
        private System.Windows.Forms.Timer timerFTPSession;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemStart;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.Timer timerPhotoSnap;
        private System.Windows.Forms.TabPage tabPageOutput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelFTPBytesSent;
        private System.Windows.Forms.Label labelAnzahlPhotosSnapped;
        private System.Windows.Forms.Label labelAnzahlBarcodeScans;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelAkkulevel;
        private System.Windows.Forms.Label labelTestdauer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelStartzeit;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TabPage tabPageConfig1;
        private System.Windows.Forms.Button buttonPresetBelade2;
        private System.Windows.Forms.Button buttonPresetBelade1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeFTPBulkSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeFTPSessionSize;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeFTPSessions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeSnapPhotoDurationSekunden;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeSnapPhotos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeScanBarcodeDurationSekunden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeScanBarcodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownBeladeLaufzeitStunden;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConfig2;
        private System.Windows.Forms.Button buttonPresetTour2;
        private System.Windows.Forms.Button buttonPresetTour1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown numericUpDownTourCycleIntervalMinuten;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown numericUpDownTourCycleFTPSessionSize;
        private System.Windows.Forms.NumericUpDown numericUpDownTourFTPSessionIntervalSekunden;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown numericUpDownTourSnapPhotoDurationSekunden;
        private System.Windows.Forms.NumericUpDown numericUpDownTourSnapPhotos;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.NumericUpDown numericUpDownTourCycleScanBarcodeDurationSekunden;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown numericUpDownTourCycleScanBarcodes;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.NumericUpDown numericUpDownTourLaufzeitStunden;
        private System.Windows.Forms.Button buttonPresetIntern3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDownTourFTPSessionSize;
        private System.Windows.Forms.Timer timerPositionGPS;
        private System.Windows.Forms.Timer timerCycleInterval;
        private System.Windows.Forms.TabPage tabPageConfig0;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBoxDataKennwort;
        private System.Windows.Forms.TextBox textBoxDataBenutzer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDataServer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownTourGPSIntervalSekunden;
        private System.Windows.Forms.Button buttonTestFTP;
        private System.Windows.Forms.TextBox textBoxTestFTP;
        private System.Windows.Forms.CheckBox checkBoxLogFTP;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Label labelFTPSessions;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Timer timerFixPositionGPS;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.RadioButton radioButtonPassive;
    }
}

