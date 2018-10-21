using AutoMapper;
using EnterprisePatterns.Api.Jugadores.Application.Dto;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Jugadores.Application.Assembler
{
    public class JugadorAssembler
    {
        private readonly IMapper _mapper;

        public JugadorAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<JugadorDto> toDtoList(List<Jugador> jugadorList)
        {
            return _mapper.Map<List<Jugador>, List<JugadorDto>>(jugadorList);
        }
    }
}