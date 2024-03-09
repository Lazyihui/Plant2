using UnityEngine;
using System.Collections.Generic;
using System;

//所以UI的东西都在这里
// 可以直接写在main里面，但是这样会很乱
public static class UIApp {


    //登入页面
    public static void Panel_Login_Open(UIcontext ctx) {
        Panel_Login panel_Login = ctx.panel_Login;
        if (panel_Login == null) {

            bool has = ctx.assetsContext.Panel_TryGetPrefab("Panel_Login", out GameObject prefab);
            if (has == false) {
                Debug.LogError("prefab==null err");
                return;
            }

            panel_Login = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();
            panel_Login.Ctor();
            panel_Login.OnStartClickHandle = () => {
                ctx.events.Login_StartGame();
            };
            ctx.panel_Login = panel_Login;
        }
        panel_Login.Show();
    }
    public static void Panel_Login_Close(UIcontext context) {
        Panel_Login panel_Login = context.panel_Login;
        if (panel_Login != null) {
            panel_Login.Close();
        }
    }

    public static void Panel_Start_Open(UIcontext ctx) {
        Panel_Start panel_Start = ctx.panel_Start;
        if (panel_Start == null) {
            bool has = ctx.assetsContext.Panel_TryGetPrefab("Panel_Start", out GameObject prefab);
            if (has == false) {
                Debug.LogError("prefab==null err");
                return;
            }

            panel_Start = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Start>();
            panel_Start.Ctor();
            panel_Start.OnStartClickHandle = () => {
                ctx.events.Panel_Start_Start();
            };
            ctx.panel_Start = panel_Start;
        }
        panel_Start.Show();
    }

    public static void Panel_Start_Close(UIcontext context) {
        Panel_Start panel_Start = context.panel_Start;
        if (panel_Start != null) {
            panel_Start.Close();
        }
    }

    //增加element
    public static void Panel_PlantManifest_AddElement(UIcontext ctx, int typeID, Sprite sprite, string plantName, string plantPrice, int count,int plantClickID) {

        Panel_PlantManifest panel_PlantManifest = ctx.panel_PlantManifest;
        panel_PlantManifest.elementCount += 1;
        if (panel_PlantManifest.elementCount > count) {
            return;
        }
        panel_PlantManifest.AddElement(typeID, sprite, plantName, plantPrice, ctx,plantClickID);
    }

    public static void Panel_PlantManifest_AddElement_NoClick(UIcontext ctx, int typeID, Sprite sprite, string plantName, string plantPrice, int count) {

        Panel_PlantManifest panel_PlantManifest = ctx.panel_PlantManifest;
        panel_PlantManifest.elementCount += 1;
        if (panel_PlantManifest.elementCount > count) {
            return;
        }
        panel_PlantManifest.AddElement_NoClick(typeID, sprite, plantName, plantPrice);
    }

    //打开PlantManifest
    public static void Panel_PlantManifest_Open(UIcontext ctx) {
        Panel_PlantManifest panel_PlantManifest = ctx.panel_PlantManifest;
        if (panel_PlantManifest == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_PlantManifest", out GameObject prefab);

            panel_PlantManifest = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_PlantManifest>();

            panel_PlantManifest.Ctor();
            ctx.panel_PlantManifest = panel_PlantManifest;
        }

        panel_PlantManifest.Init();
        panel_PlantManifest.Show();
    }



    // 关闭top
    public static void Panel_Top_Close(UIcontext context) {
        Panel_PlantManifest panel_Top = context.panel_PlantManifest;
        if (panel_Top != null) {
            panel_Top.Close();
        }
    }

    public static void Panel_Sun_Open(UIcontext ctx) {
        Panel_Sun panel_Sun = ctx.panel_Sun;
        if (panel_Sun == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_Sun", out GameObject prefab);

            panel_Sun = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Sun>();

            panel_Sun.Ctor();
            ctx.panel_Sun = panel_Sun;
        }
        panel_Sun.Init();
        panel_Sun.Show();
    }

    public static void Panel_SunSet(UIcontext ctx, int sunSum) {
        Panel_Sun panel_Sun = ctx.panel_Sun;
        if (panel_Sun != null) {
            panel_Sun.SetSunNumber(sunSum);
        }
    }

    public static void Panel_Shovel_Open(UIcontext ctx) {
        Panel_Shovel panel_Shovel = ctx.panel_Shovel;

        if (panel_Shovel == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_Shovel", out GameObject prefab);

            panel_Shovel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Shovel>();

            panel_Shovel.Ctor();
            ctx.panel_Shovel = panel_Shovel;
        }
        panel_Shovel.Init();
        panel_Shovel.Show();
    }

    public static void Panel_ShovelElementAdd(UIcontext ctx) {
        Panel_Shovel panel_Shovel = ctx.panel_Shovel;
        panel_Shovel.AddElement(ctx);
    }

    public static void Panel_Select_Open(UIcontext ctx) {
        Panel_Select panel_Select = ctx.panel_Select;
        if (panel_Select == null) {
            ctx.assetsContext.Panel_TryGetPrefab("Panel_Select", out GameObject prefab);

            panel_Select = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Select>();

            panel_Select.Ctor();
            ctx.panel_Select = panel_Select;
        }
        panel_Select.Init();
        panel_Select.Show();
    }

    public static void Panel_Select_Close(UIcontext context) {
        Panel_Select panel_Select = context.panel_Select;
        if (panel_Select != null) {
            panel_Select.Close();
        }
    }

    public static void Panel_SelectElementAdd(UIcontext ctx, Sprite sprite, int typeID) {
        Panel_Select panel_Select = ctx.panel_Select;
        panel_Select.AddElement(sprite, ctx, typeID);
    }

}