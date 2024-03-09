using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_PlantManifest : MonoBehaviour {

    [SerializeField] Panel_PlantManifestElement elePrefab;

    [SerializeField] Transform plantManifestGroup;

    public int elementCount = 0;

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

    public void AddElement(int typeID, Sprite sprite, string plantName, string plantPrice, UIcontext ctx, int plantClickID) {

        Panel_PlantManifestElement ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

        ele.Ctor();
        ele.OnPlantClickHandle = (plantClickID) => {
            ctx.events.PlantManifestElement_Plant(plantClickID);
        };
        ele.Init(typeID, sprite, plantName, plantPrice);

    }

    public void AddElement_NoClick(int typeID, Sprite sprite, string plantName, string plantPrice) {

        Panel_PlantManifestElement ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

        ele.Init(typeID, sprite, plantName, plantPrice);

    }
}