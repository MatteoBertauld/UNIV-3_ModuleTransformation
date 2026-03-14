using ModuleTransformation;
using System.Text.Json.Nodes;

namespace Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = """
            {
              "super_colle": {"nom": "Super colle", "volume ml": 20, "temps sechage_sec": 30, "résistant_eau": true, "prix": 4.99},
              "couteau_precision": {"nom": "Couteau de précision", "longueur_lame_cm": 2.5, "lame_remplacable": true, "materiau": "Acier inoxydable", "prix": 9.49},
              "tablette_humide": {"nom": "Tablette humide", "taille": "Standard", "feuilles_supplémentaires": 20, "material": "plastique", "prix": 40.00}
            }
            """;

            ABC abc = new ABC(data);
            string rapport = abc.GenerateRapport();

            Extraction extraction = new Extraction(rapport);

            Formatage formatage = new Formatage(extraction.Produits);

            Verification veritication = new Verification(formatage.Produits_formate);

            Convertion convertion = new Convertion(formatage.Produits_formate);

            DDD ddd = new DDD(convertion.Articles);

            ddd.Afficher_produits();
        }
    }
}
