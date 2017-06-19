using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TheMachineCafe.Models;
using TheMachineCafe.Dtos;

namespace TheMachineCafe.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Selection, SelectionDto>();
            Mapper.CreateMap<SelectionDto, Selection>();
            Mapper.CreateMap<Boisson, BoissonDto>();
            Mapper.CreateMap<BoissonDto, Boisson>();
        }
    }
}