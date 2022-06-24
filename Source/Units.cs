
namespace Radman
{
    public class Units
    {
        public string Name { get; set; }
        public string Base { get; set; }
        public decimal K { get; set; }        

        public Units(string _Name,string _Base,decimal _K)
        {
            Name = _Name;
            Base = _Base;
            K = _K;             
        }
    }
}
