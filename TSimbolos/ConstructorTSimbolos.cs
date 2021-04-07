using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSimbolos
{
    public class ConstructorTSimbolos
    {
        private int IDtoken;
        private string Token;
        private string Tipo;
        private string DescTipo;

        public ConstructorTSimbolos(int iDtoken, string token, 
            string tipo, string descTipo)
        {
            IDtoken = iDtoken;
            Token = token;
            Tipo = tipo;
            DescTipo = descTipo;
        }

        public int IDtoken1 { get => IDtoken; set => IDtoken = value; }
        public string Token1 { get => Token; set => Token = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string DescTipo1 { get => DescTipo; set => DescTipo = value; }
    }
}
