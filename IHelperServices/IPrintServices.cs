using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHelperServices
{
    public interface IPrintServices : _IHelperService
    {

        byte[] ExportPDF(string html);

    }
}
