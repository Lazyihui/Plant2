using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;



public class MstRepository {

    Dictionary<int, MstEntity> all;

    MstEntity[] temArray;

    public MstRepository() {
        all = new Dictionary<int, MstEntity>();
        temArray = new MstEntity[1000];
    }

    public void Add(MstEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(MstEntity mst) {
        all.Remove(mst.id);
    }
    //这个没有兼顾超过all数量的情况
    public int TakeAll(out MstEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;


    }

    public MstEntity Find(Predicate<MstEntity> predicate) {
        foreach (MstEntity mst in all.Values) {
            bool isMatch = predicate(mst);
            if (isMatch) {
                return mst;
            }
        }
        return null;
    }
}
