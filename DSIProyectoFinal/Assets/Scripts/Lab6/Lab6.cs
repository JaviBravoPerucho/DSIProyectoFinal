using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;
using System.Linq;
using Lab5c_namespace;

namespace Lab6_namespace
{
    public class Lab6 : MonoBehaviour
    {
        VisualElement createButton;
        VisualElement guardarButton;
        VisualElement armorElement;
        VisualElement weaponElement;
        Label titulo;

        [SerializeField]
        Lab3 lab3;


        VisualElement container;
        VisualElement container2;
        VisualElement sets;
        bool hayTarjeta = false, equipWeapons = false, equipArmor = false;
        int contSelected = 0;

        TextField input_name;

        Individuo individualSelected;
        Individuo indivFromJson;
        List<Individuo> listaIndividuos = new List<Individuo>();

        string armorImg;
        string weaponImg;

        private void OnEnable()
        {
          
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            container2 = root.Q<VisualElement>("Container");
            sets = root.Q<VisualElement>("Sets");
         

            container = root.Q<VisualElement>("habilities");
            titulo = root.Q<Label>("titulo1");

            input_name = root.Q<TextField>("InputNombre");
            createButton = root.Q<Button>("BotonCrear");
            guardarButton = root.Q<Button>("BotonGuardar");
            //toggleModify = root.Q<Toggle>("ToggleModificar");

            //container.RegisterCallback<ClickEvent>(seleccionTarjeta);
            createButton.RegisterCallback<ClickEvent>(NuevaTarjeta);
            guardarButton.RegisterCallback<ClickEvent>(Guardar);
            input_name.RegisterCallback<ChangeEvent<string>>(CambiaNombre);

            Cargar();
            void NuevaTarjeta(ClickEvent evt)
            {
                if (contSelected < 3 && equipWeapons && equipArmor)
                {
                    contSelected++;
                    VisualTreeAsset template = Resources.Load<VisualTreeAsset>("Tarjeta");
                    VisualElement tempalteTarjeta = template.Instantiate();
                    if (!hayTarjeta)
                    {
                        container2.style.opacity = 0;
                        sets.style.opacity = 1;
                        hayTarjeta = true;
                    }
                    sets.Add(tempalteTarjeta);
                    //black_border_tarjeta();
                    //white_border_tarjeta(tempalteTarjeta);

                    armorElement = root.Q<VisualElement>("Arma");
                    weaponElement = root.Q<VisualElement>("Armadura");

                    armorElement.name = "Arma" + contSelected;
                    weaponElement.name = "Arma" + contSelected;

                    armorElement.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(armorImg));
                    weaponElement.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(weaponImg));

                    if(contSelected < 3)lab3.resetCounters();

                    equipArmor = false;
                    equipWeapons = false;
                    
                    titulo.text = @"<b><gradient=""Cuatro colores"">SETS</gradient></b>";

                    Individuo individuo = new Individuo(input_name.value);

                    Tarjeta tarjeta = new Tarjeta(tempalteTarjeta, individuo);
                    individualSelected = individuo;
                    Debug.Log(listaIndividuos);

                    listaIndividuos.Add(individuo);

                }

            }

            void Guardar(ClickEvent evt)
            {
                string datos = "";

                if (File.Exists("datos.txt")) File.Delete("datos.txt");

                    foreach (Individuo i in listaIndividuos)
                {
                    datos += i.Nombre + "\n";
                    File.WriteAllText("datos.txt", datos);
                }
            }

            void Cargar()
            {
                if (File.Exists("datos.txt"))
                {
                    listaIndividuos.Clear();

                    string[] lines = File.ReadAllLines("datos.txt");

                    foreach(string line in lines)
                    {

                        VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                        VisualElement tempalteTarjeta = plantilla.Instantiate();
                        sets.Add(tempalteTarjeta);


                        Individuo indiv = new Individuo(line);
                        Tarjeta tarjeta = new Tarjeta(tempalteTarjeta, indiv);
                        individualSelected = indiv;
                        listaIndividuos.Add(indiv);
                        Debug.Log("hecho");
                    }
                    container2.style.opacity = 0;
                    sets.style.opacity = 1;
                }
            }

            void seleccionTarjeta(ClickEvent e)
            {
                VisualElement miTarjeta = e.target as VisualElement;
                individualSelected = miTarjeta.userData as Individuo;
                input_name.SetValueWithoutNotify(individualSelected.Nombre);
            }

            void CambiaNombre(ChangeEvent<string> evt)
            {
                 if(individualSelected != null)individualSelected.Nombre = evt.newValue;
            }

            void black_border_tarjeta()
            {
                List<VisualElement> list_tarjetas = container.Children().ToList();
                list_tarjetas.ForEach(elem =>
                {
                    VisualElement tarjeta = elem.Q("Tarjeta");

                    tarjeta.style.borderBottomColor = Color.black;
                    tarjeta.style.borderLeftColor = Color.black;
                    tarjeta.style.borderRightColor = Color.black;
                    tarjeta.style.borderTopColor = Color.black;
                });
            }

            void white_border_tarjeta(VisualElement tar)
            {
                VisualElement tarjeta = tar.Q("Tarjeta");

                tarjeta.style.borderBottomColor = Color.white;
                tarjeta.style.borderLeftColor = Color.white;
                tarjeta.style.borderRightColor = Color.white;
                tarjeta.style.borderTopColor = Color.white;
            }


        }

        public void armorEquipped(string img)
        {
            equipArmor = true;
            weaponImg = img;
        }


        public void weaponsEquipped(string img)
        {
            equipWeapons = true;
            armorImg = img;
        }
    }
}
