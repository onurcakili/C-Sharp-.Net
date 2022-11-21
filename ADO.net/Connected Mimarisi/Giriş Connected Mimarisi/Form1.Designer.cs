
namespace Giriş_Connected_Mimarisi
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
            this.listUrunler = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listUrunler
            // 
            this.listUrunler.FormattingEnabled = true;
            this.listUrunler.ItemHeight = 16;
            this.listUrunler.Location = new System.Drawing.Point(98, 80);
            this.listUrunler.Name = "listUrunler";
            this.listUrunler.Size = new System.Drawing.Size(414, 308);
            this.listUrunler.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kategori Formunu Aç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listUrunler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listUrunler;
        private System.Windows.Forms.Button button1;
    }
}

