using UnityEngine;

public static class BaseDomain {


    public static BaseEntity Spawn(GamaContext ctx, int id, Vector2 pos) {

        BaseEntity prafab = ctx.assetsContext.baseEntity;
        BaseEntity entity = GameObject.Instantiate(prafab);
        entity.Ctor();
        entity.id = id++;
        entity.SetPos(pos);
        ctx.baseRepository.Add(entity);
        return entity;
    }

    public static void TrySpawnMst(GamaContext ctx, BaseEntity bases, float fixdt) {
        bases.cd -= fixdt;
        if (bases.cd > 0) {
            return;
        }
        bases.intervalTimer -= fixdt;
        if (bases.intervalTimer <= 0) {
            bases.intervalTimer = bases.interval;
            Debug.Log("bases.intervalTimer <= 0");
            // bases.intervalTimer = bases.interval;
            // bases.cd = bases.maxCd;
            // BaseEntity mst = Spawn(ctx, bases.id, bases.transform.position);
            // mst.cd = mst.maxCd;
            // mst.interval = mst.maxCd;
            // mst.intervalTimer = mst.maxCd;
        }

        bases.maintainTimer -= fixdt;
        if (bases.maintainTimer <= 0) {
            bases.maintainTimer = bases.maintain;
            bases.cd = bases.maxCd;
            
            Debug.Log("bases.maintainTimer <= 0");
            // bases.maintainTimer = bases.maintain;
            // bases.cd = bases.maxCd;
            // BaseEntity mst = Spawn(ctx, bases.id, bases.transform.position);
            // mst.cd = mst.maxCd;
            // mst.interval = mst.maxCd;
            // mst.intervalTimer = mst.maxCd;
        }
    }
}