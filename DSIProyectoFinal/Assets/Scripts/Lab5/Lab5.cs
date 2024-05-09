using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

namespace Lab5c_namespace
{
    public class Lab5 : MonoBehaviour
    {
        List<Individuo> individuos;

        Individuo selectIndividuo;

        VisualElement plantilla;

        VisualElement tarjeta1;

        TextField input_nombre;
        TextField input_apellido;

        Individuo individuoPrueba;
        VisualElement ImagenArma;
        VisualElement ImagenArmadura;
        VisualElement root;

        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            plantilla = root.Q("plantilla");

            individuoPrueba = new Individuo("");

            Tarjeta tarjetaPrueba = new Tarjeta(plantilla, individuoPrueba);
            ImagenArma = root.Q("armaIcono");
            ImagenArmadura = root.Q("armaduraIcono");
            Debug.Log(ImagenArma);
            
            tarjeta1 = root.Q("plantilla");

            input_nombre = root.Q<TextField>("InputNombre");

            //plantilla.RegisterCallback<ClickEvent>(SeleccionIndividuo);

            //individuos = Basedatos.getData();

            //VisualElement footer = root.Q("plantilla");
            //footer.RegisterCallback<ClickEvent>(seleccionTarjeta);

            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);

            //input_nombre.SetValueWithoutNotify(individuoPrueba.Nombre);
            //input_apellido.SetValueWithoutNotify(individuoPrueba.Apellido);

            InitializeUI();
        }

        //void SeleccionIndividuo(ClickEvent evt)
        //{
        //    string nombre = plantilla.Q<Label>("Nombre").text;
        //    string apellido = plantilla.Q<Label>("Apellido").text;

        //    Debug.Log(nombre);

        //    input_nombre.SetValueWithoutNotify(nombre);
        //    input_apellido.SetValueWithoutNotify(apellido);

        //}

        void CambioNombre(ChangeEvent<string> evt)
        {
           // selectIndividuo.Nombre = evt.newValue;

            individuoPrueba.Nombre = evt.newValue;
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta =e.target as VisualElement;

            //selectIndividuo = tarjeta.userData as Individuo;
          //  Debug.Log(selectIndividuo);
            //input_nombre.SetValueWithoutNotify(selectIndividuo.Nombre);
            //input_apellido.SetValueWithoutNotify(selectIndividuo.Apellido);
        }
        void InitializeUI()
        {
           // Tarjeta tar1 = new Tarjeta(tarjeta1, individuos[0]);
            //Debug.Log(individuos[0]);
        }

        public void setImageArma(string img)
        {
            ImagenArma.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(img));
            ImagenArma.visible = true; 
        }

        public void setImageArmadura(string img)
        {
            ImagenArmadura.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(img));
            ImagenArmadura.visible = true;
        }
    }
}

