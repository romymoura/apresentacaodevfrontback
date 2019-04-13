using Apresentacao.Business.Services.Interfaces;
using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Entities;
using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Mappings;
using Apresentacao.Domain.Uteis.Response;
using System;

namespace Apresentacao.Business.Services
{
    public class AirplaneApplication : IAirplaneApplication
    {
        private readonly IAirplaneApplicationService AirplaneService;

        public AirplaneApplication(IAirplaneApplicationService airplaneService)
        {
            AirplaneService = airplaneService;
        }

        public ApplicationResponse<AirplaneResponse> DeleteAirplane(AirplaneRequest input)
        {
            try
            {
                AirplaneService.Delete((x => x.Id == input.Id));
                return new ApplicationResponse<AirplaneResponse>(
                    null,
                    ApplicationResponseStatus.Success,
                    "Successfully deleted airplane!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<AirplaneResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Error deleting the airplane!"
                  );
            }
        }

        public ApplicationResponse<AirplaneResponse> GetAirplane(AirplaneRequest input)
        {
            try
            {
                var resultData = AirplaneService.Read((x => x.Id == input.Id));
                return new ApplicationResponse<AirplaneResponse>(
                    new AirplaneResponse()
                    {
                        Airplane = resultData
                    },
                    ApplicationResponseStatus.Success,
                    "Successfully recovered airplane!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<AirplaneResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Error recovered airplane!"
                  );
            }
        }

        public ApplicationResponse<AirplaneResponse> InsertAirplane(AirplaneRequest input)
        {
            try
            {
                Airplane airplane = input.MapTo<Airplane>();
                AirplaneService.Insert(airplane);
                return new ApplicationResponse<AirplaneResponse>(
                    new AirplaneResponse()
                    {
                        Airplane = airplane
                    },
                    ApplicationResponseStatus.Success,
                    "Successfully inserted airplane!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<AirplaneResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Inserting airplane error!"
                  );
            }
        }

        public ApplicationResponse<AirplaneResponse> ListAirplane()
        {
            try
            {
                return new ApplicationResponse<AirplaneResponse>(
                    new AirplaneResponse()
                    {
                        Airplanes = AirplaneService.Read()
                    },
                    ApplicationResponseStatus.Success,
                    "Successfully recovered airplanes!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<AirplaneResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Error recovered airplanes!"
                  );
            }
        }

        public ApplicationResponse<AirplaneResponse> UpdateAirplane(AirplaneRequest input)
        {
            try
            {
                Airplane airplane = input.MapTo<Airplane>();
                AirplaneService.Update(airplane);
                return new ApplicationResponse<AirplaneResponse>(
                    new AirplaneResponse()
                    {
                        Airplane = airplane
                    },
                    ApplicationResponseStatus.Success,
                    "Successfully inserted airplane!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<AirplaneResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Inserting airplane error!"
                  );
            }
        }
    }
}