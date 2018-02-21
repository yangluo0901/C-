using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace PokeInfo
{
    public class Pokemon
    {
        public string Name {get; set;}
        public long Weight {get; set;}
        public long Height {get; set;}
        public JArray Types {get; set;}
    }
}