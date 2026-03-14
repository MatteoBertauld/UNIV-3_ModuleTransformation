using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModuleTransformation
{
    public class Convertion
    {

        public List<IArticleExterneInterface> Articles { get; set; }

        public Convertion(List<List<KeyValuePair<string, object>>> Produits)
        {
            Articles = new List<IArticleExterneInterface>();
            Convertion_produit_article(Produits);
        }

        public void Convertion_produit_article(List<List<KeyValuePair<string, object>>> Produits)
        {

            foreach (List<KeyValuePair<string, object>> produit in Produits)
            {
                string name = "";
                double price = 0;
                List<KeyValuePair<string, object>> attributs = new List<KeyValuePair<string, object>>();

                foreach (KeyValuePair<string, object> detail in produit)
                {

                    switch (detail.Key)
                    {
                        case "nom":

                            if (detail.Value is not JsonElement stringElement)
                            {
                                throw new ArgumentException($"Internal Error : le type n'est pas un JsonElement. Reçu : {detail.Value?.GetType().Name ?? "null"}, Valeur : {detail.Value}");
                            }

                            name = stringElement.ToString();
                            break;

                        case "prix":
                        
                            if (detail.Value is not JsonElement doubleElement)
                            {
                                throw new ArgumentException($"Internal Error : le type n'est pas un JsonElement. Reçu : {detail.Value?.GetType().Name ?? "null"}, Valeur : {detail.Value}");
                            }

                            price = doubleElement.GetDouble();
                            break;

                        default:
                            attributs.Add(new KeyValuePair<string, object>(detail.Key, detail.Value));
                            break;

                    }
                }
                Article article = new Article(name, price, attributs);
                Articles.Add(article);
            }
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
