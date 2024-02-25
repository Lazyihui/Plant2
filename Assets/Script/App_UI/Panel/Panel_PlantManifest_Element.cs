using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Panel_PlantManifestElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Button button;

    [SerializeField] Text plantName;

    [SerializeField] Text plantPrice;

    public Action OnStartClickHandle;



    public void Ctor() {
    }
    public void Init() {

    }

}