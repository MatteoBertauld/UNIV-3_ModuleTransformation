using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModuleTransformation
{
    public class Extraction
    {
        public List<List<KeyValuePair<string, object>>> Produits { get; set; }

        // Constructor
        public Extraction()
        {
            Produits = new List<List<KeyValuePair<string, object>>>();
        }

        

        public bool extraire_rapport(string rapport)
        {

            using (JsonDocument doc = JsonDocument.Parse(rapport))
            {
                JsonElement root = doc.RootElement;

                Console.WriteLine("Extraction des produits");
                // On parcourt chaque propriété de l'objet racine
                foreach (JsonProperty produit in root.EnumerateObject())
                {
                    Console.WriteLine(produit.Name);
                    List<KeyValuePair<string, object>> ObjectExtract = new List<KeyValuePair<string, object>>();

                    JsonElement detail_produit = produit.Value;
                    var dictionnaire = JsonSerializer.Deserialize<Dictionary<string, object>>(detail_produit);


                    foreach (KeyValuePair<string, object> detail in dictionnaire)
                    {
                        string extracted_key = detail.Key;
                        object extracted_value = detail.Value;

                        ObjectExtract.Add(new KeyValuePair<string, object>(extracted_key, extracted_value));
                    }


                    if (ObjectExtract.Count()  == 0 )
                    {
                        throw new ArgumentException("ObjectExtract est null.");
                        return false;
                    }

                    Produits.Add(ObjectExtract);
                }
            }
            return true;
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
            if (Produits == null)
            {
                throw new ArgumentException("Produits est null.");
            }

            string chaine = "";
            
            foreach (var produit in Produits)
            {
                foreach (var detail in produit)
                {
                    chaine += detail.ToString();
                }
            }
            return chaine;
        }
    }
}
