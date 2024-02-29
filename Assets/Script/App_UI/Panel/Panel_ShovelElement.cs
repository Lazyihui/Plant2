using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_ShovelElement : MonoBehaviour {

    [SerializeField] Button btn;

    [SerializeField] Text shovelName;

    public Action OnPlantClickHandle;


    public void Ctor() {
        btn.onClick.AddListener(() => {
            OnPlantClickHandle.Invoke();
        });
    }

    public void Init() {

        this.shovelName.text = "铲子";


    }



}