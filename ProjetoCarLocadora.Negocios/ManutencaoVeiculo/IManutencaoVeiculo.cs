using ProjetoCarLocadora.Models.Models;


namespace ProjetoCarLocadora.Negocios.ManutencaoVeiculo
{
    public interface IManutencaoVeiculo
    {
        Task<List<ManutencaoVeiculoModel>> ListaManutencaoVeiculo();
        Task<ManutencaoVeiculoModel> ObterUmaListaManutencaoVeiculo(int valor);
        Task AlterarListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel);
        Task IncluirListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel);
        Task ExcluirListaManutencaoVeiculo(int valor);
    }
}
