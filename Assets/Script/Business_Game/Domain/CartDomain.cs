using System;
using UnityEngine;


public static class CartDomain {
    public static CartEntity Spawn(GameContext ctx, Vector2 pos) {

        ctx.assetsContext.Entity_TryGetPrefab("Entity_Cart", out GameObject prefab);
        if (prefab == null) {
            Debug.LogError("prefab is null");
        }
        CartEntity cartEntity = GameObject.Instantiate(prefab).GetComponent<CartEntity>();
        if (cartEntity == null) {
            Debug.LogError("cartEntity is null");
        }
        cartEntity.Ctor();
        cartEntity.SetPos(pos);
        cartEntity.Init();
        cartEntity.id = ctx.cartID++;
        ctx.cartRepository.Add(cartEntity);

        return cartEntity;
    }
}
