﻿namespace SVC
{
    partial class frmReportes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTOTALVOTOS = new System.Windows.Forms.Button();
            this.btnTOTALVOTANTES = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panelTOTALVOTANTES = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelTOTALVOTANTES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-5, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 32);
            this.panel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SVC.Properties.Resources.thin_1570_exit_login_import_16;
            this.button1.Location = new System.Drawing.Point(571, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reportes";
            // 
            // btnTOTALVOTOS
            // 
            this.btnTOTALVOTOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTOTALVOTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTOTALVOTOS.Location = new System.Drawing.Point(12, 86);
            this.btnTOTALVOTOS.Name = "btnTOTALVOTOS";
            this.btnTOTALVOTOS.Size = new System.Drawing.Size(246, 39);
            this.btnTOTALVOTOS.TabIndex = 38;
            this.btnTOTALVOTOS.Text = "Generar el total de votos";
            this.btnTOTALVOTOS.UseVisualStyleBackColor = true;
            this.btnTOTALVOTOS.Click += new System.EventHandler(this.btnTOTALVOTOS_Click);
            // 
            // btnTOTALVOTANTES
            // 
            this.btnTOTALVOTANTES.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTOTALVOTANTES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTOTALVOTANTES.Location = new System.Drawing.Point(12, 131);
            this.btnTOTALVOTANTES.Name = "btnTOTALVOTANTES";
            this.btnTOTALVOTANTES.Size = new System.Drawing.Size(246, 37);
            this.btnTOTALVOTANTES.TabIndex = 39;
            this.btnTOTALVOTANTES.Text = "Generar total de votantes";
            this.btnTOTALVOTANTES.UseVisualStyleBackColor = true;
            this.btnTOTALVOTANTES.Click += new System.EventHandler(this.btnTOTALVOTANTES_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(246, 283);
            this.webBrowser1.TabIndex = 0;
            // 
            // panelTOTALVOTANTES
            // 
            this.panelTOTALVOTANTES.Controls.Add(this.webBrowser1);
            this.panelTOTALVOTANTES.Location = new System.Drawing.Point(12, 174);
            this.panelTOTALVOTANTES.Name = "panelTOTALVOTANTES";
            this.panelTOTALVOTANTES.Size = new System.Drawing.Size(246, 286);
            this.panelTOTALVOTANTES.TabIndex = 40;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(310, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 26);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(511, 131);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 26);
            this.textBox2.TabIndex = 42;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(310, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(492, 286);
            this.dataGridView1.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(506, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 45;
            this.label3.Text = "Reportes";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(869, 490);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panelTOTALVOTANTES);
            this.Controls.Add(this.btnTOTALVOTANTES);
            this.Controls.Add(this.btnTOTALVOTOS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.panel1.ResumeLayout(false);
            this.panelTOTALVOTANTES.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTOTALVOTOS;
        private System.Windows.Forms.Button btnTOTALVOTANTES;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panelTOTALVOTANTES;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}