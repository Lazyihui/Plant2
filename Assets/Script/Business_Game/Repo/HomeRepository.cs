using System;

using System.Collections.Generic;



public class HomeRepository {

    Dictionary<int, HomeEntity> all;

    public HomeRepository() {
        all = new Dictionary<int, HomeEntity>();
    }

    public void Add(HomeEntity entity) {
        // all.Add(entity.id, entity);
    }
}
