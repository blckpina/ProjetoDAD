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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnCadastrarMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescricao.Text == "")
                {
                    throw new Exception();
                }

                Modalidade modalidade = new Modalidade(txtDescricao.Text, float.Parse(txtPreco.Text), Convert.ToInt32(txtQtdeAlunos.Text), Convert.ToInt32(txtQtdeAulas.Text));
                if (modalidade.cadastrarModalidade())
                {
                    MessageBox.Show("Modalidade cadastrada com sucesso");
                }
                else
                {
                    MessageBox.Show("Houve um erro ao cadastrar a modalidade");
                }

                txtDescricao.Text = "";
                txtPreco.Text = "";
                txtQtdeAlunos.Text = "";
                txtQtdeAulas.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
