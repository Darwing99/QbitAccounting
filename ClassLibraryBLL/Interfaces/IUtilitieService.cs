using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Interfaces
{
    public interface IUtilitieService
    {
        string GenerarClave();
        string ConvertirSha256(string Text);
    }
}
