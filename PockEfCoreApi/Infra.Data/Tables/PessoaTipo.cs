namespace PockEfCoreApi.Infra.Data.Tables
{
    public class PessoaTipo
    {

        public int PessoaId { get; set; }

        public int TipoId { get; set; }

        public virtual Pessoa? Pessoa { get; set; }

        public virtual Tipo? Tipo { get; set; }

    }
}
