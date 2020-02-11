using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Workshop
    {
        private List<Baugette> baugetteTypes;
        private Dictionary<string, int> materials;
        private Dictionary<int, int> order;

        private string baugettePath = "Files/Baugette.txt";
        private string materialsPath = "Files/Materials.txt";

        public Workshop()
        {
            baugetteTypes = FileReader.ReadBaugette(baugettePath);
            materials = FileReader.ReadMaterials(materialsPath);
            order = new Dictionary<int, int>();
        }

        public void AddOrder(int type, int count)
        {
            this.order.Add(type, count);
        }

        public Dictionary<string, int> GetMaterials()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            Dictionary<string, int> requiredMaterials = new Dictionary<string, int>();

            FillDictionaries(requiredMaterials, output);
            CountMaterials(requiredMaterials);
            SubstractMaterials(requiredMaterials, output);

            foreach (KeyValuePair<string, int> pair in output)
            {
                if (pair.Value != 0)
                    return output;
            }
            return new Dictionary<string, int>();
        }

        public List<Baugette> GetBaugetteList()
        {
            return this.baugetteTypes;
        }



        private void FillDictionaries(Dictionary<string, int> requiredMaterials, Dictionary<string, int> output)
        {
            foreach (KeyValuePair<string, int> pair in materials)
            {
                requiredMaterials.Add(pair.Key, 0);
                output.Add(pair.Key, 0);
            }
        }

        private void CountMaterials(Dictionary<string, int> requiredMaterials)
        {
            foreach (KeyValuePair<int, int> pair in order)
            {
                for (int i = 0; i < baugetteTypes[pair.Key].materials.Count(); i++)
                    requiredMaterials[baugetteTypes[pair.Key].materials[i]] += baugetteTypes[pair.Key].count[i] * pair.Value;
            }
        }

        private void SubstractMaterials(Dictionary<string, int> requiredMaterials, Dictionary<string, int> output)
        {
            foreach (KeyValuePair<string, int> pair in requiredMaterials)
            {
                if (materials[pair.Key] < pair.Value)
                    output[pair.Key] = pair.Value - materials[pair.Key];
            }
        }
    }
}