using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Workshop
    {
        private List<Baugette> baugette_types;
        private Dictionary<string, int> materials;
        private Dictionary<int, int> order;

        public Workshop()
        {
            baugette_types = FileReader.ReadBaugette("Files/Baugette.txt");
            materials = FileReader.ReadMaterials("Files/Materials.txt");
            order = new Dictionary<int, int>();
        }

        public void AddOrder(int type, int count)
        {
            this.order.Add(type, count);
        }

        public Dictionary<string, int> GetMaterials()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            Dictionary<string, int> required_materials = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> pair in materials)
            {
                required_materials.Add(pair.Key, 0);
                output.Add(pair.Key, 0);
            }

            foreach (KeyValuePair<int, int> pair in order)
            {
                for (int i = 0; i < baugette_types[pair.Key].materials.Count(); i++)
                    required_materials[baugette_types[pair.Key].materials[i]] += baugette_types[pair.Key].count[i] * pair.Value;
            }

            foreach (KeyValuePair<string, int> pair in required_materials)
            {
                if (materials[pair.Key] < pair.Value)
                    output[pair.Key] = pair.Value - materials[pair.Key];
            }

            foreach (KeyValuePair<string, int> pair in output)
            {
                if (pair.Value != 0)
                    return output;
            }
            return null;
        }

        public List<Baugette> GetBaugetteList()
        {
            return this.baugette_types;
        }
    }
}