using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_SelectElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Button selectButton;

    public int typeID;

    public Action<int> OnSelectClickHandle;

    public void Ctor() {
        selectButton.onClick.AddListener(() => {
            OnSelectClickHandle.Invoke(this.typeID);
        });
    }

    public void Init(Sprite sprite, int typeID) {
        elePrefab.sprite = sprite;
        this.typeID = typeID;

    }




}