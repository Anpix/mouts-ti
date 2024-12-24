using AutoMapper;
using SalesApi.Application.UseCases.Sales.Models;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Automapper;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<Sale, SaleDto>().ReverseMap();
    }
}
