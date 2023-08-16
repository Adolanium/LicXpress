namespace LicXpress
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
            groupBox1 = new GroupBox();
            serialTextBox = new TextBox();
            groupBox2 = new GroupBox();
            versionListBox = new ListBox();
            groupBox3 = new GroupBox();
            productListBox = new ListBox();
            generateBtn = new Button();
            groupBox4 = new GroupBox();
            codeTextBox = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(serialTextBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 57);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Serial number:";
            // 
            // serialTextBox
            // 
            serialTextBox.Location = new Point(6, 22);
            serialTextBox.Name = "serialTextBox";
            serialTextBox.Size = new Size(391, 23);
            serialTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(versionListBox);
            groupBox2.Location = new Point(12, 75);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(167, 219);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Installed version:";
            // 
            // versionListBox
            // 
            versionListBox.FormattingEnabled = true;
            versionListBox.ItemHeight = 15;
            versionListBox.Items.AddRange(new object[] { "2023", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015" });
            versionListBox.Location = new Point(6, 22);
            versionListBox.Name = "versionListBox";
            versionListBox.Size = new Size(155, 184);
            versionListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(productListBox);
            groupBox3.Location = new Point(185, 75);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(230, 219);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Xpress product:";
            // 
            // productListBox
            // 
            productListBox.FormattingEnabled = true;
            productListBox.ItemHeight = 15;
            productListBox.Items.AddRange(new object[] { "FloXpress", "SimulationXpress", "DFMXpress", "SustainabilityXpress", "DriveWorksXpress" });
            productListBox.Location = new Point(6, 22);
            productListBox.Name = "productListBox";
            productListBox.Size = new Size(218, 184);
            productListBox.TabIndex = 0;
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(12, 309);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(167, 60);
            generateBtn.TabIndex = 3;
            generateBtn.Text = "Generate";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(codeTextBox);
            groupBox4.Location = new Point(185, 309);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(230, 60);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Xpress code:";
            // 
            // codeTextBox
            // 
            codeTextBox.Location = new Point(6, 22);
            codeTextBox.Name = "codeTextBox";
            codeTextBox.Size = new Size(218, 23);
            codeTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 382);
            Controls.Add(groupBox4);
            Controls.Add(generateBtn);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "LicXpress";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox serialTextBox;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button generateBtn;
        private GroupBox groupBox4;
        private TextBox codeTextBox;
        private ListBox versionListBox;
        private ListBox productListBox;
    }
}