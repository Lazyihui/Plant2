using UnityEngine;

public static class CellDomain {
    public static CellEntity Spawn(GameContext ctx, int TypeID, Vector2 pos) {

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Cell", out GameObject prefab);


        CellEntity cellEntity = GameObject.Instantiate(prefab).GetComponent<CellEntity>();
        
        cellEntity.Ctor();
        cellEntity.SetPos(pos);
        cellEntity.Init();
        cellEntity.id = ctx.cellID++;
        ctx.cellRepository.Add(cellEntity);
        return cellEntity;
    }
}