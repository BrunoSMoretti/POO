using OperationsRegister.Persistence;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaProcura : UserControl
    {
        public TelaProcura()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

                            textBox2.Text = operation.NomeOperacao;
                            textBox3.Text = Convert.ToString(operation.Tempo);
                            textBox4.Text = operation.Unidade;

                            // MessageBox.Show("Operação encontrada", "Sucesso");

                            break;
                        }
                    }
                    else
                        MessageBox.Show("Não existem operações cadastradas no sistema", "Atenção!");
                }
                else
                    MessageBox.Show("Informe o nome da operação que deseja procurar", "Atenção!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
        }*/
    }
}