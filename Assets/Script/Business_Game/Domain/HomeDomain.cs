using UnityEngine;
public static class HomeDomain {

    public static HomeEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Home", out GameObject prafab);

        HomeEntity homeEntity = GameObject.Instantiate(prafab).GetComponent<HomeEntity>();
        homeEntity.Ctor();
        homeEntity.SetPos(pos);
        homeEntity.id = ctx.homeID++;
        ctx.homeRepository.Add(homeEntity);
        return homeEntity;
    }
}