using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Modalidade
    {
        private string Descricao;
        private float preco;
        private int qtde_alunos, qtde_aulas;
        private int a;

        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public int Qtde_aulas { get => qtde_aulas; set => qtde_aulas = value; }
        public int A { get => a; set => a = value; }

        public Modalidade(string descricao, float preco, int qtde_alunos, int qtde_aulas)
        {
            this.Descricao = descricao;
            this.preco = preco;
            this.qtde_alunos = qtde_alunos;
            this.qtde_aulas = qtde_aulas;
        }

        public Modalidade(string descricao, float preco, int qtde_alunos, int qtde_aulas, int a)
        {
            this.Descricao = descricao;
            this.preco = preco;
            this.qtde_alunos = qtde_alunos;
            this.qtde_aulas = qtde_aulas;
            this.a = a;
        }

        public Modalidade(string descricao)
        {
            this.Descricao = descricao;
        }

        public Modalidade()
        {
        }


        public bool cadastrarModalidade()
        {
            bool cad2 = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade (descricaoModalidade, precoModalidade, qtdeAlunos, " +
                    "qtdeAulas) values " +
                    "('" + Descricao + "','" + preco + "','" + qtde_alunos + "','" + qtde_aulas + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad2 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad2;
        }

        public MySqlDataReader consultarModalidade(String descricaoSelected)
        {
            MySqlDataReader reader = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade " +
                    "WHERE descricaoModalidade='" + descricaoSelected + "'", DAO_Conexao.con);
                reader = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
            }
            return reader;
        }

        public MySqlDataReader consultarTodasModalidades()
        {
            MySqlCommand consulta = null;
            MySqlDataReader reader2 = null;
            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade", DAO_Conexao.con);
                reader2 = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
            }
            return reader2;
        }

        public bool consultarModalidade2() 
        {
            bool c = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consult = new MySqlCommand("SELECT * FROM Estudio_Modalidade WHERE descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consult.ExecuteReader();
                if (resultado.Read())
                {
                    c = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                DAO_Conexao.con.Close();
            }

            return c;
        }

        public bool atualizarModalidade()
        {
            bool exc2 = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Modalidade set descricaoModalidade='" + Descricao + "', precoModalidade = " + preco + ", qtdeAlunos = " + qtde_alunos + ", qtdeAulas = " + qtde_aulas + ", ativa = " + a + "", DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
                exc2 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc2;
        }

        public bool excluirModalidade()
        {
            bool exc2 = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Modalidade set ativa = 1 where descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc2 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc2;
        }

        public MySqlDataReader consultarModalidadeAtivo()
        {
            MySqlCommand consulta = null;
            MySqlDataReader resultado = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("select * from Estudio_Modalidade where ativa=0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
            }
            return resultado;
        }
    }
}
