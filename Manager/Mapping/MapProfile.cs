using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
        }
    }
}
