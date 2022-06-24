using System;


namespace Radman
{
    public class Product
    {
       // int Id { get; set; }
     
        string Orifice { get; set; }
        string Series { get; set; }
      

        public Product(string _Orifice, string _Series)
        {
            //Id = _Id;
           
            Orifice = _Orifice;
            Series = _Series;
          
        }
    }
}
