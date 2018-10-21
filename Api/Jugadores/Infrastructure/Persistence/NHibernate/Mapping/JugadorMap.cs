using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Jugadores.Domain.Entity;
using EnterprisePatterns.Api.Jugadores.Domain.Enum;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Jugadores.Infrastructure.Persistence.NHibernate.Mapping
{
    public class JugadorMap : ClassMap<Jugador>
    {
        public JugadorMap()
        {
            Id(x => x.Id).Column("jugador_id");
            Map(x => x.Nombre).Column("jugador_nombre");
            Map(x => x.FechaNacimiento).Column("jugador_FechaNacimiento");
            Map(x => x.MpaaPosicion).CustomType<int>().Column("mpaa_posiscion");
            Map(x => x.Pais).Column("jugador_pais");
            Component(x => x.ValorMercadoPases, m =>
            {
                m.Map(x => x.Amount, "jugador_valorMercado");
                m.Map(x => x.Currency, "currency");
            });
            Map(x => x.Activo).CustomType<bool>().Column("jugador_activo");
            References(x => x.Club);
        }
    }
}
