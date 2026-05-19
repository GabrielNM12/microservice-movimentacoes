using Exemplo;
using MovimentacoesBancarias.Servicos;
using Template.Infra;

namespace MovimentacoesBancarias
{
    public class ServMovimentos
    {
        private DataContext _dataContext;
        private ContasClient _contasClient;

        public ServMovimentos()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
            _contasClient = new ContasClient();
        }

        public void RegistrarEntradas(RegistrarMovimentosDTO movimentosDto)
        {
            var conta = _contasClient.BuscarConta(movimentosDto.CodigoContaBancaria);
            if (conta == null || !conta.Ativo)
            {
                throw new Exception("Conta bancária inválida ou inativa.");
            }

            Movimentos movimentos = new Movimentos
            {
                Valor = movimentosDto.Valor,
                CodigoContaBancaria = movimentosDto.CodigoContaBancaria,
                Descricao = movimentosDto.Descricao,
                TipoOperacao = EnumTipoOperacao.Entrada,
                DataOperacao = DateTime.Now
            };

            _dataContext.Add(movimentos);
            _dataContext.SaveChanges();
        }

        public void RegistrarSaidas(RegistrarMovimentosDTO movimentosDto)
        {
            var conta = _contasClient.BuscarConta(movimentosDto.CodigoContaBancaria);
            if (conta == null || !conta.Ativo)
            {
                throw new Exception("Conta bancária inválida ou inativa.");
            }

            Movimentos movimentos = new Movimentos
            {
                Valor = movimentosDto.Valor,
                CodigoContaBancaria = movimentosDto.CodigoContaBancaria,
                Descricao = movimentosDto.Descricao,
                TipoOperacao = EnumTipoOperacao.Saida,
                DataOperacao = DateTime.Now
            };

            _dataContext.Add(movimentos);
            _dataContext.SaveChanges();
        }

        public List<Movimentos> BuscarMovimentacoes()
        {
            var movimentacoes = _dataContext.Movimentos.ToList();
            return movimentacoes;
        }
    }
}
