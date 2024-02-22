using UnityEngine;

public static class MstDomain {


    public static MstEntity Spawn(GamaContext ctx, int TypeID, Vector2 pos) {
        MstEntity prefab = ctx.assetsContext.mstEntity;
        MstEntity mstEntity = GameObject.Instantiate(prefab);
        mstEntity.Ctor();
        mstEntity.SetPos(pos);
        mstEntity.id = ctx.MstID++;

        ctx.mstRepository.Add(mstEntity);
        return mstEntity;
    }

}