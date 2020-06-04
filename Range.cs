using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Range_Exercise
{
    public class Range
    {
        private string interval;
        private List<int> arr_of_numbers = new List<int>();

        //public bool openedInterval = false;
        //public bool closedInterval = false;
        private enum side { Opened, Closed, Wrong }
        private string[] arrTempInterval = new string[2];
        public int leftNumber = 0;
        public int rightNumber = 0;
        private side rightside;
        private side leftside;

        public Range(string interval)
        {


            this.interval = interval.Trim().Replace(" ", ""); //El replace para quitar los espacios del medio.
            interval = interval.Trim().Replace(" ", "");

            //Validando el lado izquierdo
            if (interval.StartsWith("("))
                leftside = side.Opened;
            else if (interval.StartsWith("["))
                leftside = side.Closed;
            else
            {
                Console.WriteLine("Se ha ingresado un intervalo inválido.");
                rightside = side.Wrong;
                return;
            }


            //Validando el lado derecho
            if (interval.EndsWith(")"))
                rightside = side.Opened; //interval.Remove(interval.LastIndexOf(')'));
            else if (interval.EndsWith("]"))
                rightside = side.Closed;
            else
            {
                Console.WriteLine("Se ha ingresado un intervalo inválido.");
                leftside = side.Wrong;
                return;
            }

            //Confirmar si hay letras
            for (int i = 0; i < interval.Length; i++)
            {
                if (char.IsLetter(interval[i]))
                {
                    Console.WriteLine("Se ha ingresado un intervalo invalido");
                    return;
                    //interval = interval.Replace(interval[i].ToString(), "");
                }

            }



            interval = interval.Remove(0, 1); //Quitamos el simbolo que está delante.
            interval = interval.Remove(interval.Length - 1); //Quitamos el simbolo que está detrás.
                                                             //Console.WriteLine(interval); //Replace no me sirve porque lo quita en donde quiera que esté Ej. (1[,2)

            arrTempInterval = interval.Split(',');

            try
            {
                leftNumber = int.Parse(arrTempInterval[0]);
                rightNumber = int.Parse(arrTempInterval[1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Se ingreso un intervalo invalido");
                return;

            }


            if (leftNumber < rightNumber) // && (rightNumber - leftNumber) != 1  
            {
                int tempLeft = leftNumber;
                int tempRight = rightNumber;

                if (leftside == side.Opened && rightside == side.Opened)
                {

                    for (int i = 0; i < (rightNumber - leftNumber) - 1; i++)
                    {
                        tempLeft = tempLeft + 1;
                        arr_of_numbers.Add(tempLeft);
                    }

                }
                else if (leftside == side.Opened && rightside == side.Closed) //(3, 7]
                {
                    Console.WriteLine("Bazinga");
                    for (int i = 0; i < (rightNumber - leftNumber); i++) //(rightNumber - leftNumber) representa en este caso la distancia que hay entre uno y otro numero, es decir el total de numeros que hay entre ellos.
                    {
                        tempLeft = tempLeft + 1;
                        arr_of_numbers.Add(tempLeft);
                    }

                }
                else if (leftside == side.Closed && rightside == side.Opened) //[-2, 4)   
                {
                    for (int i = 0; i < (rightNumber - leftNumber); i++)
                    {
                        arr_of_numbers.Add(tempLeft);
                        tempLeft = tempLeft + 1;
                    }

                }
                else if (leftside == side.Closed && rightside == side.Closed) // ejemplo: [3, 6]
                {
                    for (int i = 0; i < (rightNumber - leftNumber) + 1; i++)
                    {
                        arr_of_numbers.Add(tempLeft);
                        tempLeft = tempLeft + 1;
                    }

                }

            }
            else
            {
                Console.WriteLine("se ingreso un rango de números invalido.");
            }

        }

        public bool Contains(int someNumber)
        {
            if (arr_of_numbers.Contains(someNumber))
                return true;
            else
                return false;
        }

        public bool DoesNotContains(int someNumber)
        {
            if (!arr_of_numbers.Contains(someNumber)) //Si se niega el resultado, es decir no lo contiene, entonces retorna un true para indicarlo.
                return true;
            else
                return false;
        }

        public List<int> AllPoints() //Devuelve el arreglo que contiene todos los puntos.
        {
            return arr_of_numbers;
        }

        public bool OverlapsRange(Range r) //Para saber si lo intersecta en algun punto
        {
            List<int> tempList = r.AllPoints();
            List<int> result = arr_of_numbers.Intersect(tempList).ToList();

            if (result.Count != 0) // Es decir que hubo intercepciones.
                return true;
            else
                return false;
        }

        public bool ContainsRange(Range r)
        {
            List<int> tempList = r.AllPoints();
            List<int> result = arr_of_numbers.Intersect(tempList).ToList();

            if (result.Count == tempList.Count) //Tienen la misma cantidad de numeros, quiere decir si contiene el Rango.
                return true;
            else
                return false;

        }

        public bool DoesNotContainsRange(Range r)
        {
            List<int> tempList = r.AllPoints();
            List<int> result = arr_of_numbers.Intersect(tempList).ToList();

            if (result.Count != tempList.Count) //es decir que no tiene la misma cantidad de numeros, por lo tanto no contiene el rango completo.
                return true;
            else
                return false;

        }

        public int[] Endpoints()
        {
            int[] endPointsArr = new int[2];

            if (leftside == side.Opened && rightside == side.Opened)
            {
                endPointsArr[0] = leftNumber + 1;
                endPointsArr[1] = rightNumber - 1;
            }
            else if (leftside == side.Opened && rightside == side.Closed) //(3, 7]
            {
                endPointsArr[0] = leftNumber + 1;
                endPointsArr[1] = rightNumber;
            }
            else if (leftside == side.Closed && rightside == side.Opened) //[-2, 4)   
            {
                endPointsArr[0] = leftNumber;
                endPointsArr[1] = rightNumber - 1;
            }
            else if (leftside == side.Closed && rightside == side.Closed) // ejemplo: [3, 6]
            {
                endPointsArr[0] = leftNumber;
                endPointsArr[1] = rightNumber;
            }

            return endPointsArr;
        }

        public bool Equals(Range r)
        {
            if (interval == r.interval)
                return true;
            else
                return false;
        }

        public bool NotEquals(Range r)
        {
            if (interval != r.interval)
                return true;
            else
                return false;
        }

    }
}
