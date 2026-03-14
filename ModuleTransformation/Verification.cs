using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ModuleTransformation
{
    public class Verification
    {

        public Verification(List<List<KeyValuePair<string, object>>> Produits)
        {
            Check_all(Produits);
        }

        public void Check_all(List<List<KeyValuePair<string, object>>> Produits)
        {
            foreach (List<KeyValuePair<string, object>> produit in Produits)
            {

                Check_name_prices(produit);

                foreach (KeyValuePair<string, object> detail in produit)
                {
                    Check_value_not_null(detail);
                }

            }
        }

        public void Check_name_prices(List<KeyValuePair<string, object>> produit)
        {
            bool keyNameExist = false;
            bool keyPriceExist = false;

            foreach (KeyValuePair<string, object> detail in produit)
            {
                if (detail.Key == "nom") { keyNameExist = true; }
                if (detail.Key == "prix") 
                { 
                    keyPriceExist = true;
                    Check_prices_positif(detail);
                }
            }

            if (keyNameExist == false) 
            {
                throw new FormatException("Aucun Nom n'est indiqué pour le produit");
            }

            if (keyPriceExist == false)
            {
                throw new FormatException("Aucun prix n'est indiqué pour le produit");
            }
        }

        public void Check_value_not_null(KeyValuePair<string, object> pair)
        {
            if (pair.Value == null)
            {
                throw new FormatException("Un des produits possède une valeur null");
            }

            if (pair.Key == null)
            {
                throw new FormatException("Un des produits possède une clé null");
            }
        }

        public void Check_prices_positif(KeyValuePair<string, object> pair)
        {
            if(pair.Key != "prix")
            {
                throw new ArgumentException($"Internal Error : l'argument n'est pas un prix : {pair.Key}");
            }

            if (pair.Value is not JsonElement element)
            {
                throw new FormatException($"Internal Error : le type n'est pas un JsonElement. Reçu : {pair.Value?.GetType().Name ?? "null"}, Valeur : {pair.Value}");
            }

            double price = element.GetDouble();

            if (price < 0)
            {
                 throw new FormatException($"Un des produits possède un prix infèrieur à 0 : {pair.Value}");
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
