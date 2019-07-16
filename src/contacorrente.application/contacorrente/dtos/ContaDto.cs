using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace contacorrente.application.contacorrente.dtos
{
    [DataContract(Namespace = "http://dbserver.api.com.br/contacorrente/v1/conta")]
    public class ContaDto
    {
        [DataMember]
        public int numeroConta { get; set; }

        [DataMember]
        public int? digito { get; set; }

        [DataMember]
        public double saldoInicial { get; set; }

        [DataMember]
        public double saldoAtual { get; set; }

        [DataMember]
        public double valorTransacao { get; set; }

    }
}
