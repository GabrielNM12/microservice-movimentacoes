namespace Pagamentos
{
    public class Pagamentos
    {
        public int Id { get; set; }

        public int CodigoContaBancaria { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public string FormaPagamento { get; set; }

        public DateTime DataPagamento { get; set; }

        public string Status { get; set; }
    }
}