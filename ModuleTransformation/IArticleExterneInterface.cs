using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTransformation
{
    public interface IArticleExterneInterface
    {
        string Name { get; set; }
        double Price { get; set; }

        public List<KeyValuePair<string, object>> Attributs { get; set; }
    }
}
