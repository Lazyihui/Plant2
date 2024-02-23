using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PlantManifestElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Transform plantManifestGroup;
    
    public int cellCount;

    public void Ctor() {
    }
    public void Init() {

        cellCount = 10;

        for (int i = 0; i < cellCount; i++) {

            Image ele = GameObject.Instantiate(elePrefab, plantManifestGroup);

            ele.gameObject.SetActive(true);

        }
    }

}