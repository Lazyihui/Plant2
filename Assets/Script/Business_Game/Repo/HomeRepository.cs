using System;

using System.Collections.Generic;



public class HomeRepository {

    Dictionary<int, HomeEntity> all;

    HomeEntity[] temArray;

    public HomeRepository() {
        all = new Dictionary<int, HomeEntity>();
        temArray = new HomeEntity[10];
    }

    public void Add(HomeEntity entity) {
        all.Add(entity.id, entity);
    }
    //委托 Predicate<HomeEntity> Action<>
    public HomeEntity Find(Predicate<HomeEntity> predicate) {
        foreach (HomeEntity home in all.Values) {
            bool isMatch = predicate(home);

            if (isMatch) {
                return home;
            }
        }
        return null;
    }
    public int TakeAll(out HomeEntity[] array) {

        all.Values.CopyTo(temArray, 0);
        array = temArray;
        return all.Count;
    }

}
