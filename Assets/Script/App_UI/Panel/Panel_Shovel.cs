using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_Shovel : MonoBehaviour {
    [SerializeField] Panel_ShovelElement element;
    [SerializeField] Transform Group;


    public void Ctor() {
    }

    public void Init() {
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void AddElement(UIcontext ctx) {

        Panel_ShovelElement ele = GameObject.Instantiate(element, Group);
        
        ele.Ctor();
        
        ele.OnPlantClickHandle = () => {
            ctx.events.ShovelElement_Shovel();
        };

        ele.Init();
    }


}