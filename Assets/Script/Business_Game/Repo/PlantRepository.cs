using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;



public class plantRepository {

    Dictionary<int, PlantEntity> all;

    PlantEntity[] temArray;

    Dictionary<Vector2Int, PlantEntity> posDict;



    public plantRepository() {
        all = new Dictionary<int, PlantEntity>();
        temArray = new PlantEntity[1000];
        posDict = new Dictionary<Vector2Int, PlantEntity>();
    }

    public void Add(PlantEntity entity) {
        all.Add(entity.id, entity);
    }

    public void AddVector2Int(PlantEntity entity) {
        posDict.Add(entity.gridPos, entity);
    }

    public void Remove(PlantEntity plant) {
        all.Remove(plant.id);
    }
    public void RemoveVector2Int(PlantEntity plant) {
        posDict.Remove(plant.gridPos);
    }
    //这个没有兼顾超过all数量的情况
    public int TakeAll(out PlantEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;

    }

    public PlantEntity Find(Predicate<PlantEntity> predicate) {
        foreach (PlantEntity plant in all.Values) {
            bool isMatch = predicate(plant);
            if (isMatch) {
                return plant;
            }
        }
        return null;
    }

    public bool IsPosHasPlant(Vector2Int pos) {
        return posDict.ContainsKey(pos);
    }

    public PlantEntity FindByPos(Vector2Int pos) {
        posDict.TryGetValue(pos, out PlantEntity plant);
        return plant;
    }
}
