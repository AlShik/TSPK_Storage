namespace База_ТСПК
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vocabularyPUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSPKDataSet = new База_ТСПК.TSPKDataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.vocabularyPunktPropuskaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSPKDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.vocabularyPodrazdelenieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.vocabulary_PUTableAdapter = new База_ТСПК.TSPKDataSetTableAdapters.Vocabulary_PUTableAdapter();
            this.vocabulary_PodrazdelenieTableAdapter = new База_ТСПК.TSPKDataSetTableAdapters.Vocabulary_PodrazdelenieTableAdapter();
            this.vocabulary_PunktPropuska_TableAdapter = new База_ТСПК.TSPKDataSetTableAdapters.Vocabulary_PunktPropuska_TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPKDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPunktPropuskaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPKDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPodrazdelenieBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Перейти в подразделение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.vocabularyPUBindingSource;
            this.comboBox1.DisplayMember = "ПУ";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(36, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(241, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // vocabularyPUBindingSource
            // 
            this.vocabularyPUBindingSource.DataMember = "Vocabulary_PU";
            this.vocabularyPUBindingSource.DataSource = this.tSPKDataSet;
            // 
            // tSPKDataSet
            // 
            this.tSPKDataSet.DataSetName = "TSPKDataSet";
            this.tSPKDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пограничное Управление";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите...";
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.vocabularyPunktPropuskaBindingSource;
            this.comboBox3.DisplayMember = "PunktPropuska";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(36, 126);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(241, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // vocabularyPunktPropuskaBindingSource
            // 
            this.vocabularyPunktPropuskaBindingSource.DataMember = "Vocabulary_PunktPropuska ";
            this.vocabularyPunktPropuskaBindingSource.DataSource = this.tSPKDataSetBindingSource;
            // 
            // tSPKDataSetBindingSource
            // 
            this.tSPKDataSetBindingSource.DataSource = this.tSPKDataSet;
            this.tSPKDataSetBindingSource.Position = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пункт Пропуска";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.vocabularyPodrazdelenieBindingSource;
            this.comboBox2.DisplayMember = "Podrazdelenie";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(36, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(241, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // vocabularyPodrazdelenieBindingSource
            // 
            this.vocabularyPodrazdelenieBindingSource.DataMember = "Vocabulary_Podrazdelenie";
            this.vocabularyPodrazdelenieBindingSource.DataSource = this.tSPKDataSetBindingSource;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Подразделение";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(148, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 27);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.Location = new System.Drawing.Point(120, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(22, 27);
            this.button12.TabIndex = 18;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            this.button12.MouseHover += new System.EventHandler(this.button12_MouseHover);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.Location = new System.Drawing.Point(92, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(22, 27);
            this.button11.TabIndex = 17;
            this.toolTip1.SetToolTip(this.button11, "Редактирование Справочников");
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Location = new System.Drawing.Point(64, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(22, 27);
            this.button10.TabIndex = 16;
            this.toolTip1.SetToolTip(this.button10, "Работа с расходными материалами");
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Location = new System.Drawing.Point(36, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(22, 27);
            this.button9.TabIndex = 15;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseHover += new System.EventHandler(this.button9_MouseHover);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 27);
            this.button4.TabIndex = 14;
            this.toolTip1.SetToolTip(this.button4, "Добавить ТСПК");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // vocabulary_PUTableAdapter
            // 
            this.vocabulary_PUTableAdapter.ClearBeforeFill = true;
            // 
            // vocabulary_PodrazdelenieTableAdapter
            // 
            this.vocabulary_PodrazdelenieTableAdapter.ClearBeforeFill = true;
            // 
            // vocabulary_PunktPropuska_TableAdapter
            // 
            this.vocabulary_PunktPropuska_TableAdapter.ClearBeforeFill = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(490, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(506, 342);
            this.MinimumSize = new System.Drawing.Size(506, 342);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор местонахождения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPKDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPunktPropuskaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPKDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vocabularyPodrazdelenieBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private TSPKDataSet tSPKDataSet;
        private System.Windows.Forms.BindingSource vocabularyPUBindingSource;
        private TSPKDataSetTableAdapters.Vocabulary_PUTableAdapter vocabulary_PUTableAdapter;
        private System.Windows.Forms.BindingSource tSPKDataSetBindingSource;
        private System.Windows.Forms.BindingSource vocabularyPodrazdelenieBindingSource;
        private TSPKDataSetTableAdapters.Vocabulary_PodrazdelenieTableAdapter vocabulary_PodrazdelenieTableAdapter;
        private System.Windows.Forms.BindingSource vocabularyPunktPropuskaBindingSource;
        private TSPKDataSetTableAdapters.Vocabulary_PunktPropuska_TableAdapter vocabulary_PunktPropuska_TableAdapter;
        private System.Windows.Forms.Button button2;
      
        
       
    }
}