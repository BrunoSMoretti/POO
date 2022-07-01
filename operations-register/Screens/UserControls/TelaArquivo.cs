using OperationsRegister.Persistence;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaArquivo : UserControl
    {
        private object operations;

        public TelaArquivo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("O arquivo importado deve estar no seguinte formato!" +
                    Environment.NewLine + Environment.NewLine + "valor;valor;valor" +
                    Environment.NewLine + Environment.NewLine + "Por exemplo:" +
                    Environment.NewLine + Environment.NewLine + "Pintura;10;horas" +
                    Environment.NewLine + "Estampagem;55;minutos" +
                    "", "Atenção!");

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = openFileDialog1.FileNames[0];

                    string[] lines = System.IO.File.ReadAllLines(@pathFile);

                    if (lines.Length == 0)
                    {
                        MessageBox.Show("Não existem operações no arquivo informado.", "Atenção!");
                        return;
                    }

                    foreach (string line in lines)
                    {
                        Operations operations = new Operations();

                        operations.NomeOperacao = line.Split(';')[0];
                        operations.Tempo = Convert.ToInt32(line.Split(';')[1]);
                        operations.Unidade = line.Split(';')[2];

                        OperacoesCadastradas.operationsCadastradas.Add(operations);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperacoesCadastradas.operationsCadastradas.Count == 0)
                {
                    MessageBox.Show("Não existem operações cadastradas no sistema", "Atenção!");
                    return;
                }

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = "Operacoes_" + DateTime.Now.ToString("HH_mm_ss dd_MM_yyyy") + ".txt";
                    string pathFile = folderBrowserDialog1.SelectedPath + "\\" + fileName;

                    File.WriteAllText(pathFile, string.Empty);

                    foreach (var operations in OperacoesCadastradas.operationsCadastradas)
                    {
                        File.AppendAllText(@pathFile, operations.NomeOperacao);
                        File.AppendAllText(@pathFile, ";");
                        File.AppendAllText(@pathFile, Convert.ToString(operations.Tempo));
                        File.AppendAllText(@pathFile, ";");
                        File.AppendAllText(@pathFile, operations.Unidade);
                        File.AppendAllText(@pathFile, "\n");
                    }

                    MessageBox.Show("Arquivo exportado com sucesso." +
                        Environment.NewLine + Environment.NewLine + "Nome do arquivo: " + fileName +
                        Environment.NewLine + Environment.NewLine + "Caminho do arquivo:" +
                        Environment.NewLine + @pathFile, "Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }

        private Operations Operations()
        {
            throw new NotImplementedException();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}