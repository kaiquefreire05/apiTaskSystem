using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Refit;
using TaskSystem.Integration.Response;

namespace TaskSystem.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        // Injecting ViaCepIntegration
        private readonly IViaCepIntegrationRefit _implementation;
        public ViaCepIntegration(IViaCepIntegrationRefit implementation)
        {
            _implementation = implementation;
        }

        // Method
        public async Task<ViaCepResponse> GetViaCepData(string cep)
        {
            var responseData = await _implementation.GetDataViaCep(cep);
            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }
            return null;
        }
    }
}
