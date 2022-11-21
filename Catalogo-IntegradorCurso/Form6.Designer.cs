
namespace Catalogo_IntegradorCurso
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.lblDescripCM = new System.Windows.Forms.Label();
            this.txtDescripCM = new System.Windows.Forms.TextBox();
            this.btnAceptarCM = new System.Windows.Forms.Button();
            this.btnCancelarCM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescripCM
            // 
            this.lblDescripCM.AutoSize = true;
            this.lblDescripCM.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripCM.ForeColor = System.Drawing.Color.White;
            this.lblDescripCM.Location = new System.Drawing.Point(62, 77);
            this.lblDescripCM.Name = "lblDescripCM";
            this.lblDescripCM.Size = new System.Drawing.Size(100, 19);
            this.lblDescripCM.TabIndex = 0;
            this.lblDescripCM.Text = "Descripción:";
            // 
            // txtDescripCM
            // 
            this.txtDescripCM.Location = new System.Drawing.Point(168, 71);
            this.txtDescripCM.Name = "txtDescripCM";
            this.txtDescripCM.Size = new System.Drawing.Size(192, 25);
            this.txtDescripCM.TabIndex = 1;
            // 
            // btnAceptarCM
            // 
            this.btnAceptarCM.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAceptarCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarCM.FlatAppearance.BorderSize = 0;
            this.btnAceptarCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarCM.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarCM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptarCM.Location = new System.Drawing.Point(66, 189);
            this.btnAceptarCM.Name = "btnAceptarCM";
            this.btnAceptarCM.Size = new System.Drawing.Size(99, 34);
            this.btnAceptarCM.TabIndex = 9;
            this.btnAceptarCM.Text = "&Aceptar";
            this.btnAceptarCM.UseVisualStyleBackColor = false;
            this.btnAceptarCM.Click += new System.EventHandler(this.btnAceptarCM_Click);
            // 
            // btnCancelarCM
            // 
            this.btnCancelarCM.BackColor = System.Drawing.Color.Brown;
            this.btnCancelarCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCM.FlatAppearance.BorderSize = 0;
            this.btnCancelarCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCM.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelarCM.Location = new System.Drawing.Point(261, 189);
            this.btnCancelarCM.Name = "btnCancelarCM";
            this.btnCancelarCM.Size = new System.Drawing.Size(99, 34);
            this.btnCancelarCM.TabIndex = 10;
            this.btnCancelarCM.Text = "&Cancelar";
            this.btnCancelarCM.UseVisualStyleBackColor = false;
            this.btnCancelarCM.Click += new System.EventHandler(this.btnCancelarCM_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(430, 292);
            this.Controls.Add(this.btnCancelarCM);
            this.Controls.Add(this.btnAceptarCM);
            this.Controls.Add(this.txtDescripCM);
            this.Controls.Add(this.lblDescripCM);
            this.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar ";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescripCM;
        private System.Windows.Forms.TextBox txtDescripCM;
        private System.Windows.Forms.Button btnAceptarCM;
        private System.Windows.Forms.Button btnCancelarCM;
    }
}