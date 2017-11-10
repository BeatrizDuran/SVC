namespace SVC
{
    partial class frmQuejasySugerencias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuejasySugerencias));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNOMBRE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDESCRIPCION = new System.Windows.Forms.TextBox();
            this.btnENVIAR = new System.Windows.Forms.Button();
            this.btnMENUPRINCIPAL = new System.Windows.Forms.Button();
            this.lblFECHA = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUEJAS Y SUGERENCIAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 24);
            this.panel1.TabIndex = 1;
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOMBRE.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNOMBRE.Location = new System.Drawing.Point(141, 85);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(264, 26);
            this.txtNOMBRE.TabIndex = 2;
            this.txtNOMBRE.Text = "Ingrese su nombre de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción: ";
            // 
            // txtDESCRIPCION
            // 
            this.txtDESCRIPCION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDESCRIPCION.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDESCRIPCION.Location = new System.Drawing.Point(141, 127);
            this.txtDESCRIPCION.Multiline = true;
            this.txtDESCRIPCION.Name = "txtDESCRIPCION";
            this.txtDESCRIPCION.Size = new System.Drawing.Size(543, 172);
            this.txtDESCRIPCION.TabIndex = 5;
            this.txtDESCRIPCION.Text = "Escriba aqui";
            // 
            // btnENVIAR
            // 
            this.btnENVIAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnENVIAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnENVIAR.Location = new System.Drawing.Point(141, 322);
            this.btnENVIAR.Name = "btnENVIAR";
            this.btnENVIAR.Size = new System.Drawing.Size(133, 38);
            this.btnENVIAR.TabIndex = 6;
            this.btnENVIAR.Text = "Enviar";
            this.btnENVIAR.UseVisualStyleBackColor = true;
            this.btnENVIAR.Click += new System.EventHandler(this.btnENVIAR_Click);
            // 
            // btnMENUPRINCIPAL
            // 
            this.btnMENUPRINCIPAL.BackColor = System.Drawing.Color.DarkGray;
            this.btnMENUPRINCIPAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMENUPRINCIPAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMENUPRINCIPAL.Location = new System.Drawing.Point(541, 322);
            this.btnMENUPRINCIPAL.Name = "btnMENUPRINCIPAL";
            this.btnMENUPRINCIPAL.Size = new System.Drawing.Size(143, 38);
            this.btnMENUPRINCIPAL.TabIndex = 7;
            this.btnMENUPRINCIPAL.Text = "Menu principal >";
            this.btnMENUPRINCIPAL.UseVisualStyleBackColor = false;
            this.btnMENUPRINCIPAL.Click += new System.EventHandler(this.btnMENUPRINCIPAL_Click);
            // 
            // lblFECHA
            // 
            this.lblFECHA.AutoSize = true;
            this.lblFECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFECHA.Location = new System.Drawing.Point(455, 85);
            this.lblFECHA.Name = "lblFECHA";
            this.lblFECHA.Size = new System.Drawing.Size(58, 20);
            this.lblFECHA.TabIndex = 8;
            this.lblFECHA.Text = "Fecha:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmQuejasySugerencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(749, 411);
            this.Controls.Add(this.lblFECHA);
            this.Controls.Add(this.btnMENUPRINCIPAL);
            this.Controls.Add(this.btnENVIAR);
            this.Controls.Add(this.txtDESCRIPCION);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuejasySugerencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "quejasysugerencias";
            this.Load += new System.EventHandler(this.quejasysugerencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNOMBRE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDESCRIPCION;
        private System.Windows.Forms.Button btnENVIAR;
        private System.Windows.Forms.Button btnMENUPRINCIPAL;
        private System.Windows.Forms.Label lblFECHA;
        private System.Windows.Forms.Timer timer1;
    }
}