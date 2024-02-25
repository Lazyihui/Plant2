using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PlantManifest : MonoBehaviour {

    [SerializeField] Panel_PlantManifestElement elePrefab;

    [SerializeField] Transform plantManifestGroup;


    public int cellCount;

    List<Panel_PlantManifestElement> elements;

    public void Ctor() {
    }

    public void Init() {

        // cellCount = 10;

        // for (int i = 0; i < cellCount; i++) {

        //     Panel_PlantManifestElement ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

        //     ele.gameObject.SetActive(true);

        // }
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void AddElement(int typeID, Sprite sprite, string plantName, string plantPrice) {

        Debug.Log("AddElement");

        Panel_PlantManifestElement ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

        ele.Init(typeID, sprite, plantName, plantPrice);

    }

}