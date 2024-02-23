using UnityEngine;
public static class GameBusiness {
    public static void Enter(GameContext ctx) {

        //plar
        ctx.playerEntity.sun = 0;
        // 生成home界面
        //0先随便写一个ID
        for (int i = 1; i <= 5; i++) {
            HomeDomain.Spawn(ctx, i);
        }

        // 生成僵尸
        for (int i = 1; i <= 5; i++) {
            BaseDomain.Spawn(ctx, i);

        }

        //打开UI
        UIApp.Panel_PlantManifest_Open(ctx.uiContext);

    }
    // 每帧一次
    public static void PreTick(GameContext ctx, float dt) {
        // for各种东西

    }
    // 可能一帧多次
    public static void FixedTick(GameContext ctx, float fixdt) {

        int basesLen = ctx.baseRepository.TakeAll(out BaseEntity[] bases);
        for (int i = 0; i < basesLen; i++) {
            BaseEntity baseEntity = bases[i];
            BaseDomain.TrySpawnMst(ctx, bases[i], fixdt);
        }

        // for mst

        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);
        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            MstDomain.MoveByPath(ctx, mst, fixdt);
            MstDomain.OverLapHome(ctx, mst);
        }
    }
    //每针一次
    public static void LateTick(GameContext ctx, float dt) {

        // 更新UI
    }
}