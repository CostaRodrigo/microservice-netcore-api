using contacorrente.application.contacorrente.dtos;
using contacorrente.domain.contacorrente.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace contacorrente.application.impl.contacorrente.mappers
{
    public static class ContaMapper
    {
        public static Conta Map(this ContaDto dto)
        {
            return  Conta.Criar(dto.numeroConta,dto.digito,dto.saldoInicial);
        }

        public static ContaDto Map(this Conta entity)
        {
            return new ContaDto
            {
                numeroConta = entity.numeroConta,
                digito = entity.digito,
                saldoInicial = entity.saldoInicial
            };
        }

        public static IList<Conta> Map(this IList<ContaDto> dtos)
        {
            var contas = new List<Conta>();
            foreach (var dto in dtos)
            {
                var conta = Conta.Criar(dto.numeroConta, dto.digito, dto.saldoInicial);
                contas.Add(conta);
            }
            return contas;
        }

        public static IList<ContaDto> Map(this IList<Conta> entities)
        {
            var dtos = new List<ContaDto>();
            foreach (var entity in entities)
            {
                var dto = new ContaDto
                {
                    numeroConta = entity.numeroConta,
                    digito = entity.digito,
                    saldoInicial = entity.saldoInicial
                };
            }
            return dtos;
        }

    }
}
