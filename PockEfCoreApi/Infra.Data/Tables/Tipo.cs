namespace PockEfCoreApi.Infra.Data.Tables
{
    public class Tipo
    {

        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    }
}
