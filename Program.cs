using System;
using System.Collections.Generic;
using System.Linq;

namespace Range_Exercise      //EJERCICIO CLASE RANGE CODING DOJO - REALIZADO POR ALEXIS NOVAS (1086316)
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRUEBAS (Comentar o Descomentar según se quiera probar cada método)

            #region Constructor
               Range r = new Range("[2,4]"); //(4, 8) caso invalido        
               Range s = new Range("[2,3]");
            #endregion

            #region Contains
               Console.WriteLine(r.Contains(8)); //true
            #endregion

            #region DoesNotContains
                 Console.WriteLine(r.DoesNotContains(10)); //false
            #endregion

            #region AllPoints

            foreach (int number in r.AllPoints())
            {
                Console.WriteLine(number);
            };

            #endregion

            #region ContainsRange
                Console.WriteLine(r.ContainsRange(s)); //false

            #endregion

            #region DoesNotConstainsRange
               Console.WriteLine(r.DoesNotContainsRange(s)); //true
            #endregion

            #region OverlapsRange
               Console.WriteLine(r.OverlapsRange(s)); //true
            #endregion

            #region EndPoints
              int[] arrEndPoints = r.Endpoints();
              if (r.leftNumber < r.rightNumber)
                 Console.WriteLine("The end points are {0},{1}", arrEndPoints[0], arrEndPoints[1]);
             else
                Console.WriteLine("Intervalo inválido.");


            #endregion

            #region Equals
            Console.WriteLine(r.Equals(s));
            #endregion

         #region NotEquals
            Console.WriteLine(r.NotEquals(s));
         #endregion

            Console.ReadKey();
        }

    }

} 
