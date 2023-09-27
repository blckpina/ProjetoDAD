using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form5 : Form
    {
        DialogResult resultado = DialogResult.No;
        public Form5()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text, txtNome.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, txtComplemento.Text, txtCEP.Text, txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text);
            if (aluno.consultarAluno())
            {
                if (aluno.atualizarAluno())
                {
                    MessageBox.Show("Aluno atualizado com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha na atualização!");
                }
            }
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text);
            if (e.KeyChar == 13)
            {
                Console.WriteLine("Entrou");
                if (aluno.consultarAluno())
                {
                    DialogResult result = MessageBox.Show("Este aluno já está cadastrado, gostaria de atualizar os dados?", "Aluno já existente",
                        MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Console.WriteLine("Entrou2");
                        MySqlDataReader r = aluno.consultarAluno2();
                        r.Read();
                        txtNome.Text = r["nomeAluno"].ToString();
                        txtEndereco.Text = r["ruaAluno"].ToString();
                        txtNumero.Text = r["numeroAluno"].ToString();
                        txtBairro.Text = r["bairroAluno"].ToString();
                        txtComplemento.Text = r["complementoAluno"].ToString();
                        txtCEP.Text = r["CEPAluno"].ToString();
                        txtCidade.Text = r["cidadeAluno"].ToString();
                        txtEstado.Text = r["estadoAluno"].ToString();
                        txtTelefone.Text = r["telefoneAluno"].ToString();
                        txtEmail.Text = r["emailAluno"].ToString();
                        txtCPF.Enabled = false;
                        resultado = result;
                    }
                }
                else
                {
                    txtNome.Focus();
                }
                DAO_Conexao.con.Close();
            }
        }
    }
}
