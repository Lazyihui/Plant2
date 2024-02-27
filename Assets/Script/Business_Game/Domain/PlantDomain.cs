using System;
using UnityEngine;

public static class PlantDomain {
    public static PlantEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        bool has = ctx.templateContext.plants.TryGetValue(typeID, out PlantTM tm);

        if (!has) {
            Debug.LogError("没找到" + typeID);
        }
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Plant", out GameObject prefab);
        PlantEntity plantEntity = GameObject.Instantiate(prefab).GetComponent<PlantEntity>();

        plantEntity.Ctor();
        plantEntity.SetPos(tm.plantPos);
        plantEntity.id = ctx.plantID++;
        plantEntity.isPlanted = false;
        plantEntity.isLive = false;


        plantEntity.typeID = tm.typeID;

        plantEntity.Init(tm.typeID, tm.sprite, tm.plantName, tm.plantPrice, tm.shapeSize, tm.cd, tm.cd, tm.maintain, tm.interval);

        ctx.plantRepository.Add(plantEntity);
        return plantEntity;
    }

    public static void TrySpawnBlt(GameContext ctx, PlantEntity plant, float fixdt) {

        plant.cd -= fixdt;
        if (plant.cd > 0) {
            return;
        }

        plant.intervalTimer -= fixdt;
        if (plant.intervalTimer <= 0) {
            plant.intervalTimer = plant.interval;
            plant.cd = plant.maxCd;
            BulletEntity blt = BulletDomain.Spawn(ctx, 1, plant.transform.position);
            BulletDomain.Move(blt, blt.transform.position.x, fixdt);

        }

        plant.maintainTimer -= fixdt;
        if (plant.maintainTimer <= 0) {
            plant.maintainTimer = plant.maintain;
            plant.cd = plant.maxCd;
        }
    }

}