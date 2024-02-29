using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;
        // for plant
        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < plantLen; i++) {
            PlantEntity plant = plants[i];

            if (plant.isShooter == true || plant.isSun == true) {
                if (Input.GetMouseButtonDown(0)) {
                    input.isMouseLeftDown = true;
                }


                if (plant.isPlanted == false) {
                    plant.transform.position = input.mouseWorldPos;
                }
                Vector2 pos = plant.transform.position;

                if (input.isMouseLeftDown && plant.isPlanted == false) {

                    plant.transform.position = pos;
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