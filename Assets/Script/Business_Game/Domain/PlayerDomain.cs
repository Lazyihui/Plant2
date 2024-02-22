using UnityEngine;
public static class PlayerDomain {
    public static void AddSun(GameContext ctx, int sun) {
        ctx.playerEntity.sun += sun;
    }
}