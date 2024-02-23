using UnityEngine;
using System.Collections.Generic;
using System;

//所以UI的东西都在这里
// 可以直接写在main里面，但是这样会很乱
public static class UIApp {


    //登入页面
    public static void Panel_Login_Open(UIcontext context, Action onClickStartHandle) {
        Panel_Login panel_Login = context.panel_Login;
        if (panel_Login == null) {
            context.assetsContext.Panel_TryGetPrefab("Panel_Login", out GameObject prefab);

            panel_Login = GameObject.Instantiate(prefab, context.canvas.transform).GetComponent<Panel_Login>();

            panel_Login.Ctor();
            panel_Login.OnStartClickHandle = onClickStartHandle;
            context.panel_Login = panel_Login;
        }
        panel_Login.Show();
    }
    // public static void PN_Login_Open(UICtx uiCtx) {
    //     PN_Login panel = uiCtx.pn_Login;
    //     if (panel == null) {
    //         uiCtx.assetsCtx.Panel_TryGetPrefab("Login_Panel", out GameObject prefab);
    //         panel = GameObject.Instantiate(prefab, uiCtx.screenCanvas.transform).GetComponent<PN_Login>();
    //         panel.Ctor();
    //         uiCtx.pn_Login = panel;
    //         panel.OnstartClickHandle = () => {
    //             uiCtx.events.Login_OnClcikStart();
    //         };
    //     }
    //     panel.Show();

    // }
    public static void Panel_Login_Close(UIcontext context) {
        Panel_Login panel_Login = context.panel_Login;
        if (panel_Login != null) {
            panel_Login.Close();
        }
    }

    //打开top
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

}