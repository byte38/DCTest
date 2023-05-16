using AutoMapper;
using DCTest.DTOs;
using DCTest.Entities;

namespace DCTest.Profiles {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Data, DataDto> ();
        }
    }
}
