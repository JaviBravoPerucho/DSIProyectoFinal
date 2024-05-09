using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab2 : MonoBehaviour
{

    VisualElement buttonSets;
    VisualElement buttonEscenarios;
    VisualElement escenarios;
    VisualElement sets;
    Label titulo;
    // Start is called before the first frame update
    private void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();
        VisualElement rootve = document.rootVisualElement;

        List<VisualElement> weapons = rootve.Query(className: "weapons").ToList();
        List<VisualElement> armors = rootve.Query(className: "armor").ToList();
        VisualElement weaponsSelector = rootve.Query("panel_izq");
        VisualElement armorsSelector = rootve.Query("panel_der");
        VisualElement buttonMission = rootve.Query("BotonCrear");
        buttonEscenarios = rootve.Q<Button>("BotonEscenarios");
        buttonSets = rootve.Q<Button>("BotonSets");
        buttonEscenarios.AddToClassList("red");
        buttonSets.AddToClassList("brown");
        buttonMission.AddToClassList("yellow");
        weaponsSelector.AddToClassList("border2");
        armorsSelector.AddToClassList("border2");
        escenarios = rootve.Query("Container");
        sets = rootve.Query("Sets");
        titulo = rootve.Q<Label>("titulo1");

        buttonSets.RegisterCallback<ClickEvent>(ShowSets);
        buttonEscenarios.RegisterCallback<ClickEvent>(ShowEscenarios);


        void ShowEscenarios(ClickEvent evt)
        {
            escenarios.style.opacity = 1;
            sets.style.opacity = 0;
            titulo.text = @"<b><gradient=""Cuatro colores"">ESCENARIOS</gradient></b>";

        }

        void ShowSets(ClickEvent evt)
        {
            escenarios.style.opacity = 0;
            sets.style.opacity = 1;
            titulo.text = @"<b><gradient=""Cuatro colores"">SETS</gradient></b>";
        }
    }

}
