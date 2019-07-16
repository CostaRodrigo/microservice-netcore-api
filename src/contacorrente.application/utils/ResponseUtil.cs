using contacorrente.application.contacorrente.messages;
using System;
using System.Collections.Generic;

namespace contacorrente.application.utils
{
    public class ResponseUtil
    {
        public static T GetRequestIsNullResponse<T>() where T : RealizarTransferenciaResponse, new()
        {
            var response = new T
            {
                Valido = false,
                Mensagem = "O 'request' é inválido!"
                
            };
            return response;
        }

        public static T GetInvalidRequestResponse<T>(string error) where T : RealizarTransferenciaResponse, new()
        {
   
            var response = new T
            {
                Valido = false,
                Mensagem = error
            };
            return response;
        }
    }
}
