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
        InputEntity input = ctx.gamaContext.inputEntity;


        var uiEvents = ctx.uiContext.events;
        //开始页面的点击
        uiEvents.Login_StartGameHandle = () =>
        {
            GameBusiness.Select(ctx.gamaContext, ctx.templateContext);
        };
        // 铲子的点击
        uiEvents.ShovelElement_ShovelHandle = () =>
        {

            Vector2 pos = input.mouseWorldPos;
            //11是铲子
            PlantDomain.Spawn(ctx.gamaContext, 11, pos);
        };
        //选择植物的点击
        uiEvents.SelectElement_SelectHandle = () =>
        {



            int plantClickSelectTypeID = ctx.gamaContext.playerEntity.plantClickSelectTypeID;

            bool has = ctx.templateContext.plants.TryGetValue(plantClickSelectTypeID, out PlantTM plantTM);
            if (!has)
            {
                Debug.LogError("ERror" + plantClickSelectTypeID);
            }

            int plantClickTypeID = plantTM.typeID;

            UIApp.Panel_PlantManifest_AddElement_NoClick(ctx.uiContext, 1, plantTM.sprite, plantTM.plantName, plantTM.plantPrice, ctx.gamaContext.playerEntity.plantCount);
            // {

            //     Vector2 pos = ctx.gamaContext.inputEntity.mouseWorldPos;

            //     if (plantTM.sun <= ctx.gamaContext.playerEntity.sun)
            //     {
            //         PlantDomain.Spawn(ctx.gamaContext, plantClickTypeID, pos);
            //     }
            //     //这里想写一个按钮 
            // });

            // UIApp.Panel_Select_Close(ctx.uiContext);
        };

        //植物的点击
        uiEvents.PlantManifestElement_PlantHandle = () =>
        {



            Debug.Log("PlantManifestElement_PlantHandle");
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
