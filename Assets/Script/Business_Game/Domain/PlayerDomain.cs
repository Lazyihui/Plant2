using UnityEngine;
public static class PlayerDomain {
    public static void Add(GameContext ctx) {

        GameConfigTM tm = ctx.templateContext.gameConfig;

        PlayerEntity player = ctx.playerEntity;

        player.plantManifestTypeIDs = tm.plantManifestTypeIDs;


    }
}