namespace GeoFigurGUI6 {
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.canvas = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Controls.Add(this.canvas);
            this.groupBoxCanvas.Location = new System.Drawing.Point(11, 0);
            this.groupBoxCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCanvas.Size = new System.Drawing.Size(1064, 495);
            this.groupBoxCanvas.TabIndex = 0;
            this.groupBoxCanvas.TabStop = false;
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(4, 20);
            this.canvas.Margin = new System.Windows.Forms.Padding(4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1047, 468);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 544);
            this.Controls.Add(this.groupBoxCanvas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleBuffered = true;
            this.groupBoxCanvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCanvas;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Timer timer1;
    }
}

