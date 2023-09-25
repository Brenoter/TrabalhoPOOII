
namespace Academico.Models
{
    public class Passageiro
    {
        public long? PassageiroID { get; set; }
        public string? Nome { get; set; }
        public string? Viacao { get; set; }
        public long InstituicaoID { get; set; }
        public Instituicao? Instituicao { get; set; }
    }
}
