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

            int cellLen = ctx.cellRepository.TakeAll(out CellEntity[] cells);
            for (int j = 0; j < cellLen; j++) {
                Vector2 posInt = new Vector2((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);
                Vector2 pos = posInt;

                CellEntity cell = cells[j];
                if (input.isMouseLeftDown) {
                    if (!plant.isPlanted && plant.sun <= ctx.playerEntity.sun && cell.isPlant&&!cell.isHavePlant) {
                        Debug.Log("plant.sun" + cell.isPlant);
                        plant.transform.position = pos;
                        ctx.playerEntity.sun -= plant.sun;
                        plant.isPlanted = true;
                        cell.isHavePlant = true;
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