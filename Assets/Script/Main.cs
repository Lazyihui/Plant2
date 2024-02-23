using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    //拖拽绑定
    // [SerializeField] Canvas canvas;

    MainContext mainContext;

    AssetsContext assetsContext;


    void Start() {

        Application.targetFrameRate = 120;


        mainContext = new MainContext();

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        mainContext.Inject(canvas);


        // canvans = GameObject.GetComponenetChirld<Canvas>();
        //实例化 GameObject.Instantiate
        UIApp.Panel_Login_Open(mainContext.uiContext, () => {
            UIApp.Panel_Login_Close(mainContext.uiContext);
            GameBusiness.Enter(mainContext.gamaContext);


            Debug.Log("Panel_Login_Open");
        });



        TemplateInfra.Load(mainContext.templateContext);
        AsstesInfra.Load(mainContext.assetsContext);





    }

    float restDT;

    const float FIXED_INTERVAL = 0.01f;

    void Update() {

        float dt = Time.deltaTime;
        GameBusiness.PreTick(mainContext.gamaContext, dt);


        restDT += dt;
        if (restDT <= FIXED_INTERVAL) {
            GameBusiness.FixedTick(mainContext.gamaContext, restDT);
            restDT = 0;

        } else {
            while (restDT >= FIXED_INTERVAL) {
                GameBusiness.FixedTick(mainContext.gamaContext, FIXED_INTERVAL);
                restDT -= FIXED_INTERVAL;
            }
        }


        GameBusiness.LateTick(mainContext.gamaContext, dt);


    }
}
