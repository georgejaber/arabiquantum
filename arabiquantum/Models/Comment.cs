using System.Numerics;

namespace arabiquantum.Models
{
    public class Class
    {
        [key]
        public long Id { get; set; }
        public string text { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public BigInteger like { get; set; }
        public BigInteger dislike { get; set; }
    }
}
