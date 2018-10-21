using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Mapping
{
    public class ClubMap : ClassMap<Club>
    {
        public ClubMap()
        {
            Id(x => x.Id).Column("club_id");
            Map(x => x.Nombre).Column("club_nombre");
            Map(x => x.Pais).Column("club_pais");
        }
    }
}
