using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Jugadores.Application.Assembler;
using EnterprisePatterns.Api.Jugadores.Application.Dto;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using EnterprisePatterns.Api.Jugadores.Domain.Repository;
using EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Jugadores.Controllers
{
    [Route("v1/jugadores")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly JugadorAssembler _jugadorAssembler;

        public JugadoresController(
            IUnitOfWork unitOfWork, 
            IJugadorRepository jugadorRepository, 
            JugadorAssembler jugadorAssembler)
        {
            _unitOfWork = unitOfWork;
            _jugadorRepository = jugadorRepository;
            _jugadorAssembler = jugadorAssembler;
        }

        [HttpGet]
        public IActionResult Jugadores([FromQuery]bool forKidsOnly, [FromQuery]bool onCD)
        {
            bool uowStatus = false;
            try
            {
                Specification<Jugador> specification = GetJugadorSpecification();
                uowStatus = _unitOfWork.BeginTransaction();
                List<Jugador> jugadores = _jugadorRepository.GetList(specification);
                _unitOfWork.Commit(uowStatus);
                List<JugadorDto> jugadoresDto = _jugadorAssembler.toDtoList(jugadores);
                return StatusCode(StatusCodes.Status200OK, jugadoresDto);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }
        }

        private Specification<Jugador> GetJugadorSpecification()
        {
            Specification<Jugador> specification = Specification<Jugador>.All;
            
            specification = specification.And(new JugadoresDelanterosSpecification());
            specification = specification.And(new JugadorClubBySpecification("UNIVERSITARIO DE DEPORTES"));            
            return specification;
        }
    }
}
