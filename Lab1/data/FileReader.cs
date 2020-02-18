using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class FileReader: IDataReader
    {
        public List<Baugette> ReadBaugette(string path)
        {
            StreamReader sr = new StreamReader(path);

            List<Baugette> bauglist = new List<Baugette>();

            string name, line, line2;
            int count, count2;
            while((name = sr.ReadLine()) != null)
            {
                line = sr.ReadLine();
                line2 = sr.ReadLine();
                count = Convert.ToInt32(sr.ReadLine());
                count2 = Convert.ToInt32(sr.ReadLine());
                bauglist.Add(new Baugette(name, new string[] {line, line2}, new int[] {count, count2}));
            }

            sr.Close();
            return bauglist;
        }

        public Dictionary<string, int> ReadMaterials(string path)
        {
            StreamReader sr = new StreamReader(path);

            Dictionary<string, int> matlist = new Dictionary<string, int>();

            string line;
            int count;
            while ((line = sr.ReadLine()) != null)
            {
                count = Convert.ToInt32(sr.ReadLine());
                matlist.Add(line, count);
            }

            sr.Close();
            return matlist;
        }

    }
}
