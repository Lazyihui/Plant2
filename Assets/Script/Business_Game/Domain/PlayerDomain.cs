using UnityEngine;
public static class PlayerDomain {
    public static void Add(GameContext ctx) {

        GameConfigTM tm = ctx.templateContext.gameConfig;

        PlayerEntity player = ctx.playerEntity;


        player.plantManifestTypeIDs = tm.plantManifestTypeIDs;

    }

    public static void InitSelect(GameContext ctx) {
        ctx.playerEntity.sun = 1000;
        ctx.playerEntity.plantCount = 7;
    }

    public static void init(GameContext ctx) {
        
        ctx.playerEntity.enterGame = true;
    }
}