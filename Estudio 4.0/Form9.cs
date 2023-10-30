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
        String modalidadeSelected;
        public Form9()
        {
            InitializeComponent();
            try
            {
                Modalidade mod1 = new Modalidade();
                MySqlDataReader result = mod1.consultarModalidadeAtivo();
                while (result.Read())
                {
                    cbbModalidade.Items.Add(result["descricaoModalidade"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();   
            }       
        }

        private void btnCadastrarTurma_Click(object sender, EventArgs e)
        {          
            try
            {
                string professor = txtProfessor.Text;
                string diaSemana = txtDiaSemana.Text;
                string hora = mtxtHora.Text;
                int mod = -1;

                Modalidade modal = new Modalidade();
                modalidadeSelected = cbbModalidade.SelectedItem.ToString();
                MySqlDataReader reader = modal.consultarModalidade(modalidadeSelected);
                while (reader.Read()){
                    mod = int.Parse(reader["idEstudio_Modalidade"].ToString());
                }
               
                Turma turma = new Turma(mod, professor, diaSemana, hora);

                if (turma.cadastrar())
                {
                    MessageBox.Show("Turma cadastrada com êxito");
                }
                else
                {
                    MessageBox.Show("Erro ao cadatrar");
                }
                txtDiaSemana.Text = "";
                mtxtHora.Text = "";
                txtProfessor.Text = "";
                cbbModalidade.Text = "";
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                
            }
        }

    }
}
