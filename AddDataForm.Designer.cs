namespace RL_DBMU
{
    partial class AddDataForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.wins = new System.Windows.Forms.NumericUpDown();
            this.games = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playernameValue = new System.Windows.Forms.Label();
            this.idValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.goals = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.shots = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.assist = new System.Windows.Forms.NumericUpDown();
            this.save = new System.Windows.Forms.NumericUpDown();
            this.center = new System.Windows.Forms.NumericUpDown();
            this.clear = new System.Windows.Forms.NumericUpDown();
            this.savior = new System.Windows.Forms.NumericUpDown();
            this.demo = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.v3 = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.v2 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.v1 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.gamesDiff = new System.Windows.Forms.Label();
            this.winsDiff = new System.Windows.Forms.Label();
            this.goalsDiff = new System.Windows.Forms.Label();
            this.shotsDiff = new System.Windows.Forms.Label();
            this.assitDiff = new System.Windows.Forms.Label();
            this.savesDiff = new System.Windows.Forms.Label();
            this.centerDiff = new System.Windows.Forms.Label();
            this.clearDiff = new System.Windows.Forms.Label();
            this.saviorDiff = new System.Windows.Forms.Label();
            this.demoDiff = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.games)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Daten eintragen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wins
            // 
            this.wins.Location = new System.Drawing.Point(126, 35);
            this.wins.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.wins.Name = "wins";
            this.wins.Size = new System.Drawing.Size(117, 20);
            this.wins.TabIndex = 1;
            this.wins.ValueChanged += new System.EventHandler(this.wins_ValueChanged);
            // 
            // games
            // 
            this.games.Location = new System.Drawing.Point(126, 3);
            this.games.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.games.Name = "games";
            this.games.Size = new System.Drawing.Size(117, 20);
            this.games.TabIndex = 2;
            this.games.ValueChanged += new System.EventHandler(this.games_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Spiele";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Siege";
            // 
            // playernameValue
            // 
            this.playernameValue.AutoSize = true;
            this.playernameValue.Location = new System.Drawing.Point(110, 0);
            this.playernameValue.Name = "playernameValue";
            this.playernameValue.Size = new System.Drawing.Size(77, 13);
            this.playernameValue.TabIndex = 5;
            this.playernameValue.Text = "%playername%";
            // 
            // idValue
            // 
            this.idValue.AutoSize = true;
            this.idValue.Location = new System.Drawing.Point(110, 36);
            this.idValue.Name = "idValue";
            this.idValue.Size = new System.Drawing.Size(31, 13);
            this.idValue.TabIndex = 6;
            this.idValue.Text = "%id%";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.wins, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.games, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.goals, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.shots, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.assist, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.save, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.center, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.clear, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.savior, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.demo, 1, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(284, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.18033F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.81967F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 342);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.idValue, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.playernameValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nameValue, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(215, 102);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Spielername";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Spielernummer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Name";
            // 
            // nameValue
            // 
            this.nameValue.AutoSize = true;
            this.nameValue.Location = new System.Drawing.Point(110, 68);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(49, 13);
            this.nameValue.TabIndex = 8;
            this.nameValue.Text = "%name%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tore";
            // 
            // goals
            // 
            this.goals.Location = new System.Drawing.Point(126, 68);
            this.goals.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.goals.Name = "goals";
            this.goals.Size = new System.Drawing.Size(117, 20);
            this.goals.TabIndex = 5;
            this.goals.ValueChanged += new System.EventHandler(this.goals_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Torschüsse";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // shots
            // 
            this.shots.Location = new System.Drawing.Point(126, 103);
            this.shots.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.shots.Name = "shots";
            this.shots.Size = new System.Drawing.Size(117, 20);
            this.shots.TabIndex = 8;
            this.shots.ValueChanged += new System.EventHandler(this.shots_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Felder zurücksetzten";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(148, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Fenster schließen";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Vorlagen";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Paraden";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Hereingaben";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Befreiungsschläge";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 271);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Retter";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 309);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Zerstörungen";
            // 
            // assist
            // 
            this.assist.Location = new System.Drawing.Point(126, 139);
            this.assist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.assist.Name = "assist";
            this.assist.Size = new System.Drawing.Size(117, 20);
            this.assist.TabIndex = 15;
            this.assist.ValueChanged += new System.EventHandler(this.assist_ValueChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(126, 176);
            this.save.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(117, 20);
            this.save.TabIndex = 16;
            this.save.ValueChanged += new System.EventHandler(this.save_ValueChanged);
            // 
            // center
            // 
            this.center.Location = new System.Drawing.Point(126, 207);
            this.center.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(117, 20);
            this.center.TabIndex = 17;
            this.center.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(126, 241);
            this.clear.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(117, 20);
            this.clear.TabIndex = 18;
            this.clear.ValueChanged += new System.EventHandler(this.clear_ValueChanged);
            // 
            // savior
            // 
            this.savior.Location = new System.Drawing.Point(126, 274);
            this.savior.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.savior.Name = "savior";
            this.savior.Size = new System.Drawing.Size(117, 20);
            this.savior.TabIndex = 19;
            this.savior.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // demo
            // 
            this.demo.Location = new System.Drawing.Point(126, 312);
            this.demo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.demo.Name = "demo";
            this.demo.Size = new System.Drawing.Size(117, 20);
            this.demo.TabIndex = 20;
            this.demo.ValueChanged += new System.EventHandler(this.demo_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.v3);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(12, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 41);
            this.panel1.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "3v3";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // v3
            // 
            this.v3.Location = new System.Drawing.Point(51, 11);
            this.v3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.v3.Name = "v3";
            this.v3.Size = new System.Drawing.Size(117, 20);
            this.v3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.v2);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Location = new System.Drawing.Point(12, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 41);
            this.panel2.TabIndex = 12;
            // 
            // v2
            // 
            this.v2.Location = new System.Drawing.Point(51, 11);
            this.v2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.v2.Name = "v2";
            this.v2.Size = new System.Drawing.Size(117, 20);
            this.v2.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "2v2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.v1);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Location = new System.Drawing.Point(12, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 41);
            this.panel3.TabIndex = 12;
            // 
            // v1
            // 
            this.v1.Location = new System.Drawing.Point(51, 11);
            this.v1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(117, 20);
            this.v1.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "1v1";
            // 
            // gamesDiff
            // 
            this.gamesDiff.AutoSize = true;
            this.gamesDiff.ForeColor = System.Drawing.Color.Green;
            this.gamesDiff.Location = new System.Drawing.Point(245, 12);
            this.gamesDiff.Name = "gamesDiff";
            this.gamesDiff.Size = new System.Drawing.Size(36, 13);
            this.gamesDiff.TabIndex = 4;
            this.gamesDiff.Text = "Spiele";
            this.gamesDiff.Visible = false;
            // 
            // winsDiff
            // 
            this.winsDiff.AutoSize = true;
            this.winsDiff.ForeColor = System.Drawing.Color.Green;
            this.winsDiff.Location = new System.Drawing.Point(245, 44);
            this.winsDiff.Name = "winsDiff";
            this.winsDiff.Size = new System.Drawing.Size(36, 13);
            this.winsDiff.TabIndex = 13;
            this.winsDiff.Text = "Spiele";
            this.winsDiff.Visible = false;
            // 
            // goalsDiff
            // 
            this.goalsDiff.AutoSize = true;
            this.goalsDiff.ForeColor = System.Drawing.Color.Green;
            this.goalsDiff.Location = new System.Drawing.Point(245, 77);
            this.goalsDiff.Name = "goalsDiff";
            this.goalsDiff.Size = new System.Drawing.Size(36, 13);
            this.goalsDiff.TabIndex = 14;
            this.goalsDiff.Text = "Spiele";
            this.goalsDiff.Visible = false;
            // 
            // shotsDiff
            // 
            this.shotsDiff.AutoSize = true;
            this.shotsDiff.ForeColor = System.Drawing.Color.Green;
            this.shotsDiff.Location = new System.Drawing.Point(245, 112);
            this.shotsDiff.Name = "shotsDiff";
            this.shotsDiff.Size = new System.Drawing.Size(36, 13);
            this.shotsDiff.TabIndex = 15;
            this.shotsDiff.Text = "Spiele";
            this.shotsDiff.Visible = false;
            // 
            // assitDiff
            // 
            this.assitDiff.AutoSize = true;
            this.assitDiff.ForeColor = System.Drawing.Color.Green;
            this.assitDiff.Location = new System.Drawing.Point(245, 148);
            this.assitDiff.Name = "assitDiff";
            this.assitDiff.Size = new System.Drawing.Size(36, 13);
            this.assitDiff.TabIndex = 16;
            this.assitDiff.Text = "Spiele";
            this.assitDiff.Visible = false;
            // 
            // savesDiff
            // 
            this.savesDiff.AutoSize = true;
            this.savesDiff.ForeColor = System.Drawing.Color.Green;
            this.savesDiff.Location = new System.Drawing.Point(245, 185);
            this.savesDiff.Name = "savesDiff";
            this.savesDiff.Size = new System.Drawing.Size(36, 13);
            this.savesDiff.TabIndex = 17;
            this.savesDiff.Text = "Spiele";
            this.savesDiff.Visible = false;
            this.savesDiff.Click += new System.EventHandler(this.label22_Click);
            // 
            // centerDiff
            // 
            this.centerDiff.AutoSize = true;
            this.centerDiff.ForeColor = System.Drawing.Color.Green;
            this.centerDiff.Location = new System.Drawing.Point(245, 216);
            this.centerDiff.Name = "centerDiff";
            this.centerDiff.Size = new System.Drawing.Size(36, 13);
            this.centerDiff.TabIndex = 18;
            this.centerDiff.Text = "Spiele";
            this.centerDiff.Visible = false;
            // 
            // clearDiff
            // 
            this.clearDiff.AutoSize = true;
            this.clearDiff.ForeColor = System.Drawing.Color.Green;
            this.clearDiff.Location = new System.Drawing.Point(245, 250);
            this.clearDiff.Name = "clearDiff";
            this.clearDiff.Size = new System.Drawing.Size(36, 13);
            this.clearDiff.TabIndex = 19;
            this.clearDiff.Text = "Spiele";
            this.clearDiff.Visible = false;
            // 
            // saviorDiff
            // 
            this.saviorDiff.AutoSize = true;
            this.saviorDiff.ForeColor = System.Drawing.Color.Green;
            this.saviorDiff.Location = new System.Drawing.Point(245, 283);
            this.saviorDiff.Name = "saviorDiff";
            this.saviorDiff.Size = new System.Drawing.Size(36, 13);
            this.saviorDiff.TabIndex = 20;
            this.saviorDiff.Text = "Spiele";
            this.saviorDiff.Visible = false;
            // 
            // demoDiff
            // 
            this.demoDiff.AutoSize = true;
            this.demoDiff.ForeColor = System.Drawing.Color.Green;
            this.demoDiff.Location = new System.Drawing.Point(245, 321);
            this.demoDiff.Name = "demoDiff";
            this.demoDiff.Size = new System.Drawing.Size(36, 13);
            this.demoDiff.TabIndex = 21;
            this.demoDiff.Text = "Spiele";
            this.demoDiff.Visible = false;
            // 
            // AddDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 450);
            this.Controls.Add(this.demoDiff);
            this.Controls.Add(this.saviorDiff);
            this.Controls.Add(this.clearDiff);
            this.Controls.Add(this.centerDiff);
            this.Controls.Add(this.savesDiff);
            this.Controls.Add(this.assitDiff);
            this.Controls.Add(this.shotsDiff);
            this.Controls.Add(this.goalsDiff);
            this.Controls.Add(this.winsDiff);
            this.Controls.Add(this.gamesDiff);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Name = "AddDataForm";
            this.Text = "AddDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.wins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.games)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown wins;
        private System.Windows.Forms.NumericUpDown games;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playernameValue;
        private System.Windows.Forms.Label idValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nameValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown goals;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown shots;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown assist;
        private System.Windows.Forms.NumericUpDown save;
        private System.Windows.Forms.NumericUpDown center;
        private System.Windows.Forms.NumericUpDown clear;
        private System.Windows.Forms.NumericUpDown savior;
        private System.Windows.Forms.NumericUpDown demo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown v3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown v2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown v1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label gamesDiff;
        private System.Windows.Forms.Label winsDiff;
        private System.Windows.Forms.Label goalsDiff;
        private System.Windows.Forms.Label shotsDiff;
        private System.Windows.Forms.Label assitDiff;
        private System.Windows.Forms.Label savesDiff;
        private System.Windows.Forms.Label centerDiff;
        private System.Windows.Forms.Label clearDiff;
        private System.Windows.Forms.Label saviorDiff;
        private System.Windows.Forms.Label demoDiff;
    }
}