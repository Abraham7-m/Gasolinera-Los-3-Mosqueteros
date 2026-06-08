namespace GasolineraLos3Mosqueteros
{
    partial class Configuracion
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
            this.button1 = new System.Windows.Forms.Button();
            this.textRegular = new System.Windows.Forms.TextBox();
            this.textSuper = new System.Windows.Forms.TextBox();
            this.textPremiun = new System.Windows.Forms.TextBox();
            this.textDiesel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::GasolineraLos3Mosqueteros.Properties.Resources.guardas;
            this.button1.Location = new System.Drawing.Point(327, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 45);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textRegular
            // 
            this.textRegular.Location = new System.Drawing.Point(80, 242);
            this.textRegular.Name = "textRegular";
            this.textRegular.Size = new System.Drawing.Size(117, 22);
            this.textRegular.TabIndex = 1;
            // 
            // textSuper
            // 
            this.textSuper.Location = new System.Drawing.Point(245, 242);
            this.textSuper.Name = "textSuper";
            this.textSuper.Size = new System.Drawing.Size(119, 22);
            this.textSuper.TabIndex = 2;
            // 
            // textPremiun
            // 
            this.textPremiun.Location = new System.Drawing.Point(416, 242);
            this.textPremiun.Name = "textPremiun";
            this.textPremiun.Size = new System.Drawing.Size(120, 22);
            this.textPremiun.TabIndex = 3;
            this.textPremiun.TextChanged += new System.EventHandler(this.textPremiun_TextChanged);
            // 
            // textDiesel
            // 
            this.textDiesel.Location = new System.Drawing.Point(587, 242);
            this.textDiesel.Name = "textDiesel";
            this.textDiesel.Size = new System.Drawing.Size(115, 22);
            this.textDiesel.TabIndex = 4;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GasolineraLos3Mosqueteros.Properties.Resources.confi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.textDiesel);
            this.Controls.Add(this.textPremiun);
            this.Controls.Add(this.textSuper);
            this.Controls.Add(this.textRegular);
            this.Controls.Add(this.button1);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textRegular;
        private System.Windows.Forms.TextBox textSuper;
        private System.Windows.Forms.TextBox textPremiun;
        private System.Windows.Forms.TextBox textDiesel;
    }
}