using System;

namespace CaseSolution.Models
{
    public class OrderVM
    {
        public int SiraNO { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal StokMiktar { get; set; }
        public decimal GirisMiktar { get; set; }
        public decimal CikisMiktar { get; set; }
        
    }
}
