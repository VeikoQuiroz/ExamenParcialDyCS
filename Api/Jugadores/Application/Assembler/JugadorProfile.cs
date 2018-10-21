using AutoMapper;
using EnterprisePatterns.Api.Jugadores.Application.Dto;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;

namespace EnterprisePatterns.Api.BankAccounts.Application.Assembler
{
    public class JugadorProfile : Profile
    {
        public JugadorProfile()
        {
            CreateMap<Jugador, JugadorDto>()
                .ForMember(
                    dest => dest.Club,
                    x => x.MapFrom(src => src.Club.Nombre)
                )
                .ForMember(
                    dest => dest.MpaaPosicion,
                    x => x.MapFrom(src => src.MpaaPosicion.ToString())
                );
        }
    }
}
