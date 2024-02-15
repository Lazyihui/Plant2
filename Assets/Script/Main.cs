using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    //拖拽绑定
    // [SerializeField] Canvas canvas;

    MainContext mainContext;

    AssetsContext assetsContext;


    void Start() {
        mainContext = new MainContext();
        AssetsContext assetsContext = GameObject.Find("AssetsContext").GetComponent<AssetsContext>();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        mainContext.Inject(canvas, assetsContext);


        // canvans = GameObject.GetComponenetChirld<Canvas>();
        //实例化 GameObject.Instantiate
        UIApp.Panel_Login_Open(mainContext.uiContext, () => {
            UIApp.Panel_Login_Close(mainContext.uiContext);
            GameBusiness.Enter(mainContext.gamaContext);


            Debug.Log("Panel_Login_Open");
        });


      




    }

    void Update() {

    }
}
