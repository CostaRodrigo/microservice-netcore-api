using contacorrente.application.contacorrente.dtos;
using contacorrente.core.validations;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace contacorrente.application.contacorrente.messages
{
    [DataContract(Namespace = "http://dbserver.api.com.br/contacorrente/v1/conta")]
    public class RealizarTransferenciaRequest
    {

        [DataMember]
        public IList<ContaDto> Contas { get; set; } = new List<ContaDto>();

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator.RuleFor(request => request.Contas)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotNull()
                      .NotEmpty()
                      .WithErrorCode("As contas devem ser informadas!");
        }

        public RealizarTransferenciaRequest()
        {
            SetValidationRules();
        }


        private readonly EnterpriseValidator<RealizarTransferenciaRequest> _validator = new EnterpriseValidator<RealizarTransferenciaRequest>();

    }
}
