namespace Battery_Test_itc
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTestCamera = new System.Windows.Forms.Button();
            this.btnTestScanner = new System.Windows.Forms.Button();
            this.timerPositionGPS = new System.Windows.Forms.Timer();
            this.timerCycleInterval = new System.Windows.Forms.Timer();
            this.timerFixPositionGPS = new System.Windows.Forms.Timer();
            this.tabPageOutput.SuspendLayout();
            this.tabPageConfig1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageConfig0.SuspendLayout();
            this.tabPageConfig2.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabPageOutput.AutoScroll = true;
            this.tabPageOutput.BackColor = System.Drawing.Color.AliceBlue;
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
            this.tabPageOutput.Size = new System.Drawing.Size(232, 242);
            this.tabPageOutput.Text = "Output";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(149, 124);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 18);
            this.buttonClearLog.TabIndex = 42;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelFTPSessions
            // 
            this.labelFTPSessions.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelFTPSessions.Location = new System.Drawing.Point(96, 98);
            this.labelFTPSessions.Name = "labelFTPSessions";
            this.labelFTPSessions.Size = new System.Drawing.Size(52, 16);
            this.labelFTPSessions.Text = "...";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label18.Location = new System.Drawing.Point(9, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 15);
            this.label18.Text = "FTP (Sessions)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(168, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(7, 148);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(217, 89);
            this.textBoxLog.TabIndex = 25;
            // 
            // labelFTPBytesSent
            // 
            this.labelFTPBytesSent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelFTPBytesSent.Location = new System.Drawing.Point(96, 76);
            this.labelFTPBytesSent.Name = "labelFTPBytesSent";
            this.labelFTPBytesSent.Size = new System.Drawing.Size(52, 16);
            this.labelFTPBytesSent.Text = "...";
            // 
            // labelAnzahlPhotosSnapped
            // 
            this.labelAnzahlPhotosSnapped.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelAnzahlPhotosSnapped.Location = new System.Drawing.Point(68, 52);
            this.labelAnzahlPhotosSnapped.Name = "labelAnzahlPhotosSnapped";
            this.labelAnzahlPhotosSnapped.Size = new System.Drawing.Size(50, 16);
            this.labelAnzahlPhotosSnapped.Text = "...";
            // 
            // labelAnzahlBarcodeScans
            // 
            this.labelAnzahlBarcodeScans.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelAnzahlBarcodeScans.Location = new System.Drawing.Point(182, 28);
            this.labelAnzahlBarcodeScans.Name = "labelAnzahlBarcodeScans";
            this.labelAnzahlBarcodeScans.Size = new System.Drawing.Size(42, 16);
            this.labelAnzahlBarcodeScans.Text = "...";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label15.Location = new System.Drawing.Point(8, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 15);
            this.label15.Text = "FTP (Bytes)";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label14.Location = new System.Drawing.Point(8, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 15);
            this.label14.Text = "Photos";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(132, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.Text = "Scans";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(132, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 15);
            this.label12.Text = "Akku %";
            // 
            // labelAkkulevel
            // 
            this.labelAkkulevel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelAkkulevel.Location = new System.Drawing.Point(182, 5);
            this.labelAkkulevel.Name = "labelAkkulevel";
            this.labelAkkulevel.Size = new System.Drawing.Size(42, 16);
            this.labelAkkulevel.Text = "...";
            // 
            // labelTestdauer
            // 
            this.labelTestdauer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelTestdauer.Location = new System.Drawing.Point(68, 28);
            this.labelTestdauer.Name = "labelTestdauer";
            this.labelTestdauer.Size = new System.Drawing.Size(58, 16);
            this.labelTestdauer.Text = "...";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(7, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.Text = "Testdauer";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(7, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.Text = "Startzeit";
            // 
            // labelStartzeit
            // 
            this.labelStartzeit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelStartzeit.Location = new System.Drawing.Point(68, 4);
            this.labelStartzeit.Name = "labelStartzeit";
            this.labelStartzeit.Size = new System.Drawing.Size(58, 16);
            this.labelStartzeit.Text = "...";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(9, 124);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 18);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Test";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // tabPageConfig1
            // 
            this.tabPageConfig1.AutoScroll = true;
            this.tabPageConfig1.BackColor = System.Drawing.Color.LightGreen;
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
            this.tabPageConfig1.Size = new System.Drawing.Size(232, 242);
            this.tabPageConfig1.Text = "Belade";
            // 
            // buttonPresetIntern3
            // 
            this.buttonPresetIntern3.Location = new System.Drawing.Point(112, 223);
            this.buttonPresetIntern3.Name = "buttonPresetIntern3";
            this.buttonPresetIntern3.Size = new System.Drawing.Size(86, 20);
            this.buttonPresetIntern3.TabIndex = 53;
            this.buttonPresetIntern3.Text = "Preset 1.3";
            this.buttonPresetIntern3.Click += new System.EventHandler(this.buttonPresetBeladeIntern3_Click);
            // 
            // buttonPresetBelade2
            // 
            this.buttonPresetBelade2.Location = new System.Drawing.Point(112, 200);
            this.buttonPresetBelade2.Name = "buttonPresetBelade2";
            this.buttonPresetBelade2.Size = new System.Drawing.Size(86, 21);
            this.buttonPresetBelade2.TabIndex = 27;
            this.buttonPresetBelade2.Text = "Preset 1.2";
            this.buttonPresetBelade2.Click += new System.EventHandler(this.buttonPreset2_Click);
            // 
            // buttonPresetBelade1
            // 
            this.buttonPresetBelade1.Location = new System.Drawing.Point(7, 201);
            this.buttonPresetBelade1.Name = "buttonPresetBelade1";
            this.buttonPresetBelade1.Size = new System.Drawing.Size(86, 20);
            this.buttonPresetBelade1.TabIndex = 26;
            this.buttonPresetBelade1.Text = "Preset 1.1";
            this.buttonPresetBelade1.Click += new System.EventHandler(this.buttonPreset1_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(7, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.Text = "FTP Bulkgröße (MB)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeFTPBulkSize
            // 
            this.numericUpDownBeladeFTPBulkSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeFTPBulkSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Location = new System.Drawing.Point(127, 174);
            this.numericUpDownBeladeFTPBulkSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Name = "numericUpDownBeladeFTPBulkSize";
            this.numericUpDownBeladeFTPBulkSize.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeFTPBulkSize.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(7, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.Text = "Größe (Bytes)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeFTPSessionSize
            // 
            this.numericUpDownBeladeFTPSessionSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessionSize.Location = new System.Drawing.Point(127, 149);
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
            this.numericUpDownBeladeFTPSessionSize.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeFTPSessionSize.TabIndex = 17;
            this.numericUpDownBeladeFTPSessionSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // numericUpDownBeladeFTPSessions
            // 
            this.numericUpDownBeladeFTPSessions.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeFTPSessions.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessions.Location = new System.Drawing.Point(127, 125);
            this.numericUpDownBeladeFTPSessions.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessions.Name = "numericUpDownBeladeFTPSessions";
            this.numericUpDownBeladeFTPSessions.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeFTPSessions.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(7, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.Text = "Anzahl FTP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(7, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.Text = "Dauer (Sekunden)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.Text = "Anzahl Photos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeSnapPhotoDurationSekunden
            // 
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Location = new System.Drawing.Point(127, 101);
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
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeSnapPhotoDurationSekunden.TabIndex = 9;
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBeladeSnapPhotos
            // 
            this.numericUpDownBeladeSnapPhotos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeSnapPhotos.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotos.Location = new System.Drawing.Point(127, 76);
            this.numericUpDownBeladeSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotos.Name = "numericUpDownBeladeSnapPhotos";
            this.numericUpDownBeladeSnapPhotos.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeSnapPhotos.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.Text = "Dauer (Sekunden)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeScanBarcodeDurationSekunden
            // 
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Location = new System.Drawing.Point(127, 52);
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
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeScanBarcodeDurationSekunden.TabIndex = 5;
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.Text = "Anzahl Scans";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeScanBarcodes
            // 
            this.numericUpDownBeladeScanBarcodes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeScanBarcodes.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Location = new System.Drawing.Point(127, 28);
            this.numericUpDownBeladeScanBarcodes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Name = "numericUpDownBeladeScanBarcodes";
            this.numericUpDownBeladeScanBarcodes.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownBeladeScanBarcodes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.Text = "Laufzeit (Stunden)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownBeladeLaufzeitStunden
            // 
            this.numericUpDownBeladeLaufzeitStunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeLaufzeitStunden.Location = new System.Drawing.Point(127, 4);
            this.numericUpDownBeladeLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBeladeLaufzeitStunden.Name = "numericUpDownBeladeLaufzeitStunden";
            this.numericUpDownBeladeLaufzeitStunden.Size = new System.Drawing.Size(71, 20);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageConfig0
            // 
            this.tabPageConfig0.AutoScroll = true;
            this.tabPageConfig0.BackColor = System.Drawing.Color.LightYellow;
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
            this.tabPageConfig0.Size = new System.Drawing.Size(240, 245);
            this.tabPageConfig0.Text = "Config";
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.Checked = true;
            this.radioButtonActive.Location = new System.Drawing.Point(117, 102);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(102, 22);
            this.radioButtonActive.TabIndex = 64;
            this.radioButtonActive.Text = "Aktiv (PORT)";
            this.radioButtonActive.CheckedChanged += new System.EventHandler(this.radioButtonActive_CheckedChanged);
            // 
            // radioButtonPassive
            // 
            this.radioButtonPassive.Location = new System.Drawing.Point(3, 101);
            this.radioButtonPassive.Name = "radioButtonPassive";
            this.radioButtonPassive.Size = new System.Drawing.Size(108, 22);
            this.radioButtonPassive.TabIndex = 63;
            this.radioButtonPassive.TabStop = false;
            this.radioButtonPassive.Text = "Passiv (PASV)";
            this.radioButtonPassive.CheckedChanged += new System.EventHandler(this.radioButtonPassive_CheckedChanged);
            // 
            // checkBoxLogFTP
            // 
            this.checkBoxLogFTP.Location = new System.Drawing.Point(7, 128);
            this.checkBoxLogFTP.Name = "checkBoxLogFTP";
            this.checkBoxLogFTP.Size = new System.Drawing.Size(104, 23);
            this.checkBoxLogFTP.TabIndex = 58;
            this.checkBoxLogFTP.Text = "Log Sessions";
            this.checkBoxLogFTP.CheckStateChanged += new System.EventHandler(this.checkBoxLogFTP_CheckStateChanged);
            // 
            // textBoxTestFTP
            // 
            this.textBoxTestFTP.Location = new System.Drawing.Point(3, 157);
            this.textBoxTestFTP.Multiline = true;
            this.textBoxTestFTP.Name = "textBoxTestFTP";
            this.textBoxTestFTP.ReadOnly = true;
            this.textBoxTestFTP.Size = new System.Drawing.Size(216, 81);
            this.textBoxTestFTP.TabIndex = 57;
            // 
            // buttonTestFTP
            // 
            this.buttonTestFTP.Location = new System.Drawing.Point(113, 128);
            this.buttonTestFTP.Name = "buttonTestFTP";
            this.buttonTestFTP.Size = new System.Drawing.Size(106, 22);
            this.buttonTestFTP.TabIndex = 56;
            this.buttonTestFTP.Text = "Test";
            this.buttonTestFTP.Click += new System.EventHandler(this.buttonTestFTP_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(7, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 20);
            this.label16.Text = "FTP Sessions";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(7, 76);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(65, 21);
            this.label47.Text = "Kennwort:";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(7, 49);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 21);
            this.label46.Text = "Benutzer:";
            // 
            // textBoxDataKennwort
            // 
            this.textBoxDataKennwort.Location = new System.Drawing.Point(78, 75);
            this.textBoxDataKennwort.Name = "textBoxDataKennwort";
            this.textBoxDataKennwort.Size = new System.Drawing.Size(129, 21);
            this.textBoxDataKennwort.TabIndex = 54;
            this.textBoxDataKennwort.Text = "ftp";
            this.textBoxDataKennwort.LostFocus += new System.EventHandler(this.textBoxDataKennwort_LostFocus);
            // 
            // textBoxDataBenutzer
            // 
            this.textBoxDataBenutzer.Location = new System.Drawing.Point(78, 49);
            this.textBoxDataBenutzer.Name = "textBoxDataBenutzer";
            this.textBoxDataBenutzer.Size = new System.Drawing.Size(129, 21);
            this.textBoxDataBenutzer.TabIndex = 53;
            this.textBoxDataBenutzer.Text = "ftp";
            this.textBoxDataBenutzer.LostFocus += new System.EventHandler(this.textBoxDataBenutzer_LostFocus);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.Text = "Server:";
            // 
            // textBoxDataServer
            // 
            this.textBoxDataServer.Location = new System.Drawing.Point(78, 24);
            this.textBoxDataServer.Name = "textBoxDataServer";
            this.textBoxDataServer.Size = new System.Drawing.Size(129, 21);
            this.textBoxDataServer.TabIndex = 52;
            this.textBoxDataServer.LostFocus += new System.EventHandler(this.textBoxDataServer_LostFocus);
            // 
            // tabPageConfig2
            // 
            this.tabPageConfig2.AutoScroll = true;
            this.tabPageConfig2.BackColor = System.Drawing.Color.MistyRose;
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
            this.tabPageConfig2.Size = new System.Drawing.Size(232, 242);
            this.tabPageConfig2.Text = "Tour";
            // 
            // numericUpDownTourGPSIntervalSekunden
            // 
            this.numericUpDownTourGPSIntervalSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourGPSIntervalSekunden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Location = new System.Drawing.Point(153, 124);
            this.numericUpDownTourGPSIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Name = "numericUpDownTourGPSIntervalSekunden";
            this.numericUpDownTourGPSIntervalSekunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourGPSIntervalSekunden.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(7, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 18);
            this.label17.Text = "Interval GPS (Sekunden)";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(7, 148);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 18);
            this.label20.Text = "Auslieferung:";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label19.Location = new System.Drawing.Point(39, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 18);
            this.label19.Text = "Größe (Bytes)";
            // 
            // numericUpDownTourFTPSessionSize
            // 
            this.numericUpDownTourFTPSessionSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionSize.Location = new System.Drawing.Point(153, 99);
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
            this.numericUpDownTourFTPSessionSize.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourFTPSessionSize.TabIndex = 57;
            this.numericUpDownTourFTPSessionSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPresetTour2
            // 
            this.buttonPresetTour2.Location = new System.Drawing.Point(123, 279);
            this.buttonPresetTour2.Name = "buttonPresetTour2";
            this.buttonPresetTour2.Size = new System.Drawing.Size(97, 21);
            this.buttonPresetTour2.TabIndex = 27;
            this.buttonPresetTour2.Text = "Preset 1.2";
            this.buttonPresetTour2.Click += new System.EventHandler(this.buttonPresetTour2_Click);
            // 
            // buttonPresetTour1
            // 
            this.buttonPresetTour1.Location = new System.Drawing.Point(20, 279);
            this.buttonPresetTour1.Name = "buttonPresetTour1";
            this.buttonPresetTour1.Size = new System.Drawing.Size(97, 21);
            this.buttonPresetTour1.TabIndex = 26;
            this.buttonPresetTour1.Text = "Preset 1.1";
            this.buttonPresetTour1.Click += new System.EventHandler(this.buttonPresetTour1_Click);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label37.Location = new System.Drawing.Point(7, 167);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(111, 18);
            this.label37.Text = "Interval (Minuten)";
            // 
            // numericUpDownTourCycleIntervalMinuten
            // 
            this.numericUpDownTourCycleIntervalMinuten.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleIntervalMinuten.Location = new System.Drawing.Point(153, 167);
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
            this.numericUpDownTourCycleIntervalMinuten.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourCycleIntervalMinuten.TabIndex = 23;
            this.numericUpDownTourCycleIntervalMinuten.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label39.Location = new System.Drawing.Point(7, 238);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(111, 18);
            this.label39.Text = "FTP Größe (Bytes)";
            // 
            // numericUpDownTourCycleFTPSessionSize
            // 
            this.numericUpDownTourCycleFTPSessionSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownTourCycleFTPSessionSize.Location = new System.Drawing.Point(153, 238);
            this.numericUpDownTourCycleFTPSessionSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numericUpDownTourCycleFTPSessionSize.Name = "numericUpDownTourCycleFTPSessionSize";
            this.numericUpDownTourCycleFTPSessionSize.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourCycleFTPSessionSize.TabIndex = 17;
            this.numericUpDownTourCycleFTPSessionSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownTourFTPSessionIntervalSekunden
            // 
            this.numericUpDownTourFTPSessionIntervalSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourFTPSessionIntervalSekunden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionIntervalSekunden.Location = new System.Drawing.Point(153, 75);
            this.numericUpDownTourFTPSessionIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionIntervalSekunden.Name = "numericUpDownTourFTPSessionIntervalSekunden";
            this.numericUpDownTourFTPSessionIntervalSekunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourFTPSessionIntervalSekunden.TabIndex = 16;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label40.Location = new System.Drawing.Point(7, 75);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(125, 18);
            this.label40.Text = "Interval FTP (Sekunden)";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label41.Location = new System.Drawing.Point(39, 51);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(111, 18);
            this.label41.Text = "Dauer (Sekunden)";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label42.Location = new System.Drawing.Point(7, 27);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(111, 18);
            this.label42.Text = "Anzahl Photos";
            // 
            // numericUpDownTourSnapPhotoDurationSekunden
            // 
            this.numericUpDownTourSnapPhotoDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourSnapPhotoDurationSekunden.Location = new System.Drawing.Point(153, 51);
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
            this.numericUpDownTourSnapPhotoDurationSekunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourSnapPhotoDurationSekunden.TabIndex = 9;
            this.numericUpDownTourSnapPhotoDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownTourSnapPhotos
            // 
            this.numericUpDownTourSnapPhotos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourSnapPhotos.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotos.Location = new System.Drawing.Point(153, 27);
            this.numericUpDownTourSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotos.Name = "numericUpDownTourSnapPhotos";
            this.numericUpDownTourSnapPhotos.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourSnapPhotos.TabIndex = 8;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label43.Location = new System.Drawing.Point(39, 214);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(111, 18);
            this.label43.Text = "Dauer (Sekunden)";
            // 
            // numericUpDownTourCycleScanBarcodeDurationSekunden
            // 
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Location = new System.Drawing.Point(153, 214);
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
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.TabIndex = 5;
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label44.Location = new System.Drawing.Point(7, 190);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(111, 18);
            this.label44.Text = "Anzahl Scans";
            // 
            // numericUpDownTourCycleScanBarcodes
            // 
            this.numericUpDownTourCycleScanBarcodes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleScanBarcodes.Location = new System.Drawing.Point(153, 190);
            this.numericUpDownTourCycleScanBarcodes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTourCycleScanBarcodes.Name = "numericUpDownTourCycleScanBarcodes";
            this.numericUpDownTourCycleScanBarcodes.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourCycleScanBarcodes.TabIndex = 2;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label45.Location = new System.Drawing.Point(7, 4);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(111, 18);
            this.label45.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownTourLaufzeitStunden
            // 
            this.numericUpDownTourLaufzeitStunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourLaufzeitStunden.Location = new System.Drawing.Point(153, 4);
            this.numericUpDownTourLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTourLaufzeitStunden.Name = "numericUpDownTourLaufzeitStunden";
            this.numericUpDownTourLaufzeitStunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTourLaufzeitStunden.TabIndex = 0;
            this.numericUpDownTourLaufzeitStunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.btnTestCamera);
            this.tabPage1.Controls.Add(this.btnTestScanner);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 245);
            this.tabPage1.Text = "TEST";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 21);
            this.textBox1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(116, 96);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(117, 146);
            // 
            // btnTestCamera
            // 
            this.btnTestCamera.Location = new System.Drawing.Point(7, 96);
            this.btnTestCamera.Name = "btnTestCamera";
            this.btnTestCamera.Size = new System.Drawing.Size(84, 31);
            this.btnTestCamera.TabIndex = 0;
            this.btnTestCamera.Text = "test camera";
            this.btnTestCamera.Click += new System.EventHandler(this.btnTestCamera_Click);
            // 
            // btnTestScanner
            // 
            this.btnTestScanner.Location = new System.Drawing.Point(7, 7);
            this.btnTestScanner.Name = "btnTestScanner";
            this.btnTestScanner.Size = new System.Drawing.Size(84, 31);
            this.btnTestScanner.TabIndex = 0;
            this.btnTestScanner.Text = "test scanner";
            this.btnTestScanner.Click += new System.EventHandler(this.btnTestScanner_Click);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "trans-o-flex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabPageOutput.ResumeLayout(false);
            this.tabPageConfig1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageConfig0.ResumeLayout(false);
            this.tabPageConfig2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnTestCamera;
        private System.Windows.Forms.Button btnTestScanner;
    }
}

