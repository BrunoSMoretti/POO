using OperationsRegister.Persistence;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaModificar : UserControl
    {
        public TelaModificar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    if (OperacoesCadastradas.operationsCadastradas != null && OperacoesCadastradas.operationsCadastradas.Count > 0)
                    {
                        foreach (var operation in OperacoesCadastradas.operationsCadastradas.Where(where => where.NomeOperacao == textBox1.Text))
                        {
                            OperacoesCadastradas.operationsCadastradas.Where(where => where.NomeOperacao == textBox1.Text);
                            operation.NomeOperacao = textBox2.Text;
                            operation.Tempo = Convert.ToInt32(textBox3.Text);
                            operation.Unidade = textBox4.Text;

                            MessageBox.Show("Operação modificada", "Sucesso");

                            break;
                        }
                    }
                    else
                        MessageBox.Show("Não existem operações cadastradas no sistema", "Atenção!");
                }
                else
                    MessageBox.Show("Informe o nome da operação que deseja modificar", "Atenção!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }
    }
}