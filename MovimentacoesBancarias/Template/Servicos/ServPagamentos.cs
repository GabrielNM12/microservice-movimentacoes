using Pagamentos.Servicos;
using Template.Infra;

namespace Pagamentos
{
    public interface IServPagamento
    {
        void RegistrarPagamento(RegistrarPagamentoDTO pagamentoDto);
        List<Pagamentos> BuscarPagamentos();
    }

    public class ServPagamento : IServPagamento
    {
        private DataContext _dataContext;
        private ContasClient _contasClient;

        public ServPagamento()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
            _contasClient = new ContasClient();
        }

        public void RegistrarPagamento(RegistrarPagamentoDTO pagamentoDto)
        {
            var conta = _contasClient.BuscarConta(pagamentoDto.CodigoContaBancaria);

            if (conta == null || !conta.Ativo)
            {
                throw new Exception("Conta bancária inválida ou inativa.");
            }

            Pagamentos pagamento = new Pagamentos
            {
                Valor = pagamentoDto.Valor,
                CodigoContaBancaria = pagamentoDto.CodigoContaBancaria,
                Descricao = pagamentoDto.Descricao,
                FormaPagamento = pagamentoDto.FormaPagamento,
                DataPagamento = DateTime.Now,
                Status = "Pago"
            };

            _dataContext.Add(pagamento);
            _dataContext.SaveChanges();
        }

        public List<Pagamentos> BuscarPagamentos()
        {
            var pagamentos = _dataContext.Pagamentos.ToList();
            return pagamentos;
        }
    }

    public class RegistrarPagamentoDTO
    {
        public int CodigoContaBancaria { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string FormaPagamento { get; set; }
    }

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

    public enum EnumFormaPagamento
    {
        Pix,
        CartaoCredito,
        CartaoDebito,
        Boleto,
        Transferencia
    }
}