using EnterprisePatterns.Api.Common.Application.Enum;
using System;

namespace EnterprisePatterns.Api.Jugadores.Application.Dto
{
    public class JugadorDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string MpaaPosicion { get; set; }
        public virtual string pais { get; set; }
        public Decimal ValorPase { get; set; }
        public Currency Currency { get; set; }
        public bool Activo { get; set; }
        public virtual string Club { get; set; }

        public JugadorDto()
        {
            Activo = false;
        }
    }
}
