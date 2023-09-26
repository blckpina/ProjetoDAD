
namespace Estudio
{
    partial class Form7
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
            this.lblExcluirDesc = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnExlcuir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblExcluirDesc
            // 
            this.lblExcluirDesc.AutoSize = true;
            this.lblExcluirDesc.Location = new System.Drawing.Point(37, 37);
            this.lblExcluirDesc.Name = "lblExcluirDesc";
            this.lblExcluirDesc.Size = new System.Drawing.Size(55, 13);
            this.lblExcluirDesc.TabIndex = 0;
            this.lblExcluirDesc.Text = "Descrição";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(301, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnExlcuir
            // 
            this.btnExlcuir.Location = new System.Drawing.Point(40, 74);
            this.btnExlcuir.Name = "btnExlcuir";
            this.btnExlcuir.Size = new System.Drawing.Size(359, 23);
            this.btnExlcuir.TabIndex = 2;
            this.btnExlcuir.Text = "Excluir";
            this.btnExlcuir.UseVisualStyleBackColor = true;
            this.btnExlcuir.Click += new System.EventHandler(this.btnExlcuir_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 109);
            this.Controls.Add(this.btnExlcuir);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblExcluirDesc);
            this.Name = "Form7";
            this.Text = "Excluir Modalidade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExcluirDesc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnExlcuir;
    }
}