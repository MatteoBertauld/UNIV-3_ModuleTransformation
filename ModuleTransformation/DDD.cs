using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTransformation
{
    public class DDD
    {
        public List<IArticleExterneInterface> Articles;

        public DDD(List<IArticleExterneInterface> articles)
        {
            this.Articles = articles;
        }

        public void Afficher_produits()
        {
            foreach (Article art in Articles)
            {
                Console.WriteLine(art);
            }
        }


        public override bool Equals(object? obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Articles);
        }
    }
}
