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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Modalidade mod1 = new Modalidade();
            Turma turma1 = new Turma();

            MySqlDataReader reader = mod1.consultarTodasModalidades();
            while (reader.Read())
                cbbModalidade.Items.Add(reader["idModalidade"].ToString());
            DAO_Conexao.con.Close();

            MySqlDataReader read = turma1.consultarTodasTurmas();
            while (read.Read())
            {
                cbbDiaSemana.Items.Add(read["diasemanaTurma"].ToString());
                cbbHora.Items.Add(read["horaTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnExcluirTurma_Click(object sender, EventArgs e)
        {
            String modal = (cbbModalidade.SelectedItem.ToString());
            String dia = cbbDiaSemana.SelectedItem.ToString();
            String hora = cbbHora.SelectedItem.ToString();

            Turma turma = new Turma(dia, hora);
            Modalidade modalidade = new Modalidade(modal);

            if (turma.excluir())
                MessageBox.Show("Exclusão feita com êxito");
            else
                MessageBox.Show("Erro ao excluir");
        }
    }
}
