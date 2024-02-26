using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;



public class plantRepository {

    Dictionary<int, PlantEntity> all;

    PlantEntity[] temArray;

    public plantRepository() {
        all = new Dictionary<int, PlantEntity>();
        temArray = new PlantEntity[1000];
    }

    public void Add(PlantEntity entity) {
        all.Add(entity.id, entity);
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
}
