using contacorrente.application.contacorrente.messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacorrente.webapi.Extensions
{
    public static class ControllerExtensions
    {

        public static ActionResult GetHttpResponse(this Controller controller, RealizarTransferenciaResponse response)
        {
            if (response == null)
                return controller.BadRequest(response);

            if (!response.Valido)
            {
                if (!response.Mensagem.Any())
                {
                    return controller.BadRequest(response);
                }

                
            }

             return controller.Ok(response);
        }

        public static ActionResult Conflict(this Controller controller, RealizarTransferenciaResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status409Conflict
            };
        }
    }
}
