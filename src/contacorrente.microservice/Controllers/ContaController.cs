using contacorrente.application.contacorrente.messages;
using contacorrente.application.contacorrente.services;
using contacorrente.webapi.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace contacorrente.microservice.Controllers
{

    public class ContaController : Controller
    {
        private readonly IContaService _service;

        public ContaController(IContaService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Route("operacao")]
        [ProducesResponseType(typeof(RealizarTransferenciaResponse), 200)]
        public async Task<ActionResult> RealizarOperacaoAsync([FromBody]RealizarTransferenciaRequest request)
        {
            var result = await _service.IncluirAsync(request);
            return this.GetHttpResponse(result);
        }


    }


}
