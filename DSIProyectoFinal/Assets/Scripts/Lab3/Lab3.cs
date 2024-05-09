using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Lab5c_namespace;
using Lab6_namespace;


public class Lab3 : MonoBehaviour
{
    [SerializeField] Lab5 lab5;
    [SerializeField] Lab6 lab6;
    int contArmor = 0, contWeapons = 0;
    bool palestinaLibre = false;
    bool americaComunista = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> weapons = root.Query(className: "weapons").ToList();
        List<VisualElement> armors = root.Query(className: "armor").ToList();
        VisualElement equip1 = root.Q<Button>("Button1");
        VisualElement equip2 = root.Q<Button>("Button2");

        
        foreach (var item in armors)
        {
            item.RegisterCallback<MouseDownEvent>(ev =>
            {
                if (contArmor < 1 && !item.ClassListContains("border"))
                {
                    item.AddToClassList("border");
                    contArmor++;
                }
                else if (!americaComunista)
                {
                    foreach (var item2 in armors)
                    {
                        item2.RemoveFromClassList("border");
                    }
                    item.AddToClassList("border");
                }
            });
            item.RegisterCallback<MouseEnterEvent>(ev =>
            {
                item.transform.scale = Vector3.one*1.5f;
            });
            item.RegisterCallback<MouseOutEvent>(ev =>
            {
                item.transform.scale = Vector3.one;
            });
        }
        foreach (var item in weapons)
        {
            item.RegisterCallback<MouseDownEvent>(ev =>
            {
                if (contWeapons < 1 && !item.ClassListContains("border"))
                {
                    item.AddToClassList("border");
                    contWeapons++;
                }
                else if(!palestinaLibre)
                {
                    foreach (var item2 in weapons)
                    {
                        item2.RemoveFromClassList("border");
                    }
                    item.AddToClassList("border");
                }
            });
            item.RegisterCallback<MouseEnterEvent>(ev =>
            {
                item.transform.scale = Vector3.one * 1.5f;
            });
            item.RegisterCallback<MouseOutEvent>(ev =>
            {
                item.transform.scale = Vector3.one;
            });
        }

        equip1.RegisterCallback<ClickEvent>(ev =>
        {
            if (contWeapons == 1)
            {
                List<VisualElement> bordered = root.Query(className: "border").ToList();
                foreach (var item in bordered)
                {
                    if (item.ClassListContains("weapons"))
                    {
                        item.RemoveFromClassList("border");
                        item.AddToClassList("borderBlanco");
                        lab5.setImageArma(item.name);
                        lab6.weaponsEquipped(item.name);
                        palestinaLibre = true;
                    }
                    
                }

            }
        });

        equip2.RegisterCallback<ClickEvent>(ev =>
        {
            if (contArmor == 1)
            {
                List<VisualElement> bordered = root.Query(className: "border").ToList();
                foreach (var item in bordered)
                {
                    if (item.ClassListContains("armor"))
                    {
                        item.RemoveFromClassList("border");
                        item.AddToClassList("borderBlanco");
                        lab5.setImageArmadura(item.name);
                        lab6.armorEquipped(item.name);
                        americaComunista = true;
                    }
                }
            }
        });
    }

    public void resetCounters()
    {
        contArmor = 0;
        contWeapons = 0;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> bordered = root.Query(className: "borderBlanco").ToList();
        foreach (var item in bordered)
        {

              item.RemoveFromClassList("borderBlanco");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
