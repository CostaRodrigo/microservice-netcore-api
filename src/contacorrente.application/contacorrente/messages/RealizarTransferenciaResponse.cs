using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace contacorrente.application.contacorrente.messages
{
    [DataContract(Namespace = "http://dbserver.api.com.br/contacorrente/v1/conta")]
    public class RealizarTransferenciaResponse
    {
        [DataMember]
        public IList<string> Retorno { get; set; } = new List<string>();

        [DataMember]
        public string Mensagem { get; set; }

        [DataMember]
        public bool Valido { get; set; }

        
    }
}
