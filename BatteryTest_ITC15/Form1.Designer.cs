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
            this.timerStateMachine = new System.Windows.Forms.Timer();
            this.timerPlanPhoto = new System.Windows.Forms.Timer();
            this.timerPlanScan = new System.Windows.Forms.Timer();
            this.timerPlanData = new System.Windows.Forms.Timer();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemStart = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.timerExecPhoto = new System.Windows.Forms.Timer();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCurrentPhase = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonSkipPhase = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelFTPSessions = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.tabPageConfigBelade = new System.Windows.Forms.TabPage();
            this.radioButtonBeladeGPRS = new System.Windows.Forms.RadioButton();
            this.radioButtonBeladeWIFI = new System.Windows.Forms.RadioButton();
            this.checkBoxIncludeBeladePhase = new System.Windows.Forms.CheckBox();
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
            this.tabPageConfigFTP = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxGPRSEntry = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxGPRSKennwort = new System.Windows.Forms.TextBox();
            this.textBoxGPRSBenutzer = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxGPRSAPN = new System.Windows.Forms.TextBox();
            this.checkBoxTestWWAN = new System.Windows.Forms.CheckBox();
            this.checkBoxTestWLAN = new System.Windows.Forms.CheckBox();
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
            this.tabPageConfigTour = new System.Windows.Forms.TabPage();
            this.numericUpDownTourCycleDisplayAn = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.checkBoxIncludeTourPhase = new System.Windows.Forms.CheckBox();
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
            this.tabPageConfigRuhe = new System.Windows.Forms.TabPage();
            this.radioButtonRuheUnattended = new System.Windows.Forms.RadioButton();
            this.radioButtonRuheSuspend = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDownRuheLaufzeitMinuten = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDownRuheLaufzeitStunden = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIncludeRuhePhase = new System.Windows.Forms.CheckBox();
            this.timerPlanGPS = new System.Windows.Forms.Timer();
            this.timerPlanTourCycle = new System.Windows.Forms.Timer();
            this.timerExecGPS = new System.Windows.Forms.Timer();
            this.timerManageUnattended = new System.Windows.Forms.Timer();
            this.tabPageOutput.SuspendLayout();
            this.tabPageConfigBelade.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageConfigFTP.SuspendLayout();
            this.tabPageConfigTour.SuspendLayout();
            this.tabPageConfigRuhe.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStateMachine
            // 
            this.timerStateMachine.Interval = 1000;
            this.timerStateMachine.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // timerPlanPhoto
            // 
            this.timerPlanPhoto.Tick += new System.EventHandler(this.timerPlanPhoto_Tick);
            // 
            // timerPlanScan
            // 
            this.timerPlanScan.Tick += new System.EventHandler(this.timerPlanScan_Tick);
            // 
            // timerPlanData
            // 
            this.timerPlanData.Tick += new System.EventHandler(this.timerPlanData_Tick);
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
            // timerExecPhoto
            // 
            this.timerExecPhoto.Tick += new System.EventHandler(this.timerExecPhoto_Tick);
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.AutoScroll = true;
            this.tabPageOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.tabPageOutput.Controls.Add(this.pictureBox1);
            this.tabPageOutput.Controls.Add(this.labelCurrentPhase);
            this.tabPageOutput.Controls.Add(this.label28);
            this.tabPageOutput.Controls.Add(this.buttonSkipPhase);
            this.tabPageOutput.Controls.Add(this.buttonClearLog);
            this.tabPageOutput.Controls.Add(this.labelFTPSessions);
            this.tabPageOutput.Controls.Add(this.label18);
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
            this.tabPageOutput.Size = new System.Drawing.Size(232, 294);
            this.tabPageOutput.Text = "Output";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(155, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // labelCurrentPhase
            // 
            this.labelCurrentPhase.Location = new System.Drawing.Point(106, 4);
            this.labelCurrentPhase.Name = "labelCurrentPhase";
            this.labelCurrentPhase.Size = new System.Drawing.Size(84, 21);
            this.labelCurrentPhase.Text = "...";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(7, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 21);
            this.label28.Text = "Testphase";
            // 
            // buttonSkipPhase
            // 
            this.buttonSkipPhase.Enabled = false;
            this.buttonSkipPhase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonSkipPhase.Location = new System.Drawing.Point(7, 199);
            this.buttonSkipPhase.Name = "buttonSkipPhase";
            this.buttonSkipPhase.Size = new System.Drawing.Size(68, 22);
            this.buttonSkipPhase.TabIndex = 58;
            this.buttonSkipPhase.Text = "Skip Phase";
            this.buttonSkipPhase.Click += new System.EventHandler(this.buttonSkipPhase_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonClearLog.Location = new System.Drawing.Point(81, 199);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(68, 22);
            this.buttonClearLog.TabIndex = 42;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelFTPSessions
            // 
            this.labelFTPSessions.Location = new System.Drawing.Point(107, 175);
            this.labelFTPSessions.Name = "labelFTPSessions";
            this.labelFTPSessions.Size = new System.Drawing.Size(42, 21);
            this.labelFTPSessions.Text = "...";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(7, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 21);
            this.label18.Text = "FTP (Sessions)";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxLog.Location = new System.Drawing.Point(6, 227);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(216, 98);
            this.textBoxLog.TabIndex = 25;
            // 
            // labelFTPBytesSent
            // 
            this.labelFTPBytesSent.Location = new System.Drawing.Point(106, 150);
            this.labelFTPBytesSent.Name = "labelFTPBytesSent";
            this.labelFTPBytesSent.Size = new System.Drawing.Size(43, 21);
            this.labelFTPBytesSent.Text = "...";
            // 
            // labelAnzahlPhotosSnapped
            // 
            this.labelAnzahlPhotosSnapped.Location = new System.Drawing.Point(106, 125);
            this.labelAnzahlPhotosSnapped.Name = "labelAnzahlPhotosSnapped";
            this.labelAnzahlPhotosSnapped.Size = new System.Drawing.Size(51, 21);
            this.labelAnzahlPhotosSnapped.Text = "...";
            // 
            // labelAnzahlBarcodeScans
            // 
            this.labelAnzahlBarcodeScans.Location = new System.Drawing.Point(106, 101);
            this.labelAnzahlBarcodeScans.Name = "labelAnzahlBarcodeScans";
            this.labelAnzahlBarcodeScans.Size = new System.Drawing.Size(51, 21);
            this.labelAnzahlBarcodeScans.Text = "...";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 21);
            this.label15.Text = "FTP (Bytes)";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 21);
            this.label14.Text = "Photos";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 21);
            this.label13.Text = "Scans";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 21);
            this.label12.Text = "Akku %";
            // 
            // labelAkkulevel
            // 
            this.labelAkkulevel.Location = new System.Drawing.Point(106, 78);
            this.labelAkkulevel.Name = "labelAkkulevel";
            this.labelAkkulevel.Size = new System.Drawing.Size(51, 21);
            this.labelAkkulevel.Text = "...";
            // 
            // labelTestdauer
            // 
            this.labelTestdauer.Location = new System.Drawing.Point(106, 53);
            this.labelTestdauer.Name = "labelTestdauer";
            this.labelTestdauer.Size = new System.Drawing.Size(84, 21);
            this.labelTestdauer.Text = "...";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 21);
            this.label10.Text = "Testdauer";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 21);
            this.label11.Text = "Startzeit";
            // 
            // labelStartzeit
            // 
            this.labelStartzeit.Location = new System.Drawing.Point(106, 29);
            this.labelStartzeit.Name = "labelStartzeit";
            this.labelStartzeit.Size = new System.Drawing.Size(84, 21);
            this.labelStartzeit.Text = "...";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonStop.Location = new System.Drawing.Point(155, 199);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(68, 22);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Test";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // tabPageConfigBelade
            // 
            this.tabPageConfigBelade.AutoScroll = true;
            this.tabPageConfigBelade.BackColor = System.Drawing.Color.LightSalmon;
            this.tabPageConfigBelade.Controls.Add(this.radioButtonBeladeGPRS);
            this.tabPageConfigBelade.Controls.Add(this.radioButtonBeladeWIFI);
            this.tabPageConfigBelade.Controls.Add(this.checkBoxIncludeBeladePhase);
            this.tabPageConfigBelade.Controls.Add(this.buttonPresetIntern3);
            this.tabPageConfigBelade.Controls.Add(this.buttonPresetBelade2);
            this.tabPageConfigBelade.Controls.Add(this.buttonPresetBelade1);
            this.tabPageConfigBelade.Controls.Add(this.label9);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeFTPBulkSize);
            this.tabPageConfigBelade.Controls.Add(this.label7);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeFTPSessionSize);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeFTPSessions);
            this.tabPageConfigBelade.Controls.Add(this.label6);
            this.tabPageConfigBelade.Controls.Add(this.label5);
            this.tabPageConfigBelade.Controls.Add(this.label4);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeSnapPhotoDurationSekunden);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeSnapPhotos);
            this.tabPageConfigBelade.Controls.Add(this.label3);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeScanBarcodeDurationSekunden);
            this.tabPageConfigBelade.Controls.Add(this.label2);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeScanBarcodes);
            this.tabPageConfigBelade.Controls.Add(this.label1);
            this.tabPageConfigBelade.Controls.Add(this.numericUpDownBeladeLaufzeitStunden);
            this.tabPageConfigBelade.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfigBelade.Name = "tabPageConfigBelade";
            this.tabPageConfigBelade.Size = new System.Drawing.Size(232, 294);
            this.tabPageConfigBelade.Text = "Belade";
            // 
            // radioButtonBeladeGPRS
            // 
            this.radioButtonBeladeGPRS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonBeladeGPRS.Location = new System.Drawing.Point(119, 212);
            this.radioButtonBeladeGPRS.Name = "radioButtonBeladeGPRS";
            this.radioButtonBeladeGPRS.Size = new System.Drawing.Size(102, 20);
            this.radioButtonBeladeGPRS.TabIndex = 82;
            this.radioButtonBeladeGPRS.TabStop = false;
            this.radioButtonBeladeGPRS.Text = "Benutze GPRS";
            // 
            // radioButtonBeladeWIFI
            // 
            this.radioButtonBeladeWIFI.Checked = true;
            this.radioButtonBeladeWIFI.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonBeladeWIFI.Location = new System.Drawing.Point(7, 211);
            this.radioButtonBeladeWIFI.Name = "radioButtonBeladeWIFI";
            this.radioButtonBeladeWIFI.Size = new System.Drawing.Size(102, 20);
            this.radioButtonBeladeWIFI.TabIndex = 81;
            this.radioButtonBeladeWIFI.Text = "Benutze WIFI";
            // 
            // checkBoxIncludeBeladePhase
            // 
            this.checkBoxIncludeBeladePhase.Checked = true;
            this.checkBoxIncludeBeladePhase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeBeladePhase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxIncludeBeladePhase.Location = new System.Drawing.Point(7, 7);
            this.checkBoxIncludeBeladePhase.Name = "checkBoxIncludeBeladePhase";
            this.checkBoxIncludeBeladePhase.Size = new System.Drawing.Size(214, 22);
            this.checkBoxIncludeBeladePhase.TabIndex = 62;
            this.checkBoxIncludeBeladePhase.Text = "Beladephase im Test mitnehmen";
            // 
            // buttonPresetIntern3
            // 
            this.buttonPresetIntern3.Location = new System.Drawing.Point(7, 265);
            this.buttonPresetIntern3.Name = "buttonPresetIntern3";
            this.buttonPresetIntern3.Size = new System.Drawing.Size(94, 22);
            this.buttonPresetIntern3.TabIndex = 53;
            this.buttonPresetIntern3.Text = "Preset 1.3";
            this.buttonPresetIntern3.Click += new System.EventHandler(this.buttonPresetBeladeIntern3_Click);
            // 
            // buttonPresetBelade2
            // 
            this.buttonPresetBelade2.Location = new System.Drawing.Point(107, 237);
            this.buttonPresetBelade2.Name = "buttonPresetBelade2";
            this.buttonPresetBelade2.Size = new System.Drawing.Size(94, 22);
            this.buttonPresetBelade2.TabIndex = 27;
            this.buttonPresetBelade2.Text = "Preset 1.2";
            this.buttonPresetBelade2.Click += new System.EventHandler(this.buttonPreset2_Click);
            // 
            // buttonPresetBelade1
            // 
            this.buttonPresetBelade1.Location = new System.Drawing.Point(7, 237);
            this.buttonPresetBelade1.Name = "buttonPresetBelade1";
            this.buttonPresetBelade1.Size = new System.Drawing.Size(94, 22);
            this.buttonPresetBelade1.TabIndex = 26;
            this.buttonPresetBelade1.Text = "Preset 1.1";
            this.buttonPresetBelade1.Click += new System.EventHandler(this.buttonPreset1_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(7, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 22);
            this.label9.Text = "FTP Bulkgröße (MB)";
            // 
            // numericUpDownBeladeFTPBulkSize
            // 
            this.numericUpDownBeladeFTPBulkSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeFTPBulkSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Location = new System.Drawing.Point(154, 186);
            this.numericUpDownBeladeFTPBulkSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPBulkSize.Name = "numericUpDownBeladeFTPBulkSize";
            this.numericUpDownBeladeFTPBulkSize.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownBeladeFTPBulkSize.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(33, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 22);
            this.label7.Text = "Größe (Bytes)";
            // 
            // numericUpDownBeladeFTPSessionSize
            // 
            this.numericUpDownBeladeFTPSessionSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeFTPSessionSize.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessionSize.Location = new System.Drawing.Point(154, 164);
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
            this.numericUpDownBeladeFTPSessionSize.Size = new System.Drawing.Size(67, 20);
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
            this.numericUpDownBeladeFTPSessions.Location = new System.Drawing.Point(154, 142);
            this.numericUpDownBeladeFTPSessions.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeFTPSessions.Name = "numericUpDownBeladeFTPSessions";
            this.numericUpDownBeladeFTPSessions.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownBeladeFTPSessions.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(7, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 22);
            this.label6.Text = "Anzahl FTP";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(33, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 22);
            this.label5.Text = "Dauer (Sekunden)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 22);
            this.label4.Text = "Anzahl Photos";
            // 
            // numericUpDownBeladeSnapPhotoDurationSekunden
            // 
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Location = new System.Drawing.Point(154, 120);
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
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Size = new System.Drawing.Size(67, 20);
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
            this.numericUpDownBeladeSnapPhotos.Location = new System.Drawing.Point(154, 98);
            this.numericUpDownBeladeSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeSnapPhotos.Name = "numericUpDownBeladeSnapPhotos";
            this.numericUpDownBeladeSnapPhotos.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownBeladeSnapPhotos.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(33, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 22);
            this.label3.Text = "Dauer (Sekunden)";
            // 
            // numericUpDownBeladeScanBarcodeDurationSekunden
            // 
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Location = new System.Drawing.Point(154, 76);
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
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Size = new System.Drawing.Size(67, 20);
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
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 22);
            this.label2.Text = "Anzahl Scans";
            // 
            // numericUpDownBeladeScanBarcodes
            // 
            this.numericUpDownBeladeScanBarcodes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeScanBarcodes.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Location = new System.Drawing.Point(154, 54);
            this.numericUpDownBeladeScanBarcodes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownBeladeScanBarcodes.Name = "numericUpDownBeladeScanBarcodes";
            this.numericUpDownBeladeScanBarcodes.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownBeladeScanBarcodes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownBeladeLaufzeitStunden
            // 
            this.numericUpDownBeladeLaufzeitStunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownBeladeLaufzeitStunden.Location = new System.Drawing.Point(154, 32);
            this.numericUpDownBeladeLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBeladeLaufzeitStunden.Name = "numericUpDownBeladeLaufzeitStunden";
            this.numericUpDownBeladeLaufzeitStunden.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownBeladeLaufzeitStunden.TabIndex = 0;
            this.numericUpDownBeladeLaufzeitStunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageConfigFTP);
            this.tabControl1.Controls.Add(this.tabPageConfigBelade);
            this.tabControl1.Controls.Add(this.tabPageConfigTour);
            this.tabControl1.Controls.Add(this.tabPageConfigRuhe);
            this.tabControl1.Controls.Add(this.tabPageOutput);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageConfigFTP
            // 
            this.tabPageConfigFTP.AutoScroll = true;
            this.tabPageConfigFTP.BackColor = System.Drawing.SystemColors.Info;
            this.tabPageConfigFTP.Controls.Add(this.label26);
            this.tabPageConfigFTP.Controls.Add(this.textBoxGPRSEntry);
            this.tabPageConfigFTP.Controls.Add(this.label23);
            this.tabPageConfigFTP.Controls.Add(this.label24);
            this.tabPageConfigFTP.Controls.Add(this.textBoxGPRSKennwort);
            this.tabPageConfigFTP.Controls.Add(this.textBoxGPRSBenutzer);
            this.tabPageConfigFTP.Controls.Add(this.label25);
            this.tabPageConfigFTP.Controls.Add(this.textBoxGPRSAPN);
            this.tabPageConfigFTP.Controls.Add(this.checkBoxTestWWAN);
            this.tabPageConfigFTP.Controls.Add(this.checkBoxTestWLAN);
            this.tabPageConfigFTP.Controls.Add(this.radioButtonActive);
            this.tabPageConfigFTP.Controls.Add(this.radioButtonPassive);
            this.tabPageConfigFTP.Controls.Add(this.checkBoxLogFTP);
            this.tabPageConfigFTP.Controls.Add(this.textBoxTestFTP);
            this.tabPageConfigFTP.Controls.Add(this.buttonTestFTP);
            this.tabPageConfigFTP.Controls.Add(this.label16);
            this.tabPageConfigFTP.Controls.Add(this.label47);
            this.tabPageConfigFTP.Controls.Add(this.label46);
            this.tabPageConfigFTP.Controls.Add(this.textBoxDataKennwort);
            this.tabPageConfigFTP.Controls.Add(this.textBoxDataBenutzer);
            this.tabPageConfigFTP.Controls.Add(this.label8);
            this.tabPageConfigFTP.Controls.Add(this.textBoxDataServer);
            this.tabPageConfigFTP.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfigFTP.Name = "tabPageConfigFTP";
            this.tabPageConfigFTP.Size = new System.Drawing.Size(240, 297);
            this.tabPageConfigFTP.Text = "Config";
            this.tabPageConfigFTP.Click += new System.EventHandler(this.tabPageConfigFTP_Click);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label26.Location = new System.Drawing.Point(7, 145);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(111, 19);
            this.label26.Text = "GPRS ConnMgr Entry";
            // 
            // textBoxGPRSEntry
            // 
            this.textBoxGPRSEntry.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxGPRSEntry.Location = new System.Drawing.Point(124, 145);
            this.textBoxGPRSEntry.Name = "textBoxGPRSEntry";
            this.textBoxGPRSEntry.Size = new System.Drawing.Size(93, 19);
            this.textBoxGPRSEntry.TabIndex = 84;
            this.textBoxGPRSEntry.Text = "GPRS";
            this.textBoxGPRSEntry.LostFocus += new System.EventHandler(this.textBoxGPRSEntry_LostFocus);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label23.Location = new System.Drawing.Point(7, 220);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(111, 19);
            this.label23.Text = "Kennwort";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label24.Location = new System.Drawing.Point(7, 195);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 19);
            this.label24.Text = "Benutzer";
            // 
            // textBoxGPRSKennwort
            // 
            this.textBoxGPRSKennwort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxGPRSKennwort.Location = new System.Drawing.Point(124, 220);
            this.textBoxGPRSKennwort.Name = "textBoxGPRSKennwort";
            this.textBoxGPRSKennwort.Size = new System.Drawing.Size(93, 19);
            this.textBoxGPRSKennwort.TabIndex = 80;
            this.textBoxGPRSKennwort.Text = "internet";
            this.textBoxGPRSKennwort.LostFocus += new System.EventHandler(this.textBoxGPRSKennwort_LostFocus);
            // 
            // textBoxGPRSBenutzer
            // 
            this.textBoxGPRSBenutzer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxGPRSBenutzer.Location = new System.Drawing.Point(124, 195);
            this.textBoxGPRSBenutzer.Name = "textBoxGPRSBenutzer";
            this.textBoxGPRSBenutzer.Size = new System.Drawing.Size(93, 19);
            this.textBoxGPRSBenutzer.TabIndex = 79;
            this.textBoxGPRSBenutzer.Text = "internet";
            this.textBoxGPRSBenutzer.LostFocus += new System.EventHandler(this.textBoxGPRSBenutzer_LostFocus);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label25.Location = new System.Drawing.Point(7, 170);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(111, 19);
            this.label25.Text = "APN";
            // 
            // textBoxGPRSAPN
            // 
            this.textBoxGPRSAPN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxGPRSAPN.Location = new System.Drawing.Point(124, 170);
            this.textBoxGPRSAPN.Name = "textBoxGPRSAPN";
            this.textBoxGPRSAPN.Size = new System.Drawing.Size(93, 19);
            this.textBoxGPRSAPN.TabIndex = 78;
            this.textBoxGPRSAPN.Text = "internet";
            this.textBoxGPRSAPN.LostFocus += new System.EventHandler(this.textBoxGPRSAPN_LostFocus);
            // 
            // checkBoxTestWWAN
            // 
            this.checkBoxTestWWAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxTestWWAN.Location = new System.Drawing.Point(3, 123);
            this.checkBoxTestWWAN.Name = "checkBoxTestWWAN";
            this.checkBoxTestWWAN.Size = new System.Drawing.Size(115, 16);
            this.checkBoxTestWWAN.TabIndex = 70;
            this.checkBoxTestWWAN.Text = "GPRS an bei Test";
            // 
            // checkBoxTestWLAN
            // 
            this.checkBoxTestWLAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxTestWLAN.Location = new System.Drawing.Point(3, 101);
            this.checkBoxTestWLAN.Name = "checkBoxTestWLAN";
            this.checkBoxTestWLAN.Size = new System.Drawing.Size(115, 16);
            this.checkBoxTestWLAN.TabIndex = 69;
            this.checkBoxTestWLAN.Text = "WIFI an bei Test";
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.Checked = true;
            this.radioButtonActive.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonActive.Location = new System.Drawing.Point(124, 123);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(93, 16);
            this.radioButtonActive.TabIndex = 64;
            this.radioButtonActive.Text = "Aktiv (PORT)";
            this.radioButtonActive.CheckedChanged += new System.EventHandler(this.radioButtonActive_CheckedChanged);
            // 
            // radioButtonPassive
            // 
            this.radioButtonPassive.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonPassive.Location = new System.Drawing.Point(124, 101);
            this.radioButtonPassive.Name = "radioButtonPassive";
            this.radioButtonPassive.Size = new System.Drawing.Size(93, 16);
            this.radioButtonPassive.TabIndex = 63;
            this.radioButtonPassive.TabStop = false;
            this.radioButtonPassive.Text = "Passiv (PASV)";
            this.radioButtonPassive.CheckedChanged += new System.EventHandler(this.radioButtonPassive_CheckedChanged);
            // 
            // checkBoxLogFTP
            // 
            this.checkBoxLogFTP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxLogFTP.Location = new System.Drawing.Point(124, 4);
            this.checkBoxLogFTP.Name = "checkBoxLogFTP";
            this.checkBoxLogFTP.Size = new System.Drawing.Size(93, 16);
            this.checkBoxLogFTP.TabIndex = 58;
            this.checkBoxLogFTP.Text = "Log Sessions";
            this.checkBoxLogFTP.CheckStateChanged += new System.EventHandler(this.checkBoxLogFTP_CheckStateChanged);
            // 
            // textBoxTestFTP
            // 
            this.textBoxTestFTP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxTestFTP.Location = new System.Drawing.Point(7, 276);
            this.textBoxTestFTP.Multiline = true;
            this.textBoxTestFTP.Name = "textBoxTestFTP";
            this.textBoxTestFTP.ReadOnly = true;
            this.textBoxTestFTP.Size = new System.Drawing.Size(210, 121);
            this.textBoxTestFTP.TabIndex = 57;
            // 
            // buttonTestFTP
            // 
            this.buttonTestFTP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonTestFTP.Location = new System.Drawing.Point(7, 245);
            this.buttonTestFTP.Name = "buttonTestFTP";
            this.buttonTestFTP.Size = new System.Drawing.Size(210, 25);
            this.buttonTestFTP.TabIndex = 56;
            this.buttonTestFTP.Text = "Test FTP";
            this.buttonTestFTP.Click += new System.EventHandler(this.buttonTestFTP_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(7, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 19);
            this.label16.Text = "FTP Sessions";
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label47.Location = new System.Drawing.Point(7, 76);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(111, 19);
            this.label47.Text = "Kennwort";
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label46.Location = new System.Drawing.Point(7, 51);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(111, 19);
            this.label46.Text = "Benutzer";
            // 
            // textBoxDataKennwort
            // 
            this.textBoxDataKennwort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxDataKennwort.Location = new System.Drawing.Point(124, 76);
            this.textBoxDataKennwort.Name = "textBoxDataKennwort";
            this.textBoxDataKennwort.Size = new System.Drawing.Size(93, 19);
            this.textBoxDataKennwort.TabIndex = 54;
            this.textBoxDataKennwort.Text = "ftp";
            this.textBoxDataKennwort.LostFocus += new System.EventHandler(this.textBoxDataKennwort_LostFocus);
            // 
            // textBoxDataBenutzer
            // 
            this.textBoxDataBenutzer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxDataBenutzer.Location = new System.Drawing.Point(124, 51);
            this.textBoxDataBenutzer.Name = "textBoxDataBenutzer";
            this.textBoxDataBenutzer.Size = new System.Drawing.Size(93, 19);
            this.textBoxDataBenutzer.TabIndex = 53;
            this.textBoxDataBenutzer.Text = "ftp";
            this.textBoxDataBenutzer.LostFocus += new System.EventHandler(this.textBoxDataBenutzer_LostFocus);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(7, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 19);
            this.label8.Text = "Serveradresse";
            // 
            // textBoxDataServer
            // 
            this.textBoxDataServer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxDataServer.Location = new System.Drawing.Point(124, 26);
            this.textBoxDataServer.Name = "textBoxDataServer";
            this.textBoxDataServer.Size = new System.Drawing.Size(93, 19);
            this.textBoxDataServer.TabIndex = 52;
            this.textBoxDataServer.LostFocus += new System.EventHandler(this.textBoxDataServer_LostFocus);
            // 
            // tabPageConfigTour
            // 
            this.tabPageConfigTour.AutoScroll = true;
            this.tabPageConfigTour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourCycleDisplayAn);
            this.tabPageConfigTour.Controls.Add(this.label21);
            this.tabPageConfigTour.Controls.Add(this.checkBoxIncludeTourPhase);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourGPSIntervalSekunden);
            this.tabPageConfigTour.Controls.Add(this.label17);
            this.tabPageConfigTour.Controls.Add(this.label20);
            this.tabPageConfigTour.Controls.Add(this.label19);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourFTPSessionSize);
            this.tabPageConfigTour.Controls.Add(this.buttonPresetTour2);
            this.tabPageConfigTour.Controls.Add(this.buttonPresetTour1);
            this.tabPageConfigTour.Controls.Add(this.label37);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourCycleIntervalMinuten);
            this.tabPageConfigTour.Controls.Add(this.label39);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourCycleFTPSessionSize);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourFTPSessionIntervalSekunden);
            this.tabPageConfigTour.Controls.Add(this.label40);
            this.tabPageConfigTour.Controls.Add(this.label41);
            this.tabPageConfigTour.Controls.Add(this.label42);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourSnapPhotoDurationSekunden);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourSnapPhotos);
            this.tabPageConfigTour.Controls.Add(this.label43);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourCycleScanBarcodeDurationSekunden);
            this.tabPageConfigTour.Controls.Add(this.label44);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourCycleScanBarcodes);
            this.tabPageConfigTour.Controls.Add(this.label45);
            this.tabPageConfigTour.Controls.Add(this.numericUpDownTourLaufzeitStunden);
            this.tabPageConfigTour.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfigTour.Name = "tabPageConfigTour";
            this.tabPageConfigTour.Size = new System.Drawing.Size(232, 294);
            this.tabPageConfigTour.Text = "Tour";
            this.tabPageConfigTour.Click += new System.EventHandler(this.tabPageConfigTour_Click);
            // 
            // numericUpDownTourCycleDisplayAn
            // 
            this.numericUpDownTourCycleDisplayAn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleDisplayAn.Location = new System.Drawing.Point(158, 215);
            this.numericUpDownTourCycleDisplayAn.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTourCycleDisplayAn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourCycleDisplayAn.Name = "numericUpDownTourCycleDisplayAn";
            this.numericUpDownTourCycleDisplayAn.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownTourCycleDisplayAn.TabIndex = 83;
            this.numericUpDownTourCycleDisplayAn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label21.Location = new System.Drawing.Point(37, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 17);
            this.label21.Text = "Display an (Minuten)";
            // 
            // checkBoxIncludeTourPhase
            // 
            this.checkBoxIncludeTourPhase.Checked = true;
            this.checkBoxIncludeTourPhase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeTourPhase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxIncludeTourPhase.Location = new System.Drawing.Point(7, 7);
            this.checkBoxIncludeTourPhase.Name = "checkBoxIncludeTourPhase";
            this.checkBoxIncludeTourPhase.Size = new System.Drawing.Size(216, 23);
            this.checkBoxIncludeTourPhase.TabIndex = 80;
            this.checkBoxIncludeTourPhase.Text = "Tourphase im Test mitnehmen";
            // 
            // numericUpDownTourGPSIntervalSekunden
            // 
            this.numericUpDownTourGPSIntervalSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourGPSIntervalSekunden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Location = new System.Drawing.Point(158, 151);
            this.numericUpDownTourGPSIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourGPSIntervalSekunden.Name = "numericUpDownTourGPSIntervalSekunden";
            this.numericUpDownTourGPSIntervalSekunden.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownTourGPSIntervalSekunden.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(20, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 17);
            this.label17.Text = "Interval GPS (Sekunden)";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(7, 175);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 17);
            this.label20.Text = "Auslieferung:";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label19.Location = new System.Drawing.Point(37, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 17);
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
            this.numericUpDownTourFTPSessionSize.Location = new System.Drawing.Point(158, 128);
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
            this.numericUpDownTourFTPSessionSize.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownTourFTPSessionSize.TabIndex = 57;
            this.numericUpDownTourFTPSessionSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPresetTour2
            // 
            this.buttonPresetTour2.Location = new System.Drawing.Point(115, 310);
            this.buttonPresetTour2.Name = "buttonPresetTour2";
            this.buttonPresetTour2.Size = new System.Drawing.Size(102, 27);
            this.buttonPresetTour2.TabIndex = 27;
            this.buttonPresetTour2.Text = "Preset 1.2";
            this.buttonPresetTour2.Click += new System.EventHandler(this.buttonPresetTour2_Click);
            // 
            // buttonPresetTour1
            // 
            this.buttonPresetTour1.Location = new System.Drawing.Point(7, 310);
            this.buttonPresetTour1.Name = "buttonPresetTour1";
            this.buttonPresetTour1.Size = new System.Drawing.Size(102, 27);
            this.buttonPresetTour1.TabIndex = 26;
            this.buttonPresetTour1.Text = "Preset 1.1";
            this.buttonPresetTour1.Click += new System.EventHandler(this.buttonPresetTour1_Click);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label37.Location = new System.Drawing.Point(20, 192);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(129, 17);
            this.label37.Text = "Interval (Minuten)";
            // 
            // numericUpDownTourCycleIntervalMinuten
            // 
            this.numericUpDownTourCycleIntervalMinuten.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleIntervalMinuten.Location = new System.Drawing.Point(158, 192);
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
            this.numericUpDownTourCycleIntervalMinuten.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownTourCycleIntervalMinuten.TabIndex = 23;
            this.numericUpDownTourCycleIntervalMinuten.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTourCycleIntervalMinuten.ValueChanged += new System.EventHandler(this.numericUpDownTourCycleIntervalMinuten_ValueChanged);
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label39.Location = new System.Drawing.Point(20, 284);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(129, 17);
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
            this.numericUpDownTourCycleFTPSessionSize.Location = new System.Drawing.Point(157, 284);
            this.numericUpDownTourCycleFTPSessionSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numericUpDownTourCycleFTPSessionSize.Name = "numericUpDownTourCycleFTPSessionSize";
            this.numericUpDownTourCycleFTPSessionSize.Size = new System.Drawing.Size(63, 20);
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
            this.numericUpDownTourFTPSessionIntervalSekunden.Location = new System.Drawing.Point(158, 105);
            this.numericUpDownTourFTPSessionIntervalSekunden.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownTourFTPSessionIntervalSekunden.Name = "numericUpDownTourFTPSessionIntervalSekunden";
            this.numericUpDownTourFTPSessionIntervalSekunden.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownTourFTPSessionIntervalSekunden.TabIndex = 16;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label40.Location = new System.Drawing.Point(20, 101);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(129, 17);
            this.label40.Text = "Interval FTP (Sekunden)";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label41.Location = new System.Drawing.Point(37, 81);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(97, 17);
            this.label41.Text = "Dauer (Sekunden)";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label42.Location = new System.Drawing.Point(20, 59);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 17);
            this.label42.Text = "Anzahl Photos";
            // 
            // numericUpDownTourSnapPhotoDurationSekunden
            // 
            this.numericUpDownTourSnapPhotoDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourSnapPhotoDurationSekunden.Location = new System.Drawing.Point(158, 82);
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
            this.numericUpDownTourSnapPhotoDurationSekunden.Size = new System.Drawing.Size(63, 20);
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
            this.numericUpDownTourSnapPhotos.Location = new System.Drawing.Point(158, 59);
            this.numericUpDownTourSnapPhotos.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownTourSnapPhotos.Name = "numericUpDownTourSnapPhotos";
            this.numericUpDownTourSnapPhotos.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownTourSnapPhotos.TabIndex = 8;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label43.Location = new System.Drawing.Point(37, 261);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(112, 17);
            this.label43.Text = "Dauer (Sekunden)";
            // 
            // numericUpDownTourCycleScanBarcodeDurationSekunden
            // 
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Location = new System.Drawing.Point(157, 261);
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
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Size = new System.Drawing.Size(63, 20);
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
            this.label44.Location = new System.Drawing.Point(20, 238);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(72, 17);
            this.label44.Text = "Anzahl Scans";
            // 
            // numericUpDownTourCycleScanBarcodes
            // 
            this.numericUpDownTourCycleScanBarcodes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourCycleScanBarcodes.Location = new System.Drawing.Point(158, 238);
            this.numericUpDownTourCycleScanBarcodes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTourCycleScanBarcodes.Name = "numericUpDownTourCycleScanBarcodes";
            this.numericUpDownTourCycleScanBarcodes.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownTourCycleScanBarcodes.TabIndex = 2;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label45.Location = new System.Drawing.Point(20, 36);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(129, 17);
            this.label45.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownTourLaufzeitStunden
            // 
            this.numericUpDownTourLaufzeitStunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownTourLaufzeitStunden.Location = new System.Drawing.Point(158, 36);
            this.numericUpDownTourLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTourLaufzeitStunden.Name = "numericUpDownTourLaufzeitStunden";
            this.numericUpDownTourLaufzeitStunden.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownTourLaufzeitStunden.TabIndex = 0;
            this.numericUpDownTourLaufzeitStunden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPageConfigRuhe
            // 
            this.tabPageConfigRuhe.AutoScroll = true;
            this.tabPageConfigRuhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPageConfigRuhe.Controls.Add(this.radioButtonRuheUnattended);
            this.tabPageConfigRuhe.Controls.Add(this.radioButtonRuheSuspend);
            this.tabPageConfigRuhe.Controls.Add(this.label27);
            this.tabPageConfigRuhe.Controls.Add(this.numericUpDownRuheLaufzeitMinuten);
            this.tabPageConfigRuhe.Controls.Add(this.label22);
            this.tabPageConfigRuhe.Controls.Add(this.numericUpDownRuheLaufzeitStunden);
            this.tabPageConfigRuhe.Controls.Add(this.checkBoxIncludeRuhePhase);
            this.tabPageConfigRuhe.Location = new System.Drawing.Point(0, 0);
            this.tabPageConfigRuhe.Name = "tabPageConfigRuhe";
            this.tabPageConfigRuhe.Size = new System.Drawing.Size(232, 294);
            this.tabPageConfigRuhe.Text = "Ruhe";
            // 
            // radioButtonRuheUnattended
            // 
            this.radioButtonRuheUnattended.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonRuheUnattended.Location = new System.Drawing.Point(6, 114);
            this.radioButtonRuheUnattended.Name = "radioButtonRuheUnattended";
            this.radioButtonRuheUnattended.Size = new System.Drawing.Size(186, 21);
            this.radioButtonRuheUnattended.TabIndex = 91;
            this.radioButtonRuheUnattended.TabStop = false;
            this.radioButtonRuheUnattended.Text = "Gerät in Unattended (Slumber)";
            // 
            // radioButtonRuheSuspend
            // 
            this.radioButtonRuheSuspend.Checked = true;
            this.radioButtonRuheSuspend.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonRuheSuspend.Location = new System.Drawing.Point(7, 87);
            this.radioButtonRuheSuspend.Name = "radioButtonRuheSuspend";
            this.radioButtonRuheSuspend.Size = new System.Drawing.Size(185, 21);
            this.radioButtonRuheSuspend.TabIndex = 90;
            this.radioButtonRuheSuspend.Text = "Gerät in Suspend (Power Down)";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label27.Location = new System.Drawing.Point(32, 61);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 17);
            this.label27.Text = "(Minuten)";
            this.label27.Visible = false;
            // 
            // numericUpDownRuheLaufzeitMinuten
            // 
            this.numericUpDownRuheLaufzeitMinuten.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownRuheLaufzeitMinuten.Location = new System.Drawing.Point(136, 61);
            this.numericUpDownRuheLaufzeitMinuten.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownRuheLaufzeitMinuten.Name = "numericUpDownRuheLaufzeitMinuten";
            this.numericUpDownRuheLaufzeitMinuten.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownRuheLaufzeitMinuten.TabIndex = 85;
            this.numericUpDownRuheLaufzeitMinuten.Visible = false;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label22.Location = new System.Drawing.Point(7, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 19);
            this.label22.Text = "Laufzeit (Stunden)";
            // 
            // numericUpDownRuheLaufzeitStunden
            // 
            this.numericUpDownRuheLaufzeitStunden.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownRuheLaufzeitStunden.Location = new System.Drawing.Point(136, 33);
            this.numericUpDownRuheLaufzeitStunden.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownRuheLaufzeitStunden.Name = "numericUpDownRuheLaufzeitStunden";
            this.numericUpDownRuheLaufzeitStunden.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownRuheLaufzeitStunden.TabIndex = 83;
            this.numericUpDownRuheLaufzeitStunden.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // checkBoxIncludeRuhePhase
            // 
            this.checkBoxIncludeRuhePhase.Checked = true;
            this.checkBoxIncludeRuhePhase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeRuhePhase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxIncludeRuhePhase.Location = new System.Drawing.Point(7, 3);
            this.checkBoxIncludeRuhePhase.Name = "checkBoxIncludeRuhePhase";
            this.checkBoxIncludeRuhePhase.Size = new System.Drawing.Size(210, 24);
            this.checkBoxIncludeRuhePhase.TabIndex = 81;
            this.checkBoxIncludeRuhePhase.Text = "Ruhephase im Test mitnehmen";
            // 
            // timerPlanGPS
            // 
            this.timerPlanGPS.Tick += new System.EventHandler(this.timerPlanGPS_Tick);
            // 
            // timerPlanTourCycle
            // 
            this.timerPlanTourCycle.Tick += new System.EventHandler(this.timerPlanTourCycle_Tick);
            // 
            // timerExecGPS
            // 
            this.timerExecGPS.Interval = 10000;
            this.timerExecGPS.Tick += new System.EventHandler(this.timerExecGPS_Tick);
            // 
            // timerManageUnattended
            // 
            this.timerManageUnattended.Interval = 60000;
            this.timerManageUnattended.Tick += new System.EventHandler(this.timerRuheUnattended_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Battery Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageOutput.ResumeLayout(false);
            this.tabPageConfigBelade.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageConfigFTP.ResumeLayout(false);
            this.tabPageConfigTour.ResumeLayout(false);
            this.tabPageConfigRuhe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerStateMachine;
        private System.Windows.Forms.Timer timerPlanPhoto;
        private System.Windows.Forms.Timer timerPlanScan;
        private System.Windows.Forms.Timer timerPlanData;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemStart;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.Timer timerExecPhoto;
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
        private System.Windows.Forms.TabPage tabPageConfigBelade;
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
        private System.Windows.Forms.TabPage tabPageConfigTour;
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
        private System.Windows.Forms.Timer timerPlanGPS;
        private System.Windows.Forms.Timer timerPlanTourCycle;
        private System.Windows.Forms.TabPage tabPageConfigFTP;
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
        private System.Windows.Forms.Timer timerExecGPS;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.RadioButton radioButtonPassive;
        private System.Windows.Forms.CheckBox checkBoxIncludeBeladePhase;
        private System.Windows.Forms.TabPage tabPageConfigRuhe;
        private System.Windows.Forms.CheckBox checkBoxIncludeTourPhase;
        private System.Windows.Forms.NumericUpDown numericUpDownTourCycleDisplayAn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBoxIncludeRuhePhase;
        private System.Windows.Forms.CheckBox checkBoxTestWWAN;
        private System.Windows.Forms.CheckBox checkBoxTestWLAN;
        private System.Windows.Forms.TextBox textBoxGPRSEntry;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxGPRSKennwort;
        private System.Windows.Forms.TextBox textBoxGPRSBenutzer;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxGPRSAPN;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericUpDownRuheLaufzeitStunden;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDownRuheLaufzeitMinuten;
        private System.Windows.Forms.Label labelCurrentPhase;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button buttonSkipPhase;
        private System.Windows.Forms.RadioButton radioButtonRuheUnattended;
        private System.Windows.Forms.RadioButton radioButtonRuheSuspend;
        private System.Windows.Forms.RadioButton radioButtonBeladeGPRS;
        private System.Windows.Forms.RadioButton radioButtonBeladeWIFI;
        private System.Windows.Forms.Timer timerManageUnattended;
    }
}

