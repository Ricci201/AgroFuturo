namespace AgroFuturo.Models
{
    public class CategoriaInsumo
    {
        public int CategoriaInsumoId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string UnidadeMedida { get; set; }
        public Decimal Quantidade { get; set; }
    }
}
