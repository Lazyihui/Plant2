using System;
using UnityEngine;

public static class plantDomain {
    public static plantEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        bool has = ctx.templateContext.plants.TryGetValue(typeID, out PlantTM tm);

        if (!has) {
            Debug.LogError("没找到" + typeID);
        }
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Plant", out GameObject prefab);
        plantEntity plantEntity = GameObject.Instantiate(prefab).GetComponent<plantEntity>();

        plantEntity.Ctor();
        plantEntity.SetPos(tm.pos);
        plantEntity.id = ctx.plantID++;


        plantEntity.typeID = tm.typeID;

        plantEntity.Init(tm.typeID, tm.sprite, tm.plantName, tm.plantPrice);

        ctx.plantRepository.Add(plantEntity);
        return plantEntity;
    }
}