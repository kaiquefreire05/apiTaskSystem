using Refit;
using TaskSystem.Integration.Response;

namespace TaskSystem.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
