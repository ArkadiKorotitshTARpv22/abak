namespace abak
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KategooriaBox = new System.Windows.Forms.ComboBox();
            this.lisakatbtn = new System.Windows.Forms.Button();
            this.HindBox = new System.Windows.Forms.TextBox();
            this.KogusBox = new System.Windows.Forms.TextBox();
            this.ToodeBox = new System.Windows.Forms.TextBox();
            this.LisaTabelBtn = new System.Windows.Forms.Button();
            this.UuendaTabelBtn = new System.Windows.Forms.Button();
            this.KustutaTabelBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // KategooriaBox
            // 
            this.KategooriaBox.FormattingEnabled = true;
            this.KategooriaBox.Location = new System.Drawing.Point(86, 254);
            this.KategooriaBox.Name = "KategooriaBox";
            this.KategooriaBox.Size = new System.Drawing.Size(242, 21);
            this.KategooriaBox.TabIndex = 1;
            // 
            // lisakatbtn
            // 
            this.lisakatbtn.Location = new System.Drawing.Point(334, 201);
            this.lisakatbtn.Name = "lisakatbtn";
            this.lisakatbtn.Size = new System.Drawing.Size(75, 74);
            this.lisakatbtn.TabIndex = 2;
            this.lisakatbtn.Text = "Lisa Kategooria";
            this.lisakatbtn.UseVisualStyleBackColor = true;
            // 
            // HindBox
            // 
            this.HindBox.Location = new System.Drawing.Point(86, 181);
            this.HindBox.Name = "HindBox";
            this.HindBox.Size = new System.Drawing.Size(242, 20);
            this.HindBox.TabIndex = 3;
            // 
            // KogusBox
            // 
            this.KogusBox.Location = new System.Drawing.Point(86, 155);
            this.KogusBox.Name = "KogusBox";
            this.KogusBox.Size = new System.Drawing.Size(242, 20);
            this.KogusBox.TabIndex = 4;
            // 
            // ToodeBox
            // 
            this.ToodeBox.Location = new System.Drawing.Point(86, 129);
            this.ToodeBox.Name = "ToodeBox";
            this.ToodeBox.Size = new System.Drawing.Size(242, 20);
            this.ToodeBox.TabIndex = 5;
            // 
            // LisaTabelBtn
            // 
            this.LisaTabelBtn.Location = new System.Drawing.Point(86, 208);
            this.LisaTabelBtn.Name = "LisaTabelBtn";
            this.LisaTabelBtn.Size = new System.Drawing.Size(75, 40);
            this.LisaTabelBtn.TabIndex = 6;
            this.LisaTabelBtn.Text = "Lisa";
            this.LisaTabelBtn.UseVisualStyleBackColor = true;
            // 
            // UuendaTabelBtn
            // 
            this.UuendaTabelBtn.Location = new System.Drawing.Point(168, 208);
            this.UuendaTabelBtn.Name = "UuendaTabelBtn";
            this.UuendaTabelBtn.Size = new System.Drawing.Size(75, 40);
            this.UuendaTabelBtn.TabIndex = 7;
            this.UuendaTabelBtn.Text = "Uuenda";
            this.UuendaTabelBtn.UseVisualStyleBackColor = true;
            // 
            // KustutaTabelBtn
            // 
            this.KustutaTabelBtn.Location = new System.Drawing.Point(250, 208);
            this.KustutaTabelBtn.Name = "KustutaTabelBtn";
            this.KustutaTabelBtn.Size = new System.Drawing.Size(78, 40);
            this.KustutaTabelBtn.TabIndex = 8;
            this.KustutaTabelBtn.Text = "Kustuta";
            this.KustutaTabelBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 20);
            this.textBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.KustutaTabelBtn);
            this.Controls.Add(this.UuendaTabelBtn);
            this.Controls.Add(this.LisaTabelBtn);
            this.Controls.Add(this.ToodeBox);
            this.Controls.Add(this.KogusBox);
            this.Controls.Add(this.HindBox);
            this.Controls.Add(this.lisakatbtn);
            this.Controls.Add(this.KategooriaBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox KategooriaBox;
        private System.Windows.Forms.Button lisakatbtn;
        private System.Windows.Forms.TextBox HindBox;
        private System.Windows.Forms.TextBox KogusBox;
        private System.Windows.Forms.TextBox ToodeBox;
        private System.Windows.Forms.Button LisaTabelBtn;
        private System.Windows.Forms.Button UuendaTabelBtn;
        private System.Windows.Forms.Button KustutaTabelBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}

