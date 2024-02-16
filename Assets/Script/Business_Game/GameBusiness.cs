using UnityEngine;
public static class GameBusiness {
    public static void Enter(GamaContext ctx) {
        Debug.Log("Game Started");
        // 生成home界面
        //0先随便写一个ID
        HomeDomain.Spawn(ctx, 0, new Vector2(-8, 0));

        // 生成僵尸
        BaseDomain.Spawn(ctx, 0, new Vector2(8, 0));
    
    }
}