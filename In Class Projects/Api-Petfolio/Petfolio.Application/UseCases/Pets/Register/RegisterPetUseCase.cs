using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.Register;

// Primeira Regra de Negócio
// Funções para Registrar um 'Pet'
// Só existirá UMA função pública! As demais serão privadas e auxiliarão a regra de negócio
// As funções públicas serão chamadas de 'Execute'
public class RegisterPetUseCase
{
    public ResponseRegisterPetJson Execute(RequestPetJson request)
    {
        return new ResponseRegisterPetJson
        {
            Id = 7,
            Name = request.Name,
        };
    }
}
