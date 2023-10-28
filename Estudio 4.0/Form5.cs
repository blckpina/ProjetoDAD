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
        private bool atualiza;
        String cpfSelected;
        public Form5(bool atualiza)
        {
            InitializeComponent();

            Aluno aluno1 = new Aluno();
            MySqlDataReader result = aluno1.consultarAluno2();
            while (result.Read())
            {
                cbbCPF.Items.Add(result["CPFAluno"].ToString());
            }
            DAO_Conexao.con.Close();
            this.atualiza = atualiza;

            if (!atualiza)
            {

                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtNumero.Enabled = false;
                txtBairro.Enabled = false;
                txtComplemento.Enabled = false;
                txtCEP.Enabled = false;
                txtCidade.Enabled = false;
                txtEstado.Enabled = false;
                txtTelefone.Enabled = false;
                txtEmail.Enabled = false;
                btnAtualizar.Visible = false;
                checkBox1.Enabled = false;

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (atualiza)
                {
                    string cpf = cbbCPF.Text;
                    string nome = txtNome.Text;
                    string rua = txtEndereco.Text;
                    string numero = txtNumero.Text;
                    string bairro = txtBairro.Text;
                    string complemento = txtComplemento.Text;
                    string cep = txtCEP.Text;
                    string cidade = txtCidade.Text;
                    string estado = txtEstado.Text;
                    string telefone = txtTelefone.Text;
                    string email = txtEmail.Text;
                    int ativo;

                    if (checkBox1.Checked)
                    {
                        ativo = 1;
                    }
                    else
                    {
                        ativo = 0;
                    }

                    Aluno aluno = new Aluno(cpf, nome, rua, numero, bairro, complemento, cep, cidade, estado, telefone, email, ativo);

                    if (aluno.atualizarAluno())
                    {
                        MessageBox.Show("Atualização feita com êxito");

                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar");
                    }
                }
                else
                {
                    try
                    {
                        Aluno aluno2 = new Aluno();
                        cpfSelected = cbbCPF.SelectedItem.ToString();
                        MySqlDataReader reader = aluno2.consultarAluno3(cpfSelected);
                        {
                        while (reader.Read())
                            cpfSelected = reader["CPFAluno"].ToString();
                            txtNome.Text = reader["nomeAluno"].ToString();
                            txtEndereco.Text = reader["ruaAluno"].ToString();
                            txtNumero.Text = reader["numeroAluno"].ToString();
                            txtBairro.Text = reader["bairroAluno"].ToString();
                            txtComplemento.Text = reader["complementoAluno"].ToString();
                            txtCEP.Text = reader["cepAluno"].ToString();
                            txtCidade.Text = reader["cidadeAluno"].ToString();
                            txtEstado.Text = reader["estadoAluno"].ToString();
                            txtTelefone.Text = reader["telefoneAluno"].ToString();
                            txtEmail.Text = reader["emailAluno"].ToString();
                        }

                        DAO_Conexao.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não deve ter campos vazios");
            }
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cbbCPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno2 = new Aluno();
                cpfSelected = cbbCPF.SelectedItem.ToString();
                MySqlDataReader reader = aluno2.consultarAluno3(cpfSelected);
                while (reader.Read())
                {
                    cpfSelected = reader["CPFAluno"].ToString();
                    txtNome.Text = reader["nomeAluno"].ToString();
                    txtEndereco.Text = reader["ruaAluno"].ToString();
                    txtNumero.Text = reader["numeroAluno"].ToString();
                    txtBairro.Text = reader["bairroAluno"].ToString();
                    txtComplemento.Text = reader["complementoAluno"].ToString();
                    txtCEP.Text = reader["CEPAluno"].ToString();
                    txtCidade.Text = reader["cidadeAluno"].ToString();
                    txtEstado.Text = reader["estadoAluno"].ToString();
                    txtTelefone.Text = reader["telefoneAluno"].ToString();
                    txtEmail.Text = reader["emailAluno"].ToString();

                    if (reader["ativo"].ToString().Equals("1"))
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    if(!atualiza)
                    {
                        cbbCPF.Enabled = true;
                    }
                    else
                    {
                        cbbCPF.Enabled = false;
                    }
                }

                DAO_Conexao.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
