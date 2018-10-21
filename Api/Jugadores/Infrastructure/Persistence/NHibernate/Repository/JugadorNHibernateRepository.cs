using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using EnterprisePatterns.Api.Jugadores.Domain.Repository;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Repository
{
    public class JugadorNHibernateRepository : BaseNHibernateRepository<Jugador>, IJugadorRepository
    {
        public JugadorNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Jugador> GetList(
            Specification<Jugador> specification,
            int page = 0,
            int pageSize = 5)
        {
            List<Jugador> jugadores = new List<Jugador>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                jugadores = _unitOfWork.GetSession().Query<Jugador>()
                    .Where(specification.ToExpression())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .Fetch(x => x.Club)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return jugadores;
        }
    }
}
