using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_SunElement : MonoBehaviour {
    [SerializeField] Text sunSum;

    [SerializeField] Text sunName;


    public void Ctor() {
    }

    public void Init(string sunName, int sunSum) {
        
        this.sunName.text = sunName;
        this.sunSum.text = sunSum.ToString();

    }


}