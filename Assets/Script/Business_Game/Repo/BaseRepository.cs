using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;



public class BaseRepository {

    Dictionary<int, BaseEntity> all;

    BaseEntity[] temArray;

    public BaseRepository() {
        all = new Dictionary<int, BaseEntity>();
        temArray = new BaseEntity[1000];
    }

    public void Add(BaseEntity entity) {
        all.Add(entity.id, entity);
    }
    //这个没有兼顾超过all数量的情况
    public int TakeAll(out BaseEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;

    }
}
