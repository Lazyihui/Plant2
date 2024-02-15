using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    //拖拽绑定
    // [SerializeField] Canvas canvas;

    MainContext mainContext;
    Canvas canvas;

    AssetsContext assetsContext;


    void Start() {
        mainContext = new MainContext();
        AssetsContext assetsContext = GameObject.Find("AssetsContext").GetComponent<AssetsContext>();
        mainContext.Inject(assetsContext);

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

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
