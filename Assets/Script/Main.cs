 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour {
    //拖拽绑定

    MainContext ctx;

    AssetsContext assetsContext;


    void Start() {

        Application.targetFrameRate = 120;


        ctx = new MainContext();

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Camera mainCamera = gameObject.GetComponentInChildren<Camera>();

        ctx.Inject(canvas, mainCamera);


        TemplateInfra.Load(ctx.templateContext);
        AsstesInfra.Load(ctx.assetsContext);



        UIApp.Panel_Login_Open(ctx.uiContext, () => {


            
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.gamaContext, ctx.templateContext);


        });


    }

    float restDT;

    const float FIXED_INTERVAL = 0.01f;

    void Update() {

        float dt = Time.deltaTime;
        GameBusiness.PreTick(ctx.gamaContext, dt);

        // if (Input.GetMouseButtonDown(0)) {
        //     ctx.gamaContext.playerEntity.sun += 50;
        //     //sunElement的sunSum增加
        // }

        restDT += dt;
        if (restDT <= FIXED_INTERVAL) {
            GameBusiness.FixedTick(ctx.gamaContext, restDT);
            restDT = 0;

        } else {
            while (restDT >= FIXED_INTERVAL) {
                GameBusiness.FixedTick(ctx.gamaContext, FIXED_INTERVAL);
                restDT -= FIXED_INTERVAL;
            }
        }


        GameBusiness.LateTick(ctx.gamaContext, dt);

    }
}
