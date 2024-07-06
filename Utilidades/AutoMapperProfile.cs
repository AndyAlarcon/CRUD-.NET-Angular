using AutoMapper;
using EmployeeAPI.DTOs;
using EmployeeAPI.Models;
using System.Globalization;

namespace EmployeeAPI.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(empDTO => empDTO.NombreDepartamento, 
                opt => opt.MapFrom(emp => emp.IdDepartamentoNavigation.Nombre)
                )
                .ForMember(empDTO => empDTO.FechaContrato,
                opt => opt.MapFrom(emp => emp.FechaContrato.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(emp => emp.IdDepartamentoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(emp => emp.FechaContrato,
                opt => opt.MapFrom(empDTO => DateTime.ParseExact(empDTO.FechaContrato, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion
        }
    }
}
