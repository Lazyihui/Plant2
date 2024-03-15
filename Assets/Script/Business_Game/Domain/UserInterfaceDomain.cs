using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;
        // for plant
        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);

        PlantEntity plant = ctx.plantRepository.Find(plant => plant.isPlanted == false);
        if (plant == null) {
            return;
        }
        //好像不要这个判断
        if (!plant.isShovel == true) {
            //遍历格子

            //植物的位置
            if (plant.isPlanted == false && plant.sun <= ctx.playerEntity.sun) {
                Vector2 posz = new Vector2((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);
                plant.transform.position = posz;
            }

            Vector2 posInt = new Vector2((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);
            Vector2 pos = posInt;

            if (input.isMouseLeftDown) {
                // Vector2Int gridPos = new Vector2Int((int)plant.transform.position.x, (int)plant.transform.position.y);
                // plant = ctx.plantRepository.FindByPos(gridPos);
                // if (plant == null) {
                //     Debug.Log("这个位置有植物");
                //     return;
                // }
                Vector3Int gridEntityPos = ctx.gridEntity.tilemap.cellBounds.min + ctx.gridEntity.tilemap.WorldToCell(input.mouseWorldPos);

                Vector3Int offset = new Vector3Int(-6, -3, 0);
                Vector3Int intPos = ctx.gridEntity.tilemap.WorldToCell(input.mouseWorldPos);
                Vector3Int gridPos = intPos - offset;

                Debug.Log(gridPos);

                if (!plant.isPlanted && plant.sun <= ctx.playerEntity.sun) {

                    if (gridPos.x >= 0 && gridPos.y >= 0 && gridPos.x <= 13 && gridPos.y <= 4) {

                        plant.transform.position = pos;
                        ctx.playerEntity.sun -= plant.sun;
                        plant.gridPos = (Vector2Int)gridPos;
                        ctx.plantRepository.AddVector2Int(plant);
                        plant.isPlanted = true;

                    }
                }

            }
        }
        //铲子
        if (plant.isShovel == true) {
            plant.transform.position = input.mouseWorldPos;
            Vector2 pos = plant.transform.position;

            if (input.isMouseLeftDown) {

            }
        }
    }


}