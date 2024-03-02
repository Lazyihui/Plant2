using UnityEngine;
public static class GameBusiness {
    public static void Enter(GameContext ctx, TemplateContext tplctx) {

        InputEntity input = ctx.inputEntity;

        //plar
        PlayerDomain.init(ctx);
        PlayerDomain.Add(ctx);

        // 生成home界面
        //0先随便写一个ID
        for (int i = 1; i <= 5; i++) {
            HomeDomain.Spawn(ctx, i);
        }

        // 生成僵尸
        for (int i = 1; i <= 5; i++) {
            BaseDomain.Spawn(ctx, i);

        }

        // 生成地块
        for (int i = -3; i < 2; i++) {
            for (int j = -8; j < 9; j++) {
                CellDomain.Spawn(ctx, new Vector2(j, i));
            }
        }
        // CellDomain.Spawn(ctx, new Vector2(0, 0));
        // 生成植物
        //打开UI
        UIApp.Panel_PlantManifest_Open(ctx.uiContext);

        UIApp.Panel_Sun_Open(ctx.uiContext);

        UIApp.Panel_SunSet(ctx.uiContext, ctx.playerEntity.sun);

        UIApp.Panel_Shovel_Open(ctx.uiContext);

        UIApp.Panel_ShovelElementAdd(ctx.uiContext, () => {

            Vector2 pos = input.mouseWorldPos;
            //9是铲子
            PlantDomain.Spawn(ctx, 9, pos);
        });

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
                if (plantTM.sun <= ctx.playerEntity.sun) {
                    PlantDomain.Spawn(ctx, plantTypeID, pos);
                }

            });
        }



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

        if (!ctx.playerEntity.enterGame == true) {
            return;
        }
        int basesLen = ctx.baseRepository.TakeAll(out BaseEntity[] bases);

        int a = Common.Random(0, 5);
        BaseEntity baseEntity = bases[a];
        BaseDomain.TrySpawnMst(ctx, baseEntity, fixdt);

        for (int i = 0; i < basesLen; i++) {
            // BaseEntity baseEntity = bases[i];

        }


        // for mst

        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);
        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            // MstDomain.Spawn(ctx, 1, new Vector2(0, 0));
            MstDomain.MoveByPath(ctx, mst, fixdt);
            MstDomain.OverLapHome(ctx, mst);
        }

        // for plant
        int panelLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < panelLen; i++) {
            PlantEntity plant = plants[i];
            if (plant.isPlanted == true) {

                PlantDomain.TrySpawnBlt(ctx, plant, fixdt);

            }
            if (plant.isShovel == true) {
                PlantDomain.OverLapShovel(ctx, plant);

            }
            if (plant.isDisposable == true) {
                PlantDomain.OverLapMst(ctx, plant);
            }
        }

        // for bullet
        int bulletLen = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {
            BulletEntity bullet = bullets[i];
            //1是子弹
            if (bullet.typeID == 1) {
                BulletDomain.MoveX(bullet, 1, fixdt);
                BulletDomain.OverLapMst(ctx, bullet);
            }
            //2是太阳
            if (bullet.typeID == 2) {
                BulletDomain.OverLapMouse(ctx, bullet);
            }
        }



    }
    //每针一次
    public static void LateTick(GameContext ctx, float dt) {

        UIApp.Panel_SunSet(ctx.uiContext, ctx.playerEntity.sun);
        ctx.inputEntity.Reset();

    }
}