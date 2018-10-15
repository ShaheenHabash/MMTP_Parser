using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.Custom
{
    public class AseJotv_Sympols
    {
        public AseJotv_Sympols()
        {
            Ase_Price = -1;
            Ase_Var = -1;
            Ase_Var = -1;
            Ase_Sign = -1;
            Ase_Market = 0;
        }
        public int Ase_Id { get; set; }
        public int Ase_Smpl_Id { get; set; }
        public string Ase_Smpl_Sym { get; set; }
        public string Ase_Smpl_Name_A { get; set; }
        public string Ase_Smpl_Name_E { get; set; }
        public double Ase_Price { get; set; }
        public double Ase_Var { get; set; }
        public int Ase_Sign { get; set; }
        public int? Ase_Market { get; set; }
    }
}
