using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IDataReader
    {
        List<Baugette> ReadBaugette(string path);

        Dictionary<string, int> ReadMaterials(string path);
    }
}
