using System.Threading;
using UnityEngine;
public static class GameBusiness {

    public static void Select(GameContext ctx, TemplateContext tplctx) {
        InputEntity input = ctx.inputEntity;
        UIApp.Panel_Login_Close(ctx.uiContext);
        PlayerDomain.Add(ctx);

        // 打开UI
        UIApp.Panel_Sun_Open(ctx.uiContext);
        UIApp.Panel_SunSet(ctx.uiContext, ctx.playerEntity.sun);

        UIApp.Panel_Shovel_Open(ctx.uiContext);
        UIApp.Panel_ShovelElementAdd(ctx.uiContext);

        UIApp.Panel_PlantManifest_Open(ctx.uiContext);
        UIApp.Panel_Select_Open(ctx.uiContext);


        int[] manifest = ctx.playerEntity.plantManifestTypeIDs;

        for (int i = 0; i < manifest.Length; i++) {
            int plantTypeID = manifest[i];
            bool has = tplctx.plants.TryGetValue(plantTypeID, out PlantTM plantTM);
            if (!has) {
                Debug.LogError("ERror" + plantTypeID);
                continue;
            }
            UIApp.Panel_SelectElementAdd(ctx.uiContext, plantTM.sprite, plantTM.typeID);
        }
    }


    public static void Enter(GameContext ctx, TemplateContext tplctx) {
        //plar
        PlayerDomain.init(ctx);
        // PlayerDomain.Add(ctx);

        CellDomain.SpawnGrid(ctx);

        InputEntity input = ctx.inputEntity;

        // 生成home界面
        //0先随便写一个ID
        for (int i = 1; i <= 5; i++) {
            HomeDomain.Spawn(ctx, i);
        }

        // 生成僵尸
        for (int i = 1; i <= 5; i++) {
            BaseDomain.Spawn(ctx, i);

        }
        // CartDomain.Spawn(ctx, new Vector2(0, 0));

        //生成推车
        int homeLen = ctx.homeRepository.TakeAll(out HomeEntity[] homes);
        for (int i = 0; i < homeLen; i++) {
            HomeEntity home = homes[i];
            CartDomain.Spawn(ctx, new Vector2(home.transform.position.x + 1, home.transform.position.y));
        }

        // 生成地块
        for (int i = -3; i < 2; i++) {

            for (int j = -8; j < 9; j++) {

                // CellDomain.Spawn(ctx, new Vector2(j, i));

            }
        }
        // CellDomain.Spawn(ctx, new Vector2(0, 0));
        //打开UI
        UIApp.Panel_PlantManifest_Open(ctx.uiContext);

        UIApp.Panel_Sun_Open(ctx.uiContext);

        UIApp.Panel_SunSet(ctx.uiContext, ctx.playerEntity.sun);


        // 生成植物
        int[] manifest = ctx.playerEntity.plantManifestTypeIDs;

        for (int i = 0; i < manifest.Length; i++) {
            int plantTypeID = manifest[i];
            bool has = tplctx.plants.TryGetValue(plantTypeID, out PlantTM plantTM);
            if (!has) {
                Debug.LogError("ERror" + plantTypeID);
                continue;
            }
            int plantClickID = plantTM.typeID;
            UIApp.Panel_PlantManifest_AddElement(ctx.uiContext, plantTypeID, plantTM.sprite,
             plantTM.plantName, plantTM.plantPrice, ctx.playerEntity.plantCount, plantTM.typeID);

        }


    }
    // 每帧一次
    public static void PreTick(GameContext ctx, float dt) {
        //input
        InputEntity input = ctx.inputEntity;
        input.mouseScreenPos = Input.mousePosition;
        Camera camera = ctx.camera;
        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);
        input.isMouseLeftDown = Input.GetMouseButtonDown(0);
        if (input.isMouseLeftDown) {
            Vector3Int offset = new Vector3Int(-8, -3, 0);
            Vector3Int intPos = ctx.gridEntity.tilemap.WorldToCell(input.mouseWorldPos);
            Debug.Log(intPos - offset);
        }




        //植物跟着鼠标走
        UserIntetfaceDomain.PreTick(ctx, dt);

    }
    // 可能一帧多次
    public static void FixedTick(GameContext ctx, float fixdt) {

        int basesLen = ctx.baseRepository.TakeAll(out BaseEntity[] bases);

        int a = Common.Random(0, 5);

        BaseEntity baseEntity = bases[a];
        BaseDomain.TrySpawnMst(ctx, baseEntity, fixdt, a);


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
                PlantDomain.TrySpawnNoBlt(ctx, plant, fixdt);
                PlantDomain.TrySpawnBlt(ctx, plant, fixdt);

            }
            if (plant.isShovel == true) {
                PlantDomain.OverLapShovel(ctx, plant);

            }
            if (plant.isDisposable == true) {
                PlantDomain.OverLapMst(ctx, plant);
            }
            if (plant.isMine == true) {

                plant.intervalTimer -= fixdt;

                if (plant.intervalTimer <= 0) {
                    plant.intervalTimer = plant.interval;
                    PlantDomain.OverLapMst(ctx, plant);
                }

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

        // for cart
        int cartLen = ctx.cartRepository.TakeAll(out CartEntity[] carts);
        for (int i = 0; i < cartLen; i++) {
            CartEntity cart = carts[i];
            CartDomain.OverLapMst(ctx, cart, fixdt);
            if (cart.isMove == true) {
                CartDomain.Move(cart, new Vector2(1, 0), fixdt);
                if (cart.transform.position.x > 8) {
                    CartDomain.UnSpawn(ctx, cart);
                }
            }
        }
        // for cell 
        CellDomain.OverLapMouse(ctx);
        int cellLen = ctx.cellRepository.TakeAll(out CellEntity[] cells);
        for (int i = 0; i < cellLen; i++) {
            CellEntity cell = cells[i];
            CellDomain.MstOnCell(ctx, cell);
        }
    }
    //每针一次
    public static void LateTick(GameContext ctx, float dt) {
        UIApp.Panel_SunSet(ctx.uiContext, ctx.playerEntity.sun);
        ctx.inputEntity.Reset();

    }
}