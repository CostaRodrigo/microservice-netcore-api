using System;
using System.Collections.Generic;
using System.Text;

namespace contacorrente.domain.contacorrente.models
{
    public class Conta
    {
        public Conta(int numeroConta, int? digito, double saldoInicial)
        {
            this.numeroConta = numeroConta;
            this.digito = digito ?? throw new ArgumentNullException(nameof(digito));
            this.saldoInicial = saldoInicial;
        }

        public int numeroConta { get; private set; }
        public int? digito { get; private set;}
        public double saldoInicial { get; private set; }
        public double saldoAtual { get; private set; }
        public double valorTransacao { get; private set; }

        public void RealizarTransferencia (Conta origem, Conta destino, double valorTransacao)
        {
            if (valorTransacao > 0)
            {
                origem.saldoAtual -= valorTransacao;
                destino.saldoAtual += valorTransacao;
            }
        }

        public static Conta Criar(int numeroConta, int? digito, double saldoInicial)
        {
            return new Conta(numeroConta, digito, saldoInicial);
        }

    }
}
