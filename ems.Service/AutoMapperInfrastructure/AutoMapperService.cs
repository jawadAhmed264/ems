using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.Service.AutoMapperInfrastructure
{
    public class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ems.Service.AutoMapperInfrastructure.ObjectMapper.Mapper; }
        }
    }
}
