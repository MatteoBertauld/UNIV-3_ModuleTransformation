using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTransformation
{
    public class Formatage
    {
        public List<List<KeyValuePair<string, object>>> Produits_formate { get; set; }

        public Formatage(List<List<KeyValuePair<string, object>>> Produits) 
        {
            Produits_formate = new List<List<KeyValuePair<string, object>>>();
            ApplyFormatage(Produits);
        }


        public void ApplyFormatage(List<List<KeyValuePair<string, object>>> Produits)
        {
            
            foreach (List<KeyValuePair<string, object>> produit in Produits)
            {
                List<KeyValuePair<string, object>> one_produit_formate = new List<KeyValuePair<string, object>>();

                foreach (KeyValuePair<string, object> detail in produit)
                {
                    string formated_key = Formatage_name(detail.Key);

                    one_produit_formate.Add(new KeyValuePair<string, object>(formated_key, detail.Value));
                }

                Produits_formate.Add(one_produit_formate);
            }
        }

        public string Formatage_name(string name) 
        {
           
            if (string.IsNullOrWhiteSpace(name)) 
            { 
                throw new ArgumentNullException("name");
            }

            // 1. Normalisation : sépare les caractères de base des accents
            string formeD = name.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in formeD)
            {
                // 2. On vérifie si c'est un accent (NonSpacingMark)
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    // 3. On ne garde que les lettres et chiffres, sinon on met un tiret
                    if (char.IsLetterOrDigit(c))
                    {
                        sb.Append(char.ToLower(c)); // tout en minuscule
                    }
                    else if (c == ' ' || c == '-' || c == '_')
                    {
                        sb.Append('_'); // Remplace par _
                    }
                }
            }

            return sb.ToString().Trim('_');
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
            if (Produits_formate == null)
            {
                throw new ArgumentException("Produits est null.");
            }

            string chaine = "";

            foreach (var produit in Produits_formate)
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
