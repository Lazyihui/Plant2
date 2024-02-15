using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    //拖拽绑定
    // [SerializeField] Canvas canvas;
    Canvas canvas;

    AssetsContext assetsContext;


    void Start() {

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        assetsContext = GameObject.Find("AssetsContext").GetComponent<AssetsContext>();

        // canvans = GameObject.GetComponenetChirld<Canvas>();
        //实例化 GameObject.Instantiate
        Panel_Login panel_Login = GameObject.Instantiate(assetsContext.panel_Login, canvas.transform);

        panel_Login.Ctor();
        panel_Login.Show();
        panel_Login.OnStartClickHandle += () => {
            panel_Login.Close();
            LoginBusiness.Enter();
            GameBusiness.Enter();
        };




    }

    void Update() {

    }
}
