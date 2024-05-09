using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.VisualElement;

public class Lab4d : VisualElement
{
    // Start is called before the first frame update
    int armadura;
    int ataque;

    VisualElement marcoEspadas = new VisualElement();
    VisualElement marcoEscudos = new VisualElement();

    VisualElement espada1 = new VisualElement();
    VisualElement espada2 = new VisualElement();
    VisualElement espada3 = new VisualElement();


    VisualElement escudo1 = new VisualElement();
    VisualElement escudo2 = new VisualElement();
    VisualElement escudo3 = new VisualElement();

    public int Armadura
    {
        get => armadura;
        set
        {
            armadura = value;
            MostrarStatsArmor();
        }
    }

    public int Ataque
    {
        get => ataque;
        set
        {
            ataque = value;
            MostrarStatsSword();
        }
    }

    void MostrarStatsSword()
    {
        if(Ataque > 0) { espada1.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }
        if (Ataque > 1) { espada2.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }
        if (Ataque > 2) { espada3.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }

    }

    void MostrarStatsArmor()
    {
        if (Armadura > 0) { escudo1.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }
        if (Armadura > 1) { escudo2.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }
        if (Armadura > 2) { escudo3.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1)); }

    }

    public new  class UxmlFactory : UxmlFactory<Lab4d, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myState = new UxmlIntAttributeDescription { name = "state", defaultValue = 0 };
        UxmlIntAttributeDescription myState1 = new UxmlIntAttributeDescription { name = "state1", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var stats = ve as Lab4d;
            stats.Ataque = myState.GetValueFromBag(bag, cc);
            stats.Armadura = myState1.GetValueFromBag(bag, cc);
        }    
    }
    public Lab4d()
    {
        espada1.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("espada"));
        espada2.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("espada"));
        espada3.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("espada"));

        escudo1.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("escudo"));
        escudo2.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("escudo"));
        escudo3.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("escudo"));

        espada1.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));
        espada2.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));
        espada3.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));

        escudo1.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));
        escudo2.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));
        escudo3.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 0.4f));

        marcoEspadas.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("madera"));
        marcoEscudos.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("madera"));

        marcoEspadas.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1.0f));
        marcoEscudos.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 1.0f));

        marcoEscudos.style.borderBottomLeftRadius = 70;
        marcoEscudos.style.borderBottomRightRadius = 70;

        marcoEspadas.style.borderBottomRightRadius = 70;
        marcoEspadas.style.borderBottomLeftRadius = 70;

        espada1.style.width = 100;
        espada1.style.height = 100;
        espada2.style.width = 100;
        espada2.style.height = 100;
        espada3.style.width = 100;
        espada3.style.height = 100;
        escudo1.style.width = 100;
        escudo1.style.height = 100;
        escudo2.style.width = 100;
        escudo2.style.height = 100;
        escudo3.style.width = 100;
        escudo3.style.height = 100;

        marcoEspadas.style.width = 400;
        marcoEspadas.style.height = 100;
        marcoEscudos.style.width = 400;
        marcoEscudos.style.height = 100;
        
       

        escudo1.transform.position = escudo1.transform.position + new Vector3(100, 0, 0);
        escudo2.transform.position = escudo2.transform.position + new Vector3(125, 0, 0);
        escudo3.transform.position = escudo3.transform.position + new Vector3(150, 0, 0);

        espada1.transform.position = espada1.transform.position + new Vector3(-275, -20, 0);
        espada2.transform.position = espada2.transform.position + new Vector3(-250, -20, 0);
        espada3.transform.position = espada3.transform.position + new Vector3(-225, -20, 0);

        marcoEscudos.transform.position = marcoEscudos.transform.position + new Vector3(770, -10, 0);
        marcoEspadas.transform.position = marcoEspadas.transform.position + new Vector3(490, -10, 0);

        hierarchy.Add(marcoEspadas);
        hierarchy.Add(marcoEscudos);
        hierarchy.Add(espada1);
        hierarchy.Add(espada2);
        hierarchy.Add(espada3);
        hierarchy.Add(escudo1);
        hierarchy.Add(escudo2);
        hierarchy.Add(escudo3);
    }
}

