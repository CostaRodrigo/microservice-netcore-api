using contacorrente.application.contacorrente.messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contacorrente.application.contacorrente.services
{
    public interface IContaService
    {
        Task<RealizarTransferenciaResponse> IncluirAsync(RealizarTransferenciaRequest request);
    }
}
