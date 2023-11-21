using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abak
{
    public class toode
    {
        public int Id { get; set; }
        public string Toodenimetus { get; set; }
        public int kogus { get; set; }
        public float hind { get; set; }
        public string pilt { get; set; }
        public IEnumerable<KATEGOORIA> KATEGOORIAD { get;set; }
    }
    public class KATEGOORIA
    {
        public int Id { get; set; }
        public string kategooria_nimetus { get; set; }
        public string kirjeldus { get; set; }
    }
}
