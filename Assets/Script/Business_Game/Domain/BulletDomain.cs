using UnityEngine;

public static class BulletDomain {


    public static BulletEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Bullet", out GameObject prefab);

        bool has = ctx.templateContext.bullets.TryGetValue(typeID, out BulletTM tm);
        if (!has) {
            Debug.LogError("没找到" + typeID);
        }

        BulletEntity bulletEntity = GameObject.Instantiate(prefab).GetComponent<BulletEntity>();
        bulletEntity.Ctor();
        bulletEntity.SetPos(pos);
        bulletEntity.id = ctx.bulletID++;
        bulletEntity.typeID = tm.typeID;
        bulletEntity.damage = tm.damage;
        bulletEntity.moveSpeed = tm.moveSpeed;
        bulletEntity.isSun = tm.isClick;
        bulletEntity.isLive = true;
        Vector2 path = new Vector2(pos.x - 8, pos.y);
        bulletEntity.path = new Vector2[] { pos, path };
        bulletEntity.Init(tm.sprite);
        ctx.bulletRepository.Add(bulletEntity);
        return bulletEntity;

    }

    public static void OverLapMst(GameContext ctx, BulletEntity bullet) {
        // 子弹和僵尸的交叉检测
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);

        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];

            if (mst.isLive == true && bullet.isLive == true) {
                float dirSqr = Vector2.SqrMagnitude(mst.transform.position - bullet.transform.position);

                if (dirSqr < 0.1f) {
                    mst.isLive = false;
                    bullet.isLive = false;
                    UnSpawn(ctx, bullet);
                    MstDomain.UnSpawn(ctx, mst);
                }

            }
        }

    }

    public static void OverLapMouse(GameContext ctx, BulletEntity bullet) {
        // 子弹和鼠标的交叉检测
        InputEntity input = ctx.inputEntity;

        if (bullet.isSun == true) {

            if (Input.GetMouseButtonDown(0)) {
                Camera camera = ctx.camera;

                input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);
                Vector3 mousePos = input.mouseWorldPos;

                float dirSqr = Vector2.SqrMagnitude(mousePos - bullet.transform.position);

                if (dirSqr < 0.1f) {
                    bullet.isLive = false;
                    ctx.playerEntity.sun += 25;
                    UnSpawn(ctx, bullet);
                }
            }
        }
    }

    public static void UnSpawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRepository.Remove(bullet);
        bullet.tearDown();
    }

    public static void MoveX(BulletEntity bullet, float x, float dt) {
        bullet.MoveX(x, dt);
    }

}