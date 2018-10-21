using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Jugadores.Domain.Enum;
using System;

namespace EnterprisePatterns.Api.Jugadores.Domain.Entity
{
    public class Jugador
    {
        public virtual long Id { get; protected set; }
        public virtual string Nombre { get; }
        public virtual DateTime FechaNacimiento { get; }
        public virtual MpaaPosicion MpaaPosicion { get; }
        public virtual string Pais { get; }
        public virtual Money ValorMercadoPases { get; set; }
        public virtual bool Activo { get; set; }
        public virtual Club Club { get; }

        protected Jugador()
        {
        }
    }
}
