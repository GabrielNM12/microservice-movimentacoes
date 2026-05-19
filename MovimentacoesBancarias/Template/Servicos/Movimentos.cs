namespace MovimentacoesBancarias.Servicos
{
    public class Movimentos
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public EnumTipoOperacao TipoOperacao { get; set; }
        public int CodigoContaBancaria { get; set; }
        public DateTime DataOperacao { get; set; } = DateTime.Now;
        public string Descricao { get; set; } = string.Empty;
    }
    public enum EnumTipoOperacao
    {
        Entrada = 1,
        Saida = 2
    }
}