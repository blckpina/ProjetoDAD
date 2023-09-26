using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Modalidade
    {
        private string Descricao;
        private float preco;
        private int qtde_alunos, qtde_aulas;

        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public int Qtde_aulas { get => qtde_aulas; set => qtde_aulas = value; }

        public Modalidade(string descricao, float preco, int qtde_alunos, int qtde_aulas)
        {
            this.Descricao = descricao;
            this.preco = preco;
            this.qtde_alunos = qtde_alunos;
            this.qtde_aulas = qtde_aulas;

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
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade (idEstudio_Modalidade, descricaoModalidade, precoModalidade, qtdeAlunos, " +
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

        public MySqlDataReader consultarModalidade()
        {
            MySqlDataReader reader = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade " +
                    "WHERE descricaoModalidade='" + Descricao + "'", DAO_Conexao.con);
                reader = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();

            }
            return reader;
        }

        public MySqlDataReader consultarTodasModalidades()
        {
            MySqlDataReader reader2 = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT descricaoModalidade FROM Estudio_Modalidade ", DAO_Conexao.con);
                reader2 = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return reader2;
        }

        public bool atualizarModalidade()
        {
            bool exc2 = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Modalidade set descricaoModalidade = '" + Descricao + "', precoModalidade = '" + preco + "', qtdeAlunos = '" + qtde_alunos + "', qtdeAulas = '" + qtde_aulas + "'", DAO_Conexao.con);
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
                MySqlCommand exclui = new MySqlCommand("update Estudio_Modalidade set ativo " +
                    "= 1 where Descricao = '" + Descricao + "'", DAO_Conexao.con);
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
    }
}
