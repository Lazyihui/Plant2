using UnityEngine;

public static class GridDomain {

    public static void SpawnGrid(GameContext ctx) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Grid", out GameObject prefab);
        GridEntity gridEntity = GameObject.Instantiate(prefab).GetComponent<GridEntity>();
        gridEntity.Ctor();
        ctx.gridEntity = gridEntity;
    }

    //鼠标和cell的检测

    //Cell 和 mst 的看在不在一条路上
}