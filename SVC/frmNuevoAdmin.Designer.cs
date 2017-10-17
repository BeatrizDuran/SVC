namespace SVC
{
    partial class frmNuevoAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCERRARSESION = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPASSWORDOTRO = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ingrese su clave:";
            // 
            // btnCERRARSESION
            // 
            this.btnCERRARSESION.BackColor = System.Drawing.Color.DarkGray;
            this.btnCERRARSESION.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCERRARSESION.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCERRARSESION.Location = new System.Drawing.Point(181, 107);
            this.btnCERRARSESION.Name = "btnCERRARSESION";
            this.btnCERRARSESION.Size = new System.Drawing.Size(139, 44);
            this.btnCERRARSESION.TabIndex = 8;
            this.btnCERRARSESION.Text = "Cerrar sesión";
            this.btnCERRARSESION.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(38, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Acceder";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtPASSWORDOTRO
            // 
            this.txtPASSWORDOTRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPASSWORDOTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPASSWORDOTRO.Location = new System.Drawing.Point(38, 64);
            this.txtPASSWORDOTRO.Name = "txtPASSWORDOTRO";
            this.txtPASSWORDOTRO.PasswordChar = '*';
            this.txtPASSWORDOTRO.Size = new System.Drawing.Size(282, 26);
            this.txtPASSWORDOTRO.TabIndex = 6;
            this.txtPASSWORDOTRO.UseSystemPasswordChar = true;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DarkGray;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(38, 167);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(279, 44);
            this.button9.TabIndex = 17;
            this.button9.Text = "Volver al inicio";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // NuevoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 252);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCERRARSESION);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPASSWORDOTRO);
            this.Name = "NuevoAdmin";
            this.Text = "NuevoAdmin";
            this.Load += new System.EventHandler(this.NuevoAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCERRARSESION;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPASSWORDOTRO;
        private System.Windows.Forms.Button button9;
    }
}