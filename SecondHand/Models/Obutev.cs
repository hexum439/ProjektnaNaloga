using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHand.Models
{
    public class Obutev
    {
        [Key]
        public int Id { get; set; }
        public string ImeCevlja { get; set; }
        public string SlikaCevljaUrl { get; set; }
        public double StCevlja { get; set; }
        public string opis { get; set; }
        public string znamka { get; set; }

        //kategorija
        public int KategorijaId { get; set; }
        [ForeignKey("KategorijaId")]
        public KategorijeCevlji Kategorija { get; set; }
    }
}
