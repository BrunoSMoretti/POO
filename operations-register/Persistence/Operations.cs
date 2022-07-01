using System.Collections.Generic;
using System.ComponentModel;

namespace OperationsRegister.Persistence
{
    public static class OperacoesCadastradas
    {
        public static List<Operations> operationsCadastradas = new List<Operations>();
    }

    public class Operations
    {
        [DisplayName("Nome da operação")]
        public string NomeOperacao { get; set; }

        [DisplayName("Tempo total")]
        public int Tempo { get; set; }

        [DisplayName("Unidade de tempo")]
        public string Unidade { get; set; }
    }
}