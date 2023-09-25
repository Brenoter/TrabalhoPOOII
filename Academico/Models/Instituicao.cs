namespace Academico.Models
{
    public class Instituicao
    {
        public long? InstituicaoID { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public virtual ICollection<Passageiro>? Passageiros { get; set;}
    }
}
