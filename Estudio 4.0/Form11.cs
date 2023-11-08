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
    public partial class Form11 : Form
    {
        private int index;
        private string nomeModalidade;
        private string nomeTurma;
        private String[] resultado;
        private string modalidadeSelected;
        private string horarioSelected;
        private int idModalidadeBusca;
        private string horaSelected;
        private int idTurma;
        public Form11()
        {
            InitializeComponent();
            try
            {
                Modalidade m = new Modalidade();
                MySqlDataReader r = m.consultarModalidadeAtivo();
                while (r.Read())
                {
                    cbbMod.Items.Add(r["descricaoModalidade"].ToString());
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cpf = mtxtCPF.Text;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            Aluno al = new Aluno(cpf);
            if (al.consultarAluno() == true)
            {
                int id = obterIdTurma();
                Matricula m = new Matricula();
                Turma t = new Turma();
                t.setQtdeMax(index);
                if (m.contarAlunos(obterIdTurma()) < t.QtdeMax)
                {
                    Aluno a = new Aluno(cpf);

                    if (a.verificaCPF())
                    {
                        cpf = a.getCPF();

                        if (m.cadastrar(id, cpf))
                        {
                            MessageBox.Show("Cadastro realizado");
                        }
                        else
                        {
                            MessageBox.Show("Erro no cadastro");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível mais cadastrar alunos nesta turma");
                }
            }
            else
            {
                MessageBox.Show("Este CPF não existe no banco de dados");
            }
        }

        private int obterIdTurma()
        {
            try
            {
                resultado = ltbTurma.SelectedItem.ToString().Split('-');
                modalidadeSelected = resultado[0];
                horarioSelected = resultado[1];
                horaSelected = resultado[2];

                Modalidade modalidade = new Modalidade();
                MySqlDataReader rMod = modalidade.consultarModalidade(modalidadeSelected);
                while (rMod.Read())
                {
                    idModalidadeBusca = int.Parse(rMod["idEstudio_Modalidade"].ToString());
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

        private void cbbMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ltbTurma.Items.Clear();
                Modalidade m = new Modalidade();
                MySqlDataReader rIdx = m.consultarModalidade(cbbMod.SelectedItem.ToString());
                while (rIdx.Read())
                {
                    index = int.Parse(rIdx["idEstudio_Modalidade"].ToString());
                    nomeModalidade = (rIdx["descricaoModalidade"].ToString());
                }
                DAO_Conexao.con.Close();

                Turma t = new Turma();
                MySqlDataReader rLbx = t.consultarTurmaId(index);
                while (rLbx.Read())
                {
                    nomeTurma = nomeModalidade + "-" + rLbx["diaSemanaTurma"].ToString() + "-" + rLbx["horaTurma"].ToString();
                    ltbTurma.Items.Add(nomeTurma);
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
