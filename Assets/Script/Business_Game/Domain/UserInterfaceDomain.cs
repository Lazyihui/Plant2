using UnityEngine;
using System;


public static class UserIntetfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;


        int panelLen = ctx.plantRepository.TakeAll(out plantEntity[] plants);

        for (int i = 0; i < panelLen; i++) {
            plantEntity plant = plants[i];

            bool isInside = PFPhysics.IsPointInsideRectangle(input.mouseWorldPos, plant.transform.position, plant.shapeSize);
            if (isInside && Input.GetMouseButtonDown(0)) {

                Debug.Log("aaaa");
            }

        }




    }



}