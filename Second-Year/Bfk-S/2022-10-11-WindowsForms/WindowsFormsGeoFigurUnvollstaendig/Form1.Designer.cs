namespace WindowsFormsGeoFigur {
    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxCanvas.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Controls.Add(this.panelCanvas);
            this.groupBoxCanvas.Location = new System.Drawing.Point(26, 12);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Size = new System.Drawing.Size(762, 343);
            this.groupBoxCanvas.TabIndex = 0;
            this.groupBoxCanvas.TabStop = false;
            this.groupBoxCanvas.Text = "Canvas";
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Controls.Add(this.buttonStart);
            this.groupBoxAction.Location = new System.Drawing.Point(26, 361);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(762, 82);
            this.groupBoxAction.TabIndex = 1;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Action";
            // 
            // panelCanvas
            // 
            this.panelCanvas.Location = new System.Drawing.Point(7, 21);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(749, 316);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(45, 21);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(125, 56);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.groupBoxCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxCanvas.ResumeLayout(false);
            this.groupBoxAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCanvas;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Button buttonStart;
    }
}

