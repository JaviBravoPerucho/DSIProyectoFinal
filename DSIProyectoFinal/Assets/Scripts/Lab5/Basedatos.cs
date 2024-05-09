
using System.Collections.Generic;
using UnityEngine;

namespace Lab5c_namespace
{
    public class Basedatos
    {
        public static List<Individuo> getData()
        {
            List<Individuo> datos= new List<Individuo>();

            Individuo arma = new Individuo(
                "");
            datos.Add(arma);
            return datos;
        }
    }
}

