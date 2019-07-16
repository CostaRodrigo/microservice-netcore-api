using contacorrente.application.contacorrente.messages;
using contacorrente.application.contacorrente.services;
using System;
using System.Threading.Tasks;
using static contacorrente.application.utils.ResponseUtil;

namespace contacorrente.application.impl.contacorrente.services
{
    public class ContaService : IContaService
    {

        private readonly IContaServiceValidator _validator;

        public ContaService(IContaServiceValidator validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
         }

        public async Task<RealizarTransferenciaResponse> IncluirAsync(RealizarTransferenciaRequest request)
        {
            var response = new RealizarTransferenciaResponse();
            try
            {
                response = await _validator.ValidateAsync(request);
                if (!response.Valido) return response;

            }
            catch (Exception ex)
            {
                return GetInvalidRequestResponse<RealizarTransferenciaResponse>(ex.InnerException.ToString());
            }
            return response;
        }
    }
}
