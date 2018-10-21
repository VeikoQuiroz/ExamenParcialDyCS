using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using EnterprisePatterns.Api.Jugadores.Domain.Enum;
using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class JugadoresDelanterosSpecification : Specification<Jugador>
    {
        public override Expression<Func<Jugador, bool>> ToExpression()
        {
            return jugador => jugador.MpaaPosicion <= MpaaPosicion.DELANTERO;
        }
    }
}
