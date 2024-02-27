using UnityEngine;
public static class HomeDomain {

    public static HomeEntity Spawn(GameContext ctx, int typeID) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Home", out GameObject prafab);

        bool has = ctx.templateContext.homes.TryGetValue(typeID, out HomeTM tm);
        if (!has) {
            Debug.LogError("没找到" + typeID);
        }

        HomeEntity homeEntity = GameObject.Instantiate(prafab).GetComponent<HomeEntity>();
        
        homeEntity.Ctor();
        homeEntity.SetPos(tm.pos);
        homeEntity.typeID = tm.TypeID;
        homeEntity.id = ctx.homeID++;
        ctx.homeRepository.Add(homeEntity);
        return homeEntity;
    }
}