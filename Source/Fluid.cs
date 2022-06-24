using System;


namespace Radman
{
    public class Fluid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal MolecularWeight { get; set; }
        public decimal K { get; set; }

        public decimal SpecificGravity { get; set; }
        public decimal Viscosity { get; set; }
        public decimal Comperessibility { get; set; }

        public Fluid()
        {
            Id = -1;
            Name = "";
            Type = 0;
            MolecularWeight = 0;
            K = 0;
            Comperessibility = 0;
            SpecificGravity = 0;
            Viscosity = 0;
        }

        public Fluid(int ID_, string Name_, int Type_, decimal MolecularWeight_, decimal K_, decimal Comperessibility_)
        {
            Id = ID_;
            Name = Name_;
            Type = Type_;
            MolecularWeight = MolecularWeight_;
            K = K_;
            Comperessibility = Comperessibility_;
        }

        public Fluid(int ID_, string Name_, int Type_, decimal SpecificGravity_, decimal Viscosity_)
        {
            Id = ID_;
            Name = Name_;
            Type = Type_;
            SpecificGravity = SpecificGravity_;
            Viscosity = Viscosity_;           
        }
    }
}
