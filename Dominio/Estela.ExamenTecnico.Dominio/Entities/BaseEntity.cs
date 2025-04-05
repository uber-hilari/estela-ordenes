namespace Estela.ExamenTecnico.Dominio.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Eliminado { get; protected set; } = false;
        public string CreadoPor { get; protected set; } = string.Empty;
        public DateTime CreadoEn { get; protected set; }
        public string ModificadoPor { get; protected set; } = string.Empty;
        public DateTime? ModificadoEn { get; protected set; }
        public string EliminadoPor { get; protected set; } = string.Empty;
        public DateTime? EliminadoEn { get; protected set; }

        public void Eliminar()
        {
            Eliminado = true;
        }
    }
}
