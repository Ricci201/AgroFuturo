namespace AgroFuturo.Models
{
    public class ConsumoInsumo
    {
        public int ConsumoInsumoId { get; set; }
        public decimal QuantidadeConsumida { get; set; }
        public DateTime SafraInicio { get; set; }
        public DateTime SafraFim { get; set; }
        public Decimal CustoTotal { get; set; }

        public int EquipamentoId { get; set; }
        public Equipamento? Equipamento { get; set; }

        public int CategoriaInsumoId { get; set; }
        public CategoriaInsumo? CategoriaInsumo { get; set; }

        public int FazendaId { get; set; }
        public Fazenda? Fazenda { get; set; }
    }
}
