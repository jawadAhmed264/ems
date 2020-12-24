using AutoMapper;

namespace ems.Service.AutoMapperInfrastructure
{
    public interface IAutoMapperService
    {
        IMapper Mapper { get; }
    }
}
