namespace Apresentacao.CrossCuting.Helpers.RegisterService
{
    public class IoCMappingProfile : AutoMapper.Profile
    {
        public IoCMappingProfile()
        {
            //Aqui cria a passagens de valores entre entidade e dto ou models e vice versa.
            //Não vou implementar pois não ocorreu a necessidade.
            //CreateMap<Entity, DTO>().ReverseMap();
        }
    }
}
