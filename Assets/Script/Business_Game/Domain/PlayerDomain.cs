using UnityEngine;
public static class PlayerDomain {
    public static void Add(GameContext ctx) {

        GameConfigTM tm = ctx.templateContext.gameConfig;

        PlayerEntity player = ctx.playerEntity;


        player.plantManifestTypeIDs = tm.plantManifestTypeIDs;

    }

    public static void init(GameContext ctx) {
        ctx.playerEntity.sun = 100;
        ctx.playerEntity.enterGame = true;
    }
}