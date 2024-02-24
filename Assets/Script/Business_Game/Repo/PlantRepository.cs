using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;



public class plantRepository {

    Dictionary<int, plantEntity> all;

    plantEntity[] temArray;

    public plantRepository() {
        all = new Dictionary<int, plantEntity>();
        temArray = new plantEntity[1000];
    }

    public void Add(plantEntity entity) {
        all.Add(entity.id, entity);
    }
    //这个没有兼顾超过all数量的情况
    public int TakeAll(out plantEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;

    }
}
