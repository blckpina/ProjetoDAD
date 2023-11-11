
namespace Estudio
{
    partial class Form12
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ltbTurma = new System.Windows.Forms.ListBox();
            this.lblTurmas = new System.Windows.Forms.Label();
            this.cbbModalidade = new System.Windows.Forms.ComboBox();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ltbAlunos = new System.Windows.Forms.ListBox();
            this.lblAlunos = new System.Windows.Forms.Label();
            this.txtQtdeAlunos = new System.Windows.Forms.TextBox();
            this.lblQtdeAlunos = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ltbTurma);
            this.groupBox1.Controls.Add(this.lblTurmas);
            this.groupBox1.Controls.Add(this.cbbModalidade);
            this.groupBox1.Controls.Add(this.lblModalidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turma";
            // 
            // ltbTurma
            // 
            this.ltbTurma.FormattingEnabled = true;
            this.ltbTurma.Location = new System.Drawing.Point(33, 123);
            this.ltbTurma.Name = "ltbTurma";
            this.ltbTurma.Size = new System.Drawing.Size(232, 173);
            this.ltbTurma.TabIndex = 3;
            this.ltbTurma.SelectedIndexChanged += new System.EventHandler(this.ltbTurma_SelectedIndexChanged);
            // 
            // lblTurmas
            // 
            this.lblTurmas.AutoSize = true;
            this.lblTurmas.Location = new System.Drawing.Point(30, 107);
            this.lblTurmas.Name = "lblTurmas";
            this.lblTurmas.Size = new System.Drawing.Size(42, 13);
            this.lblTurmas.TabIndex = 2;
            this.lblTurmas.Text = "Turmas";
            // 
            // cbbModalidade
            // 
            this.cbbModalidade.FormattingEnabled = true;
            this.cbbModalidade.Location = new System.Drawing.Point(33, 59);
            this.cbbModalidade.Name = "cbbModalidade";
            this.cbbModalidade.Size = new System.Drawing.Size(232, 21);
            this.cbbModalidade.TabIndex = 1;
            this.cbbModalidade.SelectedIndexChanged += new System.EventHandler(this.cbbModalidade_SelectedIndexChanged);
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(30, 42);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(67, 13);
            this.lblModalidade.TabIndex = 0;
            this.lblModalidade.Text = "Modalidades";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ltbAlunos);
            this.groupBox2.Controls.Add(this.lblAlunos);
            this.groupBox2.Controls.Add(this.txtQtdeAlunos);
            this.groupBox2.Controls.Add(this.lblQtdeAlunos);
            this.groupBox2.Location = new System.Drawing.Point(318, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 322);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alunos";
            // 
            // ltbAlunos
            // 
            this.ltbAlunos.FormattingEnabled = true;
            this.ltbAlunos.Location = new System.Drawing.Point(27, 124);
            this.ltbAlunos.Name = "ltbAlunos";
            this.ltbAlunos.Size = new System.Drawing.Size(234, 173);
            this.ltbAlunos.TabIndex = 3;
            // 
            // lblAlunos
            // 
            this.lblAlunos.AutoSize = true;
            this.lblAlunos.Location = new System.Drawing.Point(27, 107);
            this.lblAlunos.Name = "lblAlunos";
            this.lblAlunos.Size = new System.Drawing.Size(39, 13);
            this.lblAlunos.TabIndex = 2;
            this.lblAlunos.Text = "Alunos";
            // 
            // txtQtdeAlunos
            // 
            this.txtQtdeAlunos.Location = new System.Drawing.Point(27, 60);
            this.txtQtdeAlunos.Name = "txtQtdeAlunos";
            this.txtQtdeAlunos.Size = new System.Drawing.Size(234, 20);
            this.txtQtdeAlunos.TabIndex = 1;
            // 
            // lblQtdeAlunos
            // 
            this.lblQtdeAlunos.AutoSize = true;
            this.lblQtdeAlunos.Location = new System.Drawing.Point(24, 42);
            this.lblQtdeAlunos.Name = "lblQtdeAlunos";
            this.lblQtdeAlunos.Size = new System.Drawing.Size(112, 13);
            this.lblQtdeAlunos.TabIndex = 0;
            this.lblQtdeAlunos.Text = "Quantidade de Alunos";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(12, 341);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(599, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 381);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form12";
            this.Text = "Consultar Matricula";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTurmas;
        private System.Windows.Forms.ComboBox cbbModalidade;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.ListBox ltbTurma;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ltbAlunos;
        private System.Windows.Forms.Label lblAlunos;
        private System.Windows.Forms.TextBox txtQtdeAlunos;
        private System.Windows.Forms.Label lblQtdeAlunos;
        private System.Windows.Forms.Button btnExcluir;
    }
}