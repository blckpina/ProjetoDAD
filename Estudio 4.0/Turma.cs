using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Turma
    {
        private string professor, diaSemana, horaTurma;
        private int idModalidade, qtdeAlunos, idTurma;

        public Turma(int idModalidade)
        {
            this.idModalidade = idModalidade;
        }

        public Turma(int idModalidade, string professor, string diaSemana, string horaTurma)
        {
            this.idModalidade = idModalidade;
            this.professor = professor;
            this.diaSemana = diaSemana;
            this.horaTurma = horaTurma;
        }

        public Turma(string diaSemana, int idModalidade)
        {
            this.diaSemana = diaSemana;
            this.idModalidade = idModalidade;
        }

        public Turma(string professor, string diaSemana, string horaTurma, int idModalidade, int qtdeAlunos)
        {
            this.professor = professor;
            this.diaSemana = diaSemana;
            this.horaTurma = horaTurma;
            this.idModalidade = idModalidade;
            this.qtdeAlunos = qtdeAlunos;
        }

        public Turma(string diaSemana, string horaTurma)
        {
            this.diaSemana = diaSemana;
            this.horaTurma = horaTurma;
        }
        public Turma()
        {

        }

        public string Professor { get => professor; set => professor = value; }
        public string DiaSemana { get => diaSemana; set => diaSemana = value; }
        public string HoraTurma { get => horaTurma; set => horaTurma = value; }
        public int IdModalidade { get => idModalidade; set => idModalidade = value; }
        public int Qtde_Alunos { get => qtdeAlunos; set => qtdeAlunos = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }

        public bool cadastrar()
        {
            bool ins = false;
            try{
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma(idModalidade ,professorTurma, diasemanaTurma, horaTurma) values (" + idModalidade + ",'" + professor + "','" + diaSemana + "','" + horaTurma + ")", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                ins = true;
            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
            return ins;
        }

        public bool consultarBoolean()
        {
            bool existe = false;

            try{
                DAO_Conexao.con.Open();
                MySqlCommand consultaBool = new MySqlCommand("select * from Estudio_Turma where idEstudio_Turma = '" + IdTurma + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consultaBool.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
            return existe;
        }


        public bool atualizar()
        {
            bool updated = false;

            try{
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("update Estudio_Turma set idModalidade='" + idModalidade + "', professorTurma=" + professor + ", horaTurma=" + horaTurma + ", nalunosmatriculadosTurma=" + qtdeAlunos + " where idEstudio_Modalidade=" + idTurma + "", DAO_Conexao.con);
                update.ExecuteNonQuery();
                updated = true;
            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
            return updated;
        }

        public MySqlDataReader consultarTodasTurmas()
        {
            MySqlCommand consult = null;
            MySqlDataReader result = null;

            try{
                DAO_Conexao.con.Open();
                consult = new MySqlCommand("select * from Estudio_Turma", DAO_Conexao.con);
                result = consult.ExecuteReader();
            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            finally{
            }
            return result;
        }

        public bool excluir()
        {
            bool excluir = false;

            try{
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Turma set ativa=1 where idModalidade = " + idTurma, DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                excluir = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }
            return excluir;
        }
        public MySqlDataReader consultarid(int idTurma)
        {
            MySqlCommand consult2 = null;
            MySqlDataReader result2 = null;

            try{
                DAO_Conexao.con.Open();
                consult2 = new MySqlCommand("select * from Estudio_Turma where idModalidade='" + idTurma + "'", DAO_Conexao.con);
                result2 = consult2.ExecuteReader();
            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }

            finally{
            }
            return result2;
        }
    }
}