using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Panel_Sun : MonoBehaviour {

    [SerializeField] Text sunNumberText;

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

    public void SetSunNumber(int sunSum) {
        sunNumberText.text = sunSum.ToString();
    }


}
