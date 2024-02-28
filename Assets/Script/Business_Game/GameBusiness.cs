using UnityEngine;
public static class GameBusiness {
    public static void Enter(GameContext ctx, TemplateContext tplctx) {

        InputEntity input = ctx.inputEntity;

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

        // 生成植物
        PlayerDomain.Add(ctx);
        //打开UI
        UIApp.Panel_PlantManifest_Open(ctx.uiContext);


        // 生成植物
        int[] manifest = ctx.playerEntity.plantManifestTypeIDs;

        for (int i = 0; i < manifest.Length; i++) {
            int plantTypeID = manifest[i];
            bool has = tplctx.plants.TryGetValue(plantTypeID, out PlantTM plantTM);
            if (!has) {
                Debug.LogError("ERror" + plantTypeID);
                continue;
            }
            UIApp.Panel_PlantManifest_AddElement(ctx.uiContext, plantTypeID, plantTM.sprite, plantTM.plantName, plantTM.plantPrice, () => {

                Vector2 pos = input.mouseWorldPos;

                PlantDomain.Spawn(ctx, plantTypeID, pos);

            });
        }


        // PlantDomain.Spawn(ctx, 1, Vector2.zero);



    }
    // 每帧一次
    public static void PreTick(GameContext ctx, float dt) {


        InputEntity input = ctx.inputEntity;

        input.mouseScreenPos = Input.mousePosition;

        Camera camera = ctx.camera;
        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);


        


        //植物跟着鼠标走
        UserIntetfaceDomain.PreTick(ctx, dt);

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

        // for plant
        int panelLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < panelLen; i++) {
            PlantEntity plant = plants[i];
            if (plant.isLive == true) {

                PlantDomain.TrySpawnBlt(ctx, plant, fixdt);

                // BulletEntity bullet = BulletDomain.Spawn(ctx, 1, plant.transform.position);

            }
        }

        // for bullet
        int bulletLen = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {
            BulletEntity bullet = bullets[i];
            BulletDomain.Move(bullet, 1, fixdt);
            BulletDomain.OverLapMst(ctx,bullet);
        }


    }
    //每针一次
    public static void LateTick(GameContext ctx, float dt) {

        // 更新UI
    }
}