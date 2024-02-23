using UnityEngine;

public static class BaseDomain {


    public static BaseEntity Spawn(GameContext ctx, int typeID) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Base", out GameObject prafab);

        bool has = ctx.templateContext.bases.TryGetValue(typeID, out BasesTM tm);
        if (!has) {
            Debug.LogError("没找到" + typeID);
        }


        BaseEntity entity = GameObject.Instantiate(prafab).GetComponent<BaseEntity>();
        entity.Ctor();
        entity.id = ctx.baseID++;

        
        entity.typeID = tm.TypeID;
        entity.cd = tm.cd;
        entity.maxCd = tm.cd;
        entity.maintain = tm.maintain;
        entity.maintainTimer = tm.maintain;
        entity.interval = tm.interval;
        entity.intervalTimer = tm.interval;
        entity.mstID = tm.mstTypeID;
        entity.path = tm.path;
        entity.SetPos(tm.pos);


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
            MstEntity mst = MstDomain.Spawn(ctx, bases.mstID, bases.transform.position);
            mst.path = bases.path;


        }

        bases.maintainTimer -= fixdt;
        if (bases.maintainTimer <= 0) {
            bases.maintainTimer = bases.maintain;
            bases.cd = bases.maxCd;

        }
    }
}