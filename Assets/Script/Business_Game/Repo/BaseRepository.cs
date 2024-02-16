using System;

using System.Collections.Generic;



public class BaseRepository {

    Dictionary<int, BaseEntity> all;

    public BaseRepository() {
        all = new Dictionary<int, BaseEntity>();
    }

    public void Add(BaseEntity entity) {
        all.Add(entity.id, entity);
    }
}
