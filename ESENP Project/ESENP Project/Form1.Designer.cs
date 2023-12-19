namespace ESENP_Project
{
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            Form_Label = new Label();
            buttonSave = new Button();
            buttonMain = new Button();
            textBoxMain = new TextBox();
            labelData = new Label();
            MytoolTip = new ToolTip(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(labelData);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(buttonMain);
            groupBox1.Controls.Add(textBoxMain);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1339, 785);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            MytoolTip.SetToolTip(groupBox1, "Add");
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(Form_Label);
            groupBox2.Controls.Add(buttonSave);
            groupBox2.Location = new Point(12, 472);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1321, 287);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // Form_Label
            // 
            Form_Label.AutoSize = true;
            //Form_Label.BackColor = Color.LightSeaGreen;
            Form_Label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            Form_Label.Location = new Point(608, 23);
            Form_Label.Name = "Form_Label";
            Form_Label.Size = new Size(0, 28);
            Form_Label.TabIndex = 1;
            Form_Label.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Teal;
            buttonSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ActiveCaptionText;
            buttonSave.Location = new Point(1196, 23);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 43);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Visible = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonMain
            // 
            buttonMain.Image = (Image)resources.GetObject("buttonMain.Image");
            buttonMain.Location = new Point(874, 15);
            buttonMain.Name = "buttonMain";
            buttonMain.Size = new Size(44, 43);
            buttonMain.TabIndex = 1;
            MytoolTip.SetToolTip(buttonMain, "Add");
            buttonMain.UseVisualStyleBackColor = true;
            buttonMain.Click += buttonMain_Click;
            // 
            // textBoxMain
            // 
            textBoxMain.Location = new Point(646, 23);
            textBoxMain.Name = "textBoxMain";
            textBoxMain.Size = new Size(222, 27);
            textBoxMain.TabIndex = 0;
            textBoxMain.TextChanged += textBoxMain_TextChanged;
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(560, 26);
            labelData.Name = "labelData";
            labelData.Size = new Size(79, 20);
            labelData.TabIndex = 2;
            labelData.Text = "Enter Data";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1344, 664);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonMain;
        private TextBox textBoxMain;
        private GroupBox groupBox2;
        private Button buttonSave;
        private Label Form_Label;
        private Label labelData;
        private ToolTip MytoolTip;
    }
}