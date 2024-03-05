using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Panel_SelectElement : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Button selectButton;

    public Action OnSelectClickHandle;

    public void Ctor() {
        selectButton.onClick.AddListener(() => {
            OnSelectClickHandle.Invoke();
        });
    }

    public void Init(Sprite sprite) {
        elePrefab.sprite = sprite;
    }




}