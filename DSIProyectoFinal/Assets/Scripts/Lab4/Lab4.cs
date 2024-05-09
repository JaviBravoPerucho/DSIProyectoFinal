using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4 : MonoBehaviour
{
    Slider dificulty;
    //VisualElement lab;
    // Start is called before the first frame update
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label texto = root.Q<Label>("titulo");
        Label weapons = root.Q<Label>("weapons");
        Label armors = root.Q<Label>("armor");
        Label texto2 = root.Q<Label>("titulo1");
        texto.text = @"<b><gradient=""Cuatro colores"">CREATE YOUR GLADIATOR</gradient></b>";
        texto2.text = @"<b><gradient=""Cuatro colores"">ESCENARIOS</gradient></b>";
        weapons.text = @"<b><gradient=""GrisNegro"">WEAPONS</gradient></b>";
        armors.text = @"<b><gradient=""GrisNegro"">ARMOR</gradient></b>";
        dificulty = root.Q<Slider>("dificulty");
        //lab = root.Q<VisualElement>("Lab4d");



        //VisualTreeAsset template = Resources.Load<VisualTreeAsset>("Container");

       // VisualElement caja = template.Instantiate();
    }

    // Update is called once per frame
    void Update()
    {
       // lab.Ataque = (int)dificulty.value;
        //lab.Armadura = (int)dificulty.value;
    }
}
