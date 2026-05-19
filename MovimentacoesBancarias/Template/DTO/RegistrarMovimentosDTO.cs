using MovimentacoesBancarias.Servicos;

namespace MovimentacoesBancarias
{
    public class RegistrarMovimentosDTO
    {
        public decimal Valor { get; set; }
        public int CodigoContaBancaria { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
