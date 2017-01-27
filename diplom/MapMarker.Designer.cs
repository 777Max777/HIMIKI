namespace diplom
{
    partial class MapMarker
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
            this.WebBro = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebBro
            // 
            this.WebBro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBro.Location = new System.Drawing.Point(0, 0);
            this.WebBro.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBro.Name = "WebBro";
            this.WebBro.Size = new System.Drawing.Size(993, 539);
            this.WebBro.TabIndex = 0;
            // 
            // MapMarker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 539);
            this.Controls.Add(this.WebBro);
            this.Name = "MapMarker";
            this.Text = "Обзор карты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapMarker_FormClosing);
            this.Load += new System.EventHandler(this.MapMarker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBro;
    }
}