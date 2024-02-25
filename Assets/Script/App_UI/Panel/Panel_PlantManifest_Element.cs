using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Panel_PlantManifestElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Button plantButton;

    [SerializeField] Text plantName;

    [SerializeField] Text plantPrice;

    public Action OnStartClickHandle;

    public int typeID;




    public void Ctor() {

        // startButton.onClick.AddListener(OnStartButtonClicked);
        //匿名函数
        plantButton.onClick.AddListener(() => {
            //表示函数指针
            OnStartClickHandle.Invoke();

        });
    }
    public void Init(int typeID, Sprite sprite, string plantName, string plantPrice) {
        elePrefab.sprite = sprite;
        this.plantName.text = plantName;
        this.plantPrice.text = plantPrice;

    }

}