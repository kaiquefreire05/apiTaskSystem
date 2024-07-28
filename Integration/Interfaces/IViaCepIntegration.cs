using TaskSystem.Integration.Response;

namespace TaskSystem.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetViaCepData(string cep);
    }
}
