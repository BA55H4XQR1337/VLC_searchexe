namespace searchexe
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btninstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkstatus
            // 
            this.checkstatus.AutoSize = true;
            this.checkstatus.Location = new System.Drawing.Point(10, 62);
            this.checkstatus.Name = "checkstatus";
            this.checkstatus.Size = new System.Drawing.Size(37, 13);
            this.checkstatus.TabIndex = 0;
            this.checkstatus.Text = "check";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "ᴮʸ ᴮᴬ⁵⁵ᴴ⁴ˣᵠᴿ ( ° ͜ʖ͡°)╭∩╮ ";
            // 
            // btninstall
            // 
            this.btninstall.Location = new System.Drawing.Point(13, 19);
            this.btninstall.Name = "btninstall";
            this.btninstall.Size = new System.Drawing.Size(155, 23);
            this.btninstall.TabIndex = 3;
            this.btninstall.Text = "install vlc player";
            this.btninstall.UseVisualStyleBackColor = true;
            this.btninstall.Click += new System.EventHandler(this.btninstall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 110);
            this.Controls.Add(this.btninstall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkstatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 149);
            this.MinimumSize = new System.Drawing.Size(260, 149);
            this.Name = "Form1";
            this.Text = "VLCSearch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label checkstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btninstall;
    }
}

