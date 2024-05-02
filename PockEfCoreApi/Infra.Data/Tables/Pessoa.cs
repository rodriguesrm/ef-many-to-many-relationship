namespace PockEfCoreApi.Infra.Data.Tables
{
    public class Pessoa
    {

        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateTime Nascimento { get; set; }

        public virtual ICollection<Tipo> Tipos { get; set; } = new List<Tipo>();

    }
}
