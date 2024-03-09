using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Panel_PlantManifestElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Button plantButton;

    [SerializeField] Text plantName;

    [SerializeField] Text plantPrice;
    
    public int typeID;

    public Action<int> OnPlantClickHandle;

    public void Ctor() {

        plantButton.onClick.AddListener(() => {
            OnPlantClickHandle.Invoke(this.typeID);
        });
    }
    public void Init(int typeID, Sprite sprite, string plantName, string plantPrice) {
        elePrefab.sprite = sprite;
        this.plantName.text = plantName;
        this.plantPrice.text = plantPrice;
        this.typeID = typeID;
    }

}