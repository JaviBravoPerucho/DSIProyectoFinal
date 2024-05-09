using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Lab5c_namespace
{
    public class Tarjeta
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        
        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;
            nombreLabel = tarjetaRoot.Q<Label>("Nombre");

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;

        }

        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
        }
    }
}

