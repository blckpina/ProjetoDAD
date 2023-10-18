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
        public Form9()
        {
            try
            {
                Modalidade mod1 = new Modalidade();
                MySqlDataReader result = mod1.consultarTodasModalidades();
                while (result.Read())
                {
                    cbbModalidade.Items.Add(result["idModalidade"].ToString());
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
            int mod = 0;

            try{
                Modalidade modal = new Modalidade();
                MySqlDataReader reader = modal.consultarModalidade(cbbModalidade.Text);
                while (reader.Read()){
                    mod = int.Parse(reader["idEstudio_Modalidade"].ToString());
                }
                MessageBox.Show(mod.ToString());

                DAO_Conexao.con.Close();
                MessageBox.Show(mod.ToString());
                Turma turma = new Turma(txtProfessor.Text, txtDiaSemana.Text, mtxtHora.Text, cbbModalidade.Text);

                if (turma.cadastrar()){
                    MessageBox.Show("Turma cadastrada com êxito");
                }
                else{
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
                DAO_Conexao.con.Close();
            }
        }

    }
}
