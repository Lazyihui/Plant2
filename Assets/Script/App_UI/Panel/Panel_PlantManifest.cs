using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_PlantManifest : MonoBehaviour {

    [SerializeField] Panel_PlantManifestElement elePrefab;

    [SerializeField] Transform plantManifestGroup;


    public int cellCount;

    List<Panel_PlantManifestElement> elements;

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

    public void AddElement(int typeID, Sprite sprite, string plantName, string plantPrice,Action onPlantClickHandle) {

        Panel_PlantManifestElement ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

        ele.Ctor();
        ele.OnPlantClickHandle = onPlantClickHandle;
        ele.Init(typeID, sprite, plantName, plantPrice);

    }

}