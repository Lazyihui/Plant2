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
        plantEntity.isShooter = tm.isShooter;
        plantEntity.isSun = tm.isSun;
        plantEntity.isShovel = tm.isShovel;
        plantEntity.sun = tm.sun;
        plantEntity.isDisposable = tm.isDisposable;


        plantEntity.typeID = tm.typeID;
        plantEntity.bulletTypeID = tm.bulletTypeID;

        plantEntity.Init(tm.typeID, tm.sprite, tm.plantName, tm.plantPrice, tm.shapeSize, tm.cd, tm.cd, tm.maintain, tm.interval);

        ctx.plantRepository.Add(plantEntity);
        return plantEntity;
    }
    public static void OverLapShovel(GameContext ctx, PlantEntity shovel) {
        // 植物和植物的交叉检测
        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);

        for (int i = 0; i < plantLen; i++) {
            PlantEntity plant = plants[i];

            if (plant.isPlanted == true && Input.GetMouseButtonDown(0)) {
                Debug.Log("Unspaw111111111n");
                float dirSqr = Vector2.SqrMagnitude(plant.transform.position - shovel.transform.position);

                if (dirSqr < 0.1f) {
                    Debug.Log("Unspawn");
                    // shovel.isPlanted = false;
                    plant.isPlanted = false;
                    UnSpawn(ctx, plant);
                    UnSpawn(ctx, shovel);
                }

            }
            if (Input.GetMouseButtonDown(1)) {
                // shovel.isPlanted = false;
                UnSpawn(ctx, shovel);
            }
        }

    }

    public static void OverLapMst(GameContext ctx, PlantEntity plant) {
        // 植物和僵尸的交叉检测
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);

        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];

            if (plant.isPlanted && mst.isLive) {
                float dirSqr = Vector2.SqrMagnitude(mst.transform.position - plant.transform.position);
                if (dirSqr < 0.1f) {
                    mst.isLive = false;
                    UnSpawn(ctx, plant);
                    MstDomain.UnSpawn(ctx, mst);
                }
            }
            // if(mst.isLive == true && plant.isPlanted == true){
            //     float dirSqr = Vector2.SqrMagnitude(mst.transform.position - plant.transform.position);
            //     if(dirSqr < 0.1f){
            //         mst.isLive = false;
            //         UnSpawn(ctx, mst);
            //     }
            // }
        }
    }
    public static void UnSpawn(GameContext ctx, PlantEntity plant) {
        ctx.plantRepository.Remove(plant);
        plant.tearDown();
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
            if (plant.isShooter) {
                BulletDomain.Spawn(ctx, plant.bulletTypeID, plant.transform.position);

            }

            if (plant.isSun) {
                // 生成阳光
                Vector2 pos = new Vector2(plant.transform.position.x + 1, plant.transform.position.y - 1);

                BulletDomain.Spawn(ctx, plant.bulletTypeID, pos);
            }
            if (plant.isShovel) {
                // 生成铲子
                return;
            }
            if (plant.isDisposable) {
                // 地雷 南瓜一次性植物
                return;
            }

        }

        plant.maintainTimer -= fixdt;
        if (plant.maintainTimer <= 0) {
            plant.maintainTimer = plant.maintain;
            plant.cd = plant.maxCd;
        }
    }

}