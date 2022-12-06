using System.Collections.Generic;

namespace SecondHand.Models
{
    public class KategorijeCevlji
    {
        public int ID { get; set; }
        public string ImeKategorije { get; set; }
        public char Spol { get; set; }
        public List<Obutev> Obutve { get; set; }
    }
}
