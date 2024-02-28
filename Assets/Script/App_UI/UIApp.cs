using UnityEngine;
using System.Collections.Generic;
using System;

//所以UI的东西都在这里
// 可以直接写在main里面，但是这样会很乱
public static class UIApp {


    //登入页面
    public static void Panel_Login_Open(UIcontext ctx, Action onClickStartHandle) {
        Panel_Login panel_Login = ctx.panel_Login;
        if (panel_Login == null) {

            bool has = ctx.assetsContext.Panel_TryGetPrefab("Panel_Login", out GameObject prefab);

            if (has == false) {
                Debug.LogError("prefab==null err");
                return;
            }

            panel_Login = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();

            panel_Login.Ctor();
            panel_Login.OnStartClickHandle = onClickStartHandle;
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

    //增加element
    public static void Panel_PlantManifest_AddElement(UIcontext ctx, int typeID, Sprite sprite, string plantName, string plantPrice, Action onPlantClickHandle) {
        Panel_PlantManifest panel_PlantManifest = ctx.panel_PlantManifest;
        panel_PlantManifest.AddElement(typeID, sprite, plantName, plantPrice, onPlantClickHandle);
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

    public static void Panel_SunElementAdd(UIcontext ctx, int sunSum) {
        Panel_Sun panel_Sun = ctx.panel_Sun;
        panel_Sun.AddSunElement(sunSum);

    }

    public static void Panel_SunElementAddSunSum(UIcontext ctx, int sunSum) {
        Panel_Sun panel_Sun = ctx.panel_Sun;
    }



}