using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Jugadores.Domain.Repository
{
    public interface IJugadorRepository
    {
        List<Jugador> GetList(
            Specification<Jugador> specification,
            int page = 0,
            int pageSize = 5);
    }
}