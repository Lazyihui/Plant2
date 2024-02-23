using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PlantManifest : MonoBehaviour {

    public int cellCount;


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

}