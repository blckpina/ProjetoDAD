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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Modalidade mod1 = new Modalidade();
            MySqlDataReader read = mod1.consultarTodasModalidades();
            while (read.Read())
            {

                comboBox1.Items.Add(read["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnExlcuir_Click(object sender, EventArgs e)
        {
            try
            {
                Modalidade modal = new Modalidade();
                modal.Descricao1 = comboBox1.Text;

                if (modal.consultarModalidade2()){
                    if (modal.excluirModalidade()){
                        MessageBox.Show("Modalidade foi excluída");
                    }
                }
                else{
                    MessageBox.Show("Modalidade não existe");
                }
                modal.excluirModalidade();
            }
            catch (Exception ex){
                MessageBox.Show("Erro ao excluir");
            }
        }

        private void atualizarDescricao()
        {
            Modalidade mod = new Modalidade();
            try
            {
                MySqlDataReader read = mod.consultarTodasModalidades();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        comboBox1.Items.Add(read["descricaoModalidade"].ToString());
                    }
                }
                read.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            DAO_Conexao.con.Close();
        }
    }
}
