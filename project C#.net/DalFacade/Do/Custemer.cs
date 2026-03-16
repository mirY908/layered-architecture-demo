using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
    public record Custemer(int CustemerId, string CustemerName,string? Adress,string? phone)
    {
        public Custemer() : this(123, "aaa","aaa", "123456789") { }
    }
}
