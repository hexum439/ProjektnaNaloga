using System.Collections.Generic;

namespace SecondHand.Models
{
    public class KategorijeOblacila
    {
        public int ID { get; set; }
        public string ImeKategorije { get; set; }
        public char Spol { get; set; }

        public List<Oblacila> Oblacila { get; set; }
    }
}
