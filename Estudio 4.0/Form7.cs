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
        }

        private void btnExlcuir_Click(object sender, EventArgs e)
        {
            try
            {
                Modalidade modalidade = new Modalidade(comboBox1.SelectedItem.ToString());
                if (modalidade.excluirModalidade())
                {
                    this.atualizarDescricao();
                    MessageBox.Show("Modalidade foi excluída");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
