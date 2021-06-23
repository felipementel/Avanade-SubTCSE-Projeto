namespace Avanade.SubTCSE.Projeto.Domain.Aggregates
{
    public record BaseEntity<Tid>
    {
        public Tid Id { get; set; }
    }
}
