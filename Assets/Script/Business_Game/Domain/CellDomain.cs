using UnityEngine;

public static class CellDomain {
    public static CellEntity Spawn(GameContext ctx, Vector2 pos) {

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Cell", out GameObject prefab);

        CellEntity cellEntity = GameObject.Instantiate(prefab).GetComponent<CellEntity>();

        cellEntity.Ctor();
        cellEntity.SetPos(pos);
        cellEntity.Init();
        cellEntity.id = ctx.cellID++;
        cellEntity.line = (int)pos.y + 3;
        cellEntity.isHaveMst = false;
        ctx.cellRepository.Add(cellEntity);
        return cellEntity;
    }

    //Cell 和 mst 的看在不在一条路上
    public static void  MstOnCell(GameContext ctx, CellEntity cell) {
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);

        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            if (mst.line == cell.line) {
                cell.isHaveMst = true;
            }
        }
    }
}