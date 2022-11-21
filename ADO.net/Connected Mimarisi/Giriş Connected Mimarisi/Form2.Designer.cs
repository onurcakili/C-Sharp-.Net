
namespace Giriş_Connected_Mimarisi
{
    partial class Form2
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
            this.listKategoriler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listKategoriler
            // 
            this.listKategoriler.FormattingEnabled = true;
            this.listKategoriler.ItemHeight = 16;
            this.listKategoriler.Location = new System.Drawing.Point(179, 130);
            this.listKategoriler.Name = "listKategoriler";
            this.listKategoriler.Size = new System.Drawing.Size(385, 308);
            this.listKategoriler.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listKategoriler);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listKategoriler;
    }
}