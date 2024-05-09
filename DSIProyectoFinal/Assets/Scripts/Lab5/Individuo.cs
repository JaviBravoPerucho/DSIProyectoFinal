using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lab5c_namespace
{
    public class Individuo
    {
        public event Action Cambio;

        public string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if(value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }

        //private string apellido;
        //public string Apellido
        //{
        //    get { return apellido; }
        //    set
        //    {
        //        if(value != apellido)
        //        {
        //            apellido = value;
        //            Cambio?.Invoke();
        //        }
        //    }
        //}

        public Individuo(string nombre)
        {
            this.nombre = nombre;
        }
    }
}

