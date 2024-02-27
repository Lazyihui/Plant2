using System;

using System.Collections.Generic;



public class BulletRepository {

    Dictionary<int, BulletEntity> all;

    BulletEntity[] temArray;

    public BulletRepository() {
        all = new Dictionary<int, BulletEntity>();
        temArray = new BulletEntity[10];
    }

    public void Add(BulletEntity entity) {
        all.Add(entity.id, entity);
    }
    //委托 Predicate<BulletEntity> Action<>
    public BulletEntity Find(Predicate<BulletEntity> predicate) {
        foreach (BulletEntity bullet in all.Values) {
            bool isMatch = predicate(bullet);

            if (isMatch) {
                return bullet;
            }
        }
        return null;
    }

}
