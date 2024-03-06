using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;


public class Main : MonoBehaviour
{
    //拖拽绑定
    MainContext ctx;

    // 这里只运行一次！！！！！！！！
    void Start()
    {

        Application.targetFrameRate = 120;

        // === Instantiation ====
        ctx = new MainContext();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Camera mainCamera = gameObject.GetComponentInChildren<Camera>();

        // ==== Injection ====
        ctx.Inject(canvas, mainCamera);

        // ==== Load ====
        TemplateInfra.Load(ctx.templateContext);
        AsstesInfra.Load(ctx.assetsContext);

        // ==== Binding ====
        Binding();

        // ==== Init ====

        // ==== Enter ====
        LoginBusiness.Enter(ctx);

    }

    void Binding()
    {

        var uiEvents = ctx.uiContext.events;
        uiEvents.Login_StartGameHandle = () =>
        {
            GameBusiness.Select(ctx.gamaContext, ctx.templateContext);
        };

    }

    float restDT;

    const float FIXED_INTERVAL = 0.01f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UIApp.Panel_Select_Close(ctx.uiContext);
        }

        if (ctx.gamaContext.playerEntity.enterGame == true)
        {


            float dt = Time.deltaTime;
            GameBusiness.PreTick(ctx.gamaContext, dt);
            // if (Input.GetMouseButtonDown(0)) {
            //     ctx.gamaContext.playerEntity.sun += 50;
            //     //sunElement的sunSum增加
            // }
            restDT += dt;
            if (restDT <= FIXED_INTERVAL)
            {
                GameBusiness.FixedTick(ctx.gamaContext, restDT);
                restDT = 0;
            }
            else
            {
                while (restDT >= FIXED_INTERVAL)
                {
                    GameBusiness.FixedTick(ctx.gamaContext, FIXED_INTERVAL);
                    restDT -= FIXED_INTERVAL;
                }
            }
            GameBusiness.LateTick(ctx.gamaContext, dt);

        }


    }

}
