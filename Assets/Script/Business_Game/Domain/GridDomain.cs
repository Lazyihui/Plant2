using UnityEngine;

public static class GridDomain {

    public static void SpawnGrid(GameContext ctx) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Grid", out GameObject prefab);
        GridEntity gridEntity = GameObject.Instantiate(prefab).GetComponent<GridEntity>();
        gridEntity.Ctor();
        ctx.gridEntity = gridEntity;
    }


    public static void isHaveMst(GameContext ctx) {
        
    }

    // 格子上是否有植物

    // public static void IsHavePlant(GameContext ctx, Vector2 pos, out PlantEntity plant) {

    //     plant = ctx.plantRepository.FindByPos(new Vector2Int((int)pos.x, (int)pos.y));
    //     if (plant != null) {
    //         Debug.Log("这个位置有植物");
    //         return;
    //     }

    // }

    public static void GridInit(GameContext ctx) {
        InputEntity input = ctx.inputEntity;

        Vector3Int offset = new Vector3Int(-6, -3, 0);
        Vector3Int intPos = ctx.gridEntity.tilemap.WorldToCell(input.mouseWorldPos);
        Vector3Int gridPos = intPos - offset;

        ctx.gridEntity.tilemap.transform.position = gridPos;

    }

    //鼠标和cell的检测

    //Cell 和 mst 的看在不在一条路上
}