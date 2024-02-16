using UnityEngine;

public static class BaseDomain {


    public static BaseEntity Spawn(GamaContext ctx, int id, Vector2 pos) {

        BaseEntity prafab = ctx.assetsContext.baseEntity;
        BaseEntity entity = GameObject.Instantiate(prafab);
        entity.id = id++;
        entity.SetPos(pos);
        ctx.baseRepository.Add(entity);
        return entity;
    }
}