using UnityEngine;

public static class MstDomain {


    public static MstEntity Spawn(GameContext ctx, int TypeID, Vector2 pos) {
        MstEntity prefab = ctx.assetsContext.mstEntity;
        MstEntity mstEntity = GameObject.Instantiate(prefab);
        mstEntity.Ctor();
        mstEntity.SetPos(pos);
        mstEntity.id = ctx.MstID++;
        mstEntity.moveSpeed = 5.0f;

        ctx.mstRepository.Add(mstEntity);
        return mstEntity;
    }


    public static void MoveByPath(GameContext ctx, MstEntity mst, float fixdt) {
        if (mst.path == null) {
            return;
        }

        if (mst.pathIndex >= mst.path.Length) {
            return;
        }

        Vector2 target = mst.path[mst.pathIndex];




        Vector2 dir = target - (Vector2)mst.transform.position;
        if (dir.sqrMagnitude < 0.01f) {
            mst.pathIndex++;
        } else {
            dir.Normalize();
            mst.Move(dir, fixdt);
        }
    }
}