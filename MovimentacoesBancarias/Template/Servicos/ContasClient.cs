namespace MovimentacoesBancarias
{
    public class ContaDTO
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public bool Ativo { get; set; }
    }

    public class ContasClient
    {
        public ContaDTO? BuscarConta(int codigoConta) 
        {
            try
            {
                var httpClient = new HttpClient();
                var urlMicrosservico = "http://localhost:5089";
                var urlBusca = $"{urlMicrosservico}/api/Contas/{codigoConta}";

                var response = httpClient.GetAsync(urlBusca).Result;
                var dadosConta = response.Content.ReadFromJsonAsync<ContaDTO>().Result;

                if (dadosConta == null)
                {
                    Console.WriteLine("Conta não encontrada.");
                    return null;
                }

                return dadosConta;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar conta: {ex.Message}");
                return null;
            }
        }
    }
}
