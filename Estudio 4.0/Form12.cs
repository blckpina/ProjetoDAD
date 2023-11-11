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
    public partial class Form12 : Form
    {
        private int index;
        private string nomeModalidade;
        private string nomeTurma;
        private String[] resultado;
        private string nomeLista;
        private string modalidadeSelected;
        private string horarioSelected;
        private int idModalidadeBusca;
        private string horaSelected;
        private int idTurma;
        private String nomeAluno;
        private string CPFAluno;
        private int contador = 1;
        public Form12(int id)
        {
            InitializeComponent();

            try
            {
                Modalidade m = new Modalidade();
                MySqlDataReader r = m.consultarModalidadeAtivo();
                while (r.Read())
                {
                    cbbModalidade.Items.Add(r["descricaoModalidade"].ToString());
                }
                DAO_Conexao.con.Close();
                btnExcluir.Visible = false;
                txtQtdeAlunos.Enabled = false;
                if (id == 1)
                {
                    btnExcluir.Visible = true;
                    this.Text = "Excluir";
                    txtQtdeAlunos.Visible = false;
                    lblQtdeAlunos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Matricula matricula = new Matricula();
                if (matricula.excluirAlunoMatricula(obterCPFAluno()))
                {
                    MessageBox.Show("Excluido Com Sucesso!");
                    ltbAlunos.Items.RemoveAt(ltbAlunos.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Erro ao Excluir");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private string obterCPFAluno()
        {
            try
            {
                resultado = (ltbAlunos.SelectedItem.ToString()).Split('-');
                nomeAluno = resultado[0];
                CPFAluno = resultado[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CPFAluno;
        }

        private void cbbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ltbTurma.Items.Clear();
                ltbAlunos.Items.Clear();
                Modalidade m = new Modalidade();
                MySqlDataReader rI = m.consultarModalidade(cbbModalidade.SelectedItem.ToString());
                while (rI.Read())
                {
                    index = int.Parse(rI["idEstudio_Modalidade"].ToString());
                    nomeModalidade = (rI["descricaoModalidade"].ToString());
                }

                Turma t = new Turma();
                MySqlDataReader rII = t.consultarTurmaId(index);
                while (rII.Read())
                {
                    nomeTurma = nomeModalidade + "-" + rII["diasemanaTurma"].ToString() + "-" + rII["horaTurma"].ToString();
                    ltbTurma.Items.Add(nomeTurma);
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int obterIdTurma()
        {
            try
            {
                resultado = (ltbAlunos.SelectedItem.ToString()).Split('-');
                modalidadeSelected = resultado[0];
                horarioSelected = resultado[1];
                horaSelected = resultado[2];

                Modalidade modalidade = new Modalidade();
                MySqlDataReader rM = modalidade.consultarModalidade(modalidadeSelected);
                while (rM.Read())
                {
                    idModalidadeBusca = int.Parse(rM["idEstudio_Modalidade"].ToString());
                }
                DAO_Conexao.con.Close();

                Turma turma = new Turma();
                MySqlDataReader rDia = turma.consultarTurmaIdDiaHora(idModalidadeBusca, horarioSelected, horaSelected);
                while (rDia.Read())
                {
                    idTurma = int.Parse(rDia["idEstudio_Turma"].ToString());
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idTurma;
        }

        private void ltbTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Matricula matricula = new Matricula();
                Turma t = new Turma();
                t.setQtdeMax(index);

                Aluno a = new Aluno();

                MySqlDataReader reader = matricula.consultarInnerJoin(obterIdTurma());

                while (reader.Read())
                {
                    nomeLista = reader["nomeAluno"].ToString() + "-" + reader["CPFAluno"].ToString();
                    ltbAlunos.Items.Add(nomeLista);
                }
                DAO_Conexao.con.Close();
                txtQtdeAlunos.Text = matricula.contarAlunos(obterIdTurma()).ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
