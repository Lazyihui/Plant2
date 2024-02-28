using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Panel_Sun : MonoBehaviour {

    [SerializeField] Panel_SunElement element;

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

    public void AddSunElement(int sunSum) {

        Panel_SunElement ele = GameObject.Instantiate(element, Group);

        ele.Ctor();
        ele.Init("太阳", sunSum);
    }


}
