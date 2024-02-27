using UnityEngine;

public static class BulletDomain {


    public static BulletEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Bullet", out GameObject prefab);

        bool has = ctx.templateContext.bullets.TryGetValue(typeID, out BulletTM tm);
        if (!has) {
            Debug.LogError("没找到" + typeID);
        }
        Debug.Log("BulletDomain Spawn");

        BulletEntity bulletEntity = GameObject.Instantiate(prefab).GetComponent<BulletEntity>();
        Debug.Log("BulletDomain Spawn 2");
        bulletEntity.Ctor();
        bulletEntity.SetPos(pos);
        bulletEntity.id = ctx.bulletID++;
        bulletEntity.typeID = tm.typeID;
        bulletEntity.damage = tm.damage;
        bulletEntity.moveSpeed = tm.moveSpeed;
        bulletEntity.Init(tm.sprite);
        ctx.bulletRepository.Add(bulletEntity);
        return bulletEntity;

    }

    public static void MoveByPath(GameContext ctx, BulletEntity blt, float fixdt) {
        if (blt.path == null) {
            return;
        }

        if (blt.pathIndex >= blt.path.Length) {
            return;
        }

        Vector2 target = blt.path[blt.pathIndex];


        Vector2 dir = target - (Vector2)blt.transform.position;
        if (dir.sqrMagnitude < 0.01f) {
            blt.pathIndex++;
        } else {
            dir.Normalize();
            blt.MoveBy(dir, fixdt);
        }
    }

    public static void Move(BulletEntity bullet, float x, float dt) {
        bullet.Move(x, dt);
    }

}