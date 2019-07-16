using contacorrente.application.contacorrente.messages;
using contacorrente.application.contacorrente.services;
using System.Threading.Tasks;
using static contacorrente.application.utils.ResponseUtil;

namespace contacorrente.application.impl.contacorrente.services
{
    public class ContaServiceValidator : IContaServiceValidator
    {
        public async Task<RealizarTransferenciaResponse> ValidateAsync(RealizarTransferenciaRequest request)
        {
            var response = new RealizarTransferenciaResponse();

            if (request == null)
                return GetRequestIsNullResponse<RealizarTransferenciaResponse>();

                        
            return response;
        }
    }
}
