using SimpleCRM.Contracts;
using SimpleCRM.Entities.Models;
using SimpleCRM.Entities.DTOs;
using AutoMapper;

namespace SimpleCRM.Mappers
{
	/// <summary>
	/// AutoMapper profile for mapping entities to DTOs and vice versa.
	/// </summary>
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Customer, CustomerDTO>();
			CreateMap<CustomerCreationDTO, Customer>();
		}
	}
}
