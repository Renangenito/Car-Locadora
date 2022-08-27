using ProjetoCarLocadora.Models.Models;


namespace ProjetoCarLocadora.Negocios.ManutencaoVeiculo
{
    public interface IManutencaoVeiculo
    {
        List<ManutencaoVeiculoModel> ListaManutencaoVeiculo();
        ManutencaoVeiculoModel ObterUmaListaManutencaoVeiculo(int valor);
        void AlterarListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel);
        void IncluirListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel);
        void ExcluirListaManutencaoVeiculo(int valor);
    }
}
