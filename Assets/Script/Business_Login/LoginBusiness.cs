using UnityEngine;

public static class LoginBusiness {

    public static void Enter(MainContext ctx) {
        UIApp.Panel_Login_Open(ctx.uiContext);

        
    }

    public static void Exit() {
        Debug.Log("退出游戏");
    }   

}