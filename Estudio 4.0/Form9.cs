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
    public partial class Form9 : Form
    {
        bool a;
        public Form9()
        {
            try{
                InitializeComponent();
                WindowState = FormWindowState.Maximized;
                Modalidade m = new Modalidade();
                MySqlDataReader reader = m.consultarModalidadeAtivo();

                while (reader.Read()){
                    int x = int.Parse(reader["ativa"].ToString());
                    if (x == 0){
                        dataGridView1.Rows.Add(reader["descricaoModalidade"].ToString());
                    }
                }
                txtModalidade.Enabled = false;
            }
            catch (Exception ex){
                MessageBox.Show("Erro ao preencher");
            }
            finally{
                DAO_Conexao.con.Close();
            }
        }

        private void btnCadastrarTurma_Click(object sender, EventArgs e)
        {
            string dia = txtDiaSemana.Text;
            string horaT = mtxtHora.Text;
            string prof = txtProfessor.Text;
            string modalidade = txtModalidade.Text;
            int mod = -1;
            int qtdeAlunos = int.Parse(txtQtdeAlunos.Text);

            try{
                Modalidade modal = new Modalidade();
                MySqlDataReader reader = modal.consultarModalidade(modalidade);
                while (reader.Read()){
                    mod = int.Parse(reader["idEstudio_Modalidade"].ToString());
                }
                MessageBox.Show(mod.ToString());

                DAO_Conexao.con.Close();
                MessageBox.Show(mod.ToString());
                Turma turma = new Turma(prof, dia, horaT, mod, qtdeAlunos);

                if (turma.cadastrar()){
                    MessageBox.Show("Turma cadastrada com êxito");
                }
                else{
                    MessageBox.Show("Erro ao cadatrar");
                }
                txtDiaSemana.Text = "";
                mtxtHora.Text = "";
                txtProfessor.Text = "";
                txtModalidade.Text = "";
                txtQtdeAlunos.Text = "";
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModalidade.Text = dataGridView1.CurrentCell.Value.ToString();
        }
    }
}
