namespace Pagamentos
{
    public class RegistrarPagamentoDTO
    {
        public int CodigoContaBancaria { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public string FormaPagamento { get; set; }
    }
}