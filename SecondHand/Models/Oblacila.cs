using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHand.Models
{
    public class Oblacila
    {
        [Key]
        public int Id { get; set; }
        public string ImeOblacila { get; set; }
        public string SlikaOblekeUrl { get; set; }
        public string opis { get; set; }


        //kategorija
        public int KategorijaId { get; set; }
        [ForeignKey("KategorijaId")]
        public KategorijeOblacila Kategorija { get; set; }
     }
}
