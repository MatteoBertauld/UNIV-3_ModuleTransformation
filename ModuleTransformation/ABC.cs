namespace ModuleTransformation
{
    public class ABC
    {
        public string rapport { get; set; }

        // Constructor
        public ABC(string data)
        {
            rapport = data;
        }

        // Public method name follows PascalCase
        public string GenerateRapport()
        {
            return rapport;
        }

    }
}
