using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class JugadorClubBySpecification : Specification<Jugador>
    {
        private readonly string _club;

        public JugadorClubBySpecification(string club)
        {
            _club = club;
        }

        public override Expression<Func<Jugador, bool>> ToExpression()
        {
            return jugador => jugador.Club.Nombre == _club;
        }
    }
}
