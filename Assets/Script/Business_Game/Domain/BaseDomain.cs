using UnityEngine;

public static class BaseDomain {


    public static BaseEntity Spawn(GameContext ctx, int id, Vector2 pos) {

        BaseEntity prafab = ctx.assetsContext.baseEntity;
        BaseEntity entity = GameObject.Instantiate(prafab);
        entity.Ctor();
        entity.id = id++;
        entity.SetPos(pos);
        entity.Init();
        ctx.baseRepository.Add(entity);
        return entity;
    }

    public static void TrySpawnMst(GameContext ctx, BaseEntity bases, float fixdt) {
        // 单个
        bases.cd -= fixdt;
        if (bases.cd > 0) {
            return;
        }
        bases.intervalTimer -= fixdt;
        if (bases.intervalTimer <= 0) {
            bases.intervalTimer = bases.interval;
            Debug.Log("生成怪物");
            //这个ID可以在base里存一个
            MstEntity mst = MstDomain.Spawn(ctx, 0, bases.transform.position);
            mst.path = bases.path;


        }

        bases.maintainTimer -= fixdt;
        if (bases.maintainTimer <= 0) {
            bases.maintainTimer = bases.maintain;
            bases.cd = bases.maxCd;

        }
    }
}