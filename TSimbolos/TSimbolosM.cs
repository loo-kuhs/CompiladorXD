using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSimbolos
{
    public class TSimbolosM
    {
        public List<ConstructorTSimbolos> tSimbolos = new List<ConstructorTSimbolos>();
        public List<Compl> datos = new List<Compl>();
        public TSimbolosM() { }
        public List<ConstructorTSimbolos> TSimbolos { get => tSimbolos; set => tSimbolos = value; }

        public void Tokens()
        {
            ConstructorTSimbolos tokn0 = new ConstructorTSimbolos(0, "<<", "Comentario", " Inicio de una linea de comentario ");
            tSimbolos.Add(tokn0);
            ConstructorTSimbolos tokn1 = new ConstructorTSimbolos(1, ">>", "Comentario", " Fin de una linea de comentario ");
            tSimbolos.Add(tokn1);
            ConstructorTSimbolos tokn2 = new ConstructorTSimbolos(2, "<¿", "Comentario", " Inicio de mas de una linea de comentario ");
            tSimbolos.Add(tokn2);
            ConstructorTSimbolos tokn3 = new ConstructorTSimbolos(3, "<?", "Comentario", " Fin de mas de una linea de comentario ");
            tSimbolos.Add(tokn3);
            ConstructorTSimbolos tokn4 = new ConstructorTSimbolos(4, "{", "Bloque", " Inicio de un bloque ");
            tSimbolos.Add(tokn4);
            ConstructorTSimbolos tokn5 = new ConstructorTSimbolos(5, "}", "Bloque", " Fin de un bloque ");
            tSimbolos.Add(tokn5);
            ConstructorTSimbolos tokn6 = new ConstructorTSimbolos(6, ">int", "Palabra reservada", " Numero entero ");
            tSimbolos.Add(tokn6);
            ConstructorTSimbolos tokn7 = new ConstructorTSimbolos(7, ">double", "Palabra reservada", " Numero con decimales ");
            tSimbolos.Add(tokn7);
            ConstructorTSimbolos tokn8 = new ConstructorTSimbolos(8, ">string", "Palabra reservada", " Cadena de caracteres ");
            tSimbolos.Add(tokn8);
            ConstructorTSimbolos tokn9 = new ConstructorTSimbolos(9, ">bool", "Palabra reservada", " Booleano tru or false ");
            tSimbolos.Add(tokn9);
            ConstructorTSimbolos tokn10 = new ConstructorTSimbolos(10, "-", "Operador", " Representa una resta ");
            tSimbolos.Add(tokn10);
            ConstructorTSimbolos tokn11 = new ConstructorTSimbolos(11, "+", "Operador", " Representa una suma ");
            tSimbolos.Add(tokn11);
            ConstructorTSimbolos tokn12 = new ConstructorTSimbolos(12, "*", "Operador", " Representa una multiplicacion ");
            tSimbolos.Add(tokn12);
            ConstructorTSimbolos tokn13 = new ConstructorTSimbolos(13, "/", "Operador", " Representa una division ");
            tSimbolos.Add(tokn13);
            ConstructorTSimbolos tokn14 = new ConstructorTSimbolos(14, ":", "Operador", " Simbolo de asignacion ");
            tSimbolos.Add(tokn14);
            ConstructorTSimbolos tokn15 = new ConstructorTSimbolos(15, ">", "Operador", " Mayor que ");
            tSimbolos.Add(tokn15);
            ConstructorTSimbolos tokn16 = new ConstructorTSimbolos(16, "<", "Operador", " Menor que ");
            tSimbolos.Add(tokn16);
            ConstructorTSimbolos tokn17 = new ConstructorTSimbolos(17, ">:", "Operador", " Mayor o igual que ");
            tSimbolos.Add(tokn17);
            ConstructorTSimbolos tokn18 = new ConstructorTSimbolos(18, "<:", "Operador", " Menor o igual que ");
            tSimbolos.Add(tokn18);
            ConstructorTSimbolos tokn19 = new ConstructorTSimbolos(19, "&&", "Operador logico", " Condicion esto y esto ");
            tSimbolos.Add(tokn19);
            ConstructorTSimbolos tokn20 = new ConstructorTSimbolos(20, "||", "Operador logico", " Condicion esto o esto ");
            tSimbolos.Add(tokn20);
            ConstructorTSimbolos tokn21 = new ConstructorTSimbolos(21, "::", "Operador logico", " Condicion esto es igual a esto ");
            tSimbolos.Add(tokn21);
            ConstructorTSimbolos tokn22 = new ConstructorTSimbolos(22, "!:", "Operador logico", " Condicion diferente a ");
            tSimbolos.Add(tokn22);
            ConstructorTSimbolos tokn23 = new ConstructorTSimbolos(23, "!", "Operador logico", " Condicion de negacion ");
            tSimbolos.Add(tokn23);
            ConstructorTSimbolos tokn24 = new ConstructorTSimbolos(24, ">print", "Palabra reservada", " Muestra en consola ");
            tSimbolos.Add(tokn24);
            ConstructorTSimbolos tokn25 = new ConstructorTSimbolos(25, ">read", "Palabra reservada", " captura un valor desde consola ");
            tSimbolos.Add(tokn25);
            ConstructorTSimbolos tokn26 = new ConstructorTSimbolos(26, ">func", "Palabra reservada", " Define una funcion ");
            tSimbolos.Add(tokn26);
            ConstructorTSimbolos tokn27 = new ConstructorTSimbolos(27, ">class", "Palabra reservada", " define una clase ");
            tSimbolos.Add(tokn27);
            ConstructorTSimbolos tokn28 = new ConstructorTSimbolos(28, ">si", "Palabra reservada", " si tal condicion se cumple ");
            tSimbolos.Add(tokn28);
            ConstructorTSimbolos tokn29 = new ConstructorTSimbolos(29, ">sino", "Palabra reservada", " si tal condicion no se cumple ");
            tSimbolos.Add(tokn29);
            ConstructorTSimbolos tokn30 = new ConstructorTSimbolos(30, "(", "Parametro", " Inicia peticion de parametro ");
            tSimbolos.Add(tokn30);
            ConstructorTSimbolos tokn31 = new ConstructorTSimbolos(31, ")", "Parametro", " Finaliza peticion de parametro ");
            tSimbolos.Add(tokn31);
            ConstructorTSimbolos tokn32 = new ConstructorTSimbolos(32, "~", "Concatenacion", " Permite concatenar variables ");
            tSimbolos.Add(tokn32);
            ConstructorTSimbolos tokn33 = new ConstructorTSimbolos(33, "'", "Indicador de texto", " Indica donde comienza y termina un string ");
            tSimbolos.Add(tokn33);

        }

        public List<ConstructorTSimbolos> ObtenerTokens()
        {
            return tSimbolos;
        }

        public List<Compl> BuscarToken(string argumento, int linea, string regla)
        {
            foreach (var word in tSimbolos)
            {
                if (word.Token1 == argumento)
                {
                    if (Verificar((linea + 1).ToString()) == true)
                    {
                        return datos;
                    }
                    else
                    {
                        datos.Add(new Compl(word.Token1, word.Tipo1, 
                            (linea + 1).ToString(), 
                            word.IDtoken1.ToString(), regla, 
                            word.DescTipo1));

                        return datos;
                    }
                }
            }
            return null;
        }

        private bool Verificar(string linea)
        {
            foreach (var x in datos)
            {
                if (x.Linea == linea)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
