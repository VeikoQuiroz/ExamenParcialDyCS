namespace EnterprisePatterns.Api.Jugadores.Domain.Entity
{
    public class Club
    {
        public virtual long Id { get; protected set; }
        public virtual string Nombre { get; }
        public virtual string Pais { get; }
    }
}
