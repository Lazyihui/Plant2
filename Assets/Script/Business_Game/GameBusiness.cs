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
    // 每帧一次
    public static void PreTick(GamaContext ctx, float dt) {
        // for各种东西

    }
    // 可能一帧多次
    public static void FixedTick(GamaContext ctx, float fixdt) {
        int basesLen = ctx.baseRepository.TakeAll(out BaseEntity[] bases);

        for (int i = 0; i < basesLen; i++) {
            Debug.Log("FixedTick");

            BaseEntity baseEntity = bases[i];

            BaseDomain.TrySpawnMst(ctx, bases[i], fixdt);
        }
    }
    //每针一次
    public static void LateTick(GamaContext ctx, float dt) {
        // 更新UI
    }
}