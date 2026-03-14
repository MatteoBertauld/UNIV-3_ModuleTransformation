namespace ModuleTransformation
{
    public class ABC
    {
        public string rapport { get; set; }

        // Constructor
        public ABC()
        {
            GenerateRapport();
        }

        // Public method name follows PascalCase
        public string GenerateRapport()
        {
            return rapport = """
            {
              "super_colle": {"nom": "Super colle", "volume ml": 20, "temps sechage_sec": 30, "résistant_eau": true, "prix": 4.99},
              "couteau_precision": {"nom": "Couteau de précision", "longueur_lame_cm": 2.5, "lame_remplacable": true, "materiau": "Acier inoxydable", "prix": 9.49},
              "tablette_humide": {"nom": "Tablette humide", "taille": "Standard", "feuilles_supplémentaires": 20, "material": "plastique", "prix": 40.00}
            }
            """;
        }

    }
}
