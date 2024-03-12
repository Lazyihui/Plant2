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
        cellEntity.isHavePlant = false;
        cellEntity.isPlant = false;
        ctx.cellRepository.Add(cellEntity);
        return cellEntity;
    }
    //鼠标和cell的检测
    public static void OverLapMouse(GameContext ctx) {
        InputEntity input = ctx.inputEntity;
        int cellLen = ctx.cellRepository.TakeAll(out CellEntity[] cells);
        for (int i = 0; i < cellLen; i++) {
            CellEntity cell = cells[i];
                Vector3 pos = new Vector3((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);
                float dirSqr = Vector2.SqrMagnitude(cell.transform.position - pos);
                if (dirSqr < 0.1f) {
                    Debug.Log(cell.isPlant);
                    cell.isPlant = true;
                    Debug.Log(cell.isPlant);
            }
        }
    }

    //Cell 和 mst 的看在不在一条路上
    public static void MstOnCell(GameContext ctx, CellEntity cell) {
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);

        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            if (mst.line == cell.line) {
                cell.isHaveMst = true;
            }
        }
    }
}