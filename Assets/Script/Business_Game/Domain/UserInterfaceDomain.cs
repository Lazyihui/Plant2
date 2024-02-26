using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;


        int panelLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);

        for (int i = 0; i < panelLen; i++) {

            if (Input.GetMouseButtonDown(0)) {
                input.isMouseLeftDown = true;
            }

            // if (plants[i].isPlanted == false) {
            //     plants[i].transform.position = input.mouseWorldPos;
            // }
            PlantEntity plant = plants[i];

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




    }



}