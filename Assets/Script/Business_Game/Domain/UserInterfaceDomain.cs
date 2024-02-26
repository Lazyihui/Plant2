using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;


        int panelLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);

        for (int i = 0; i < panelLen; i++) {
            PlantEntity plant = plants[i];

            bool isInside = PFPhysics.IsPointInsideRectangle(input.mouseWorldPos, plant.transform.position, plant.shapeSize);




            if (isInside && Input.GetMouseButton(0)) {

                plant.transform.position = input.mouseWorldPos;


            }

        }




    }



}