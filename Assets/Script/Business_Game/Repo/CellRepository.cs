using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;



public class CellRepository {

    Dictionary<int, CellEntity> all;

    CellEntity[] temArray;

    public CellRepository() {
        all = new Dictionary<int, CellEntity>();
        temArray = new CellEntity[1000];
    }

    public void Add(CellEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(CellEntity cell) {
        all.Remove(cell.id);
    }
    //这个没有兼顾超过all数量的情况
    public int TakeAll(out CellEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;
    }
    public CellEntity Find(Predicate<CellEntity> predicate) {
        foreach (CellEntity cell in all.Values) {
            bool isMatch = predicate(cell);
            if (isMatch) {
                return cell;
            }
        }
        return null;
    }
}
