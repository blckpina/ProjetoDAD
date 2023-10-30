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
    public partial class Form8 : Form
    {
        private bool atualiza;
        String descricaoSelected;

        public Form8(bool atualiza)
        {
            InitializeComponent();

            Modalidade mod1 = new Modalidade();
            MySqlDataReader result = mod1.consultarTodasModalidades();
            while (result.Read()){
                cbbDescricao.Items.Add(result["descricaoModalidade"].ToString());
            }

            DAO_Conexao.con.Close();
            this.atualiza = atualiza;

            if (!atualiza){

                btnAtualizar.Visible = false;
                txtQtdeAlunos.Enabled = false;
                txtQtdeAulas.Enabled = false;
                txtPreco.Enabled = false;
                checkBox1.Enabled = false;

            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try{
                if (atualiza)
                {
                    float preco = float.Parse(txtPreco.Text);
                    int QtdeAlunos = int.Parse(txtQtdeAlunos.Text);
                    int QtdeAulas = int.Parse(txtQtdeAulas.Text);
                    int a;

                    if (checkBox1.Checked)
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }

                    Modalidade mod2 = new Modalidade(descricaoSelected, preco, QtdeAlunos, QtdeAulas, a);

                    if(mod2.atualizarModalidade())
                    {
                        MessageBox.Show("Atualização feita com êxito");

                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar");
                    }
                }
                else
                {
                    try
                    {
                        Modalidade mod3 = new Modalidade();
                        descricaoSelected = cbbDescricao.SelectedItem.ToString();
                        MessageBox.Show(descricaoSelected);
                        MySqlDataReader reader = mod3.consultarModalidade(descricaoSelected);
                        while (reader.Read()){
                            descricaoSelected = reader["descricaoModalidade"].ToString();
                            txtQtdeAlunos.Text = reader["qtdeAlunos"].ToString();
                            txtQtdeAulas.Text = reader["qtdeAulas"].ToString();
                            txtPreco.Text = reader["precoModalidade"].ToString();
                        }
                        DAO_Conexao.con.Close();
                    }
                    catch (Exception ex){
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show("Não deve ter campos vazios");
            }

        }

        private void cbbDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                Modalidade mod3 = new Modalidade();
                descricaoSelected = cbbDescricao.SelectedItem.ToString();
                MySqlDataReader reader = mod3.consultarModalidade(descricaoSelected);
                while (reader.Read()){
                    descricaoSelected = reader["descricaoModalidade"].ToString();
                    txtQtdeAlunos.Text = reader["qtdeAlunos"].ToString();
                    txtQtdeAulas.Text = reader["qtdeAulas"].ToString();
                    txtPreco.Text = reader["precoModalidade"].ToString();

                    if (reader["ativa"].ToString().Equals("1")){
                        checkBox1.Checked = true;
                    }
                    else{
                        checkBox1.Checked = false;
                    }
                }

                DAO_Conexao.con.Close();

            }
                catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
