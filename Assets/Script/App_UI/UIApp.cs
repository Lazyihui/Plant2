using UnityEngine;
using System.Collections.Generic;
using System;

//所以UI的东西都在这里
// 可以直接写在main里面，但是这样会很乱
public static class UIApp {


    public static void Panel_Login_Open(UIcontext context, Action onClickStartHandle) {
        Panel_Login panel_Login = context.panel_Login;
        if (panel_Login == null) {

            panel_Login = GameObject.Instantiate(context.assetsContext.panel_Login, context.canvas.transform);

            panel_Login.Ctor();
            panel_Login.OnStartClickHandle = onClickStartHandle;
            context.panel_Login = panel_Login;
        }
        panel_Login.Show();
    }

    public static void Panel_Login_Close(UIcontext context) {
        Panel_Login panel_Login = context.panel_Login;
        if (panel_Login != null) {
            panel_Login.Close();
        }
    }

}