using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModuleTransformation
{
    public class Article : IArticleExterneInterface
    {

        public string Name{ get; set; }

        public double Price { get; set; }

        public List<KeyValuePair<string, object>> Attributs { get; set; }

        public Article(string name, double price, List<KeyValuePair<string, object>> attributs)
        {
            this.Name = name;
            this.Price = price;
            this.Attributs = attributs;
        }

       

        public override bool Equals(object? obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Attributs);
        }

        public override string? ToString()
        {
            string chaine = $"---- {Name} -----\nPrix : {Price}\n";
            foreach (KeyValuePair<string, object> attribut in Attributs)
            {
                chaine += $"{attribut.Key} : {attribut.Value.ToString()}\n";
            }
            return chaine;
        }
    }
}
