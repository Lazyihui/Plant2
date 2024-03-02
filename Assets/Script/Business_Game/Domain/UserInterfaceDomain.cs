using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;
        // for plant
        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < plantLen; i++) {
            PlantEntity plant = plants[i];
            //好像不要这个判断
            if (plant.isShooter == true || plant.isSun == true || plant.isDisposable == true) {
                if (Input.GetMouseButtonDown(0)) {
                    input.isMouseLeftDown = true;
                }


                if (plant.isPlanted == false && plant.sun <= ctx.playerEntity.sun) {
                    Vector2 posz = new Vector2((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);
                    plant.transform.position = posz;
                }
                Vector2 posInt = new Vector2((int)input.mouseWorldPos.x, (int)input.mouseWorldPos.y);

                Vector2 pos = posInt;

                if (input.isMouseLeftDown && plant.isPlanted == false && plant.sun <= ctx.playerEntity.sun) {

                    plant.transform.position = pos;
                    ctx.playerEntity.sun -= plant.sun;
                    plant.isPlanted = true;

                }
                input.isMouseLeftDown = false;
            }

            if (plant.isShovel == true) {
                if (Input.GetMouseButtonDown(0)) {
                    input.isMouseLeftDown = true;
                }
                plant.transform.position = input.mouseWorldPos;
                Vector2 pos = plant.transform.position;

                if (input.isMouseLeftDown) {

                }
                input.isMouseLeftDown = false;
            }
        }




    }



}