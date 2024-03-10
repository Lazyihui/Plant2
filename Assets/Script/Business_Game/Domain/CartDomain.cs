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
    public static void UnSpawn(GameContext ctx, CartEntity cart) {
        ctx.cartRepository.Remove(cart);
        cart.tearDown();
    }

    public static void Move(CartEntity cart, Vector2 dir, float fixdt) {
        cart.Move(dir, fixdt);
    }
    public static void OverLapMst(GameContext ctx, CartEntity cart, float fixdt) {

        MstEntity target = ctx.mstRepository.Find((mst) => {
            float dirSqr = Vector2.SqrMagnitude(mst.transform.position - cart.transform.position);

            if (dirSqr < 0.01f) {
                return true;
            } else {
                return false;
            }
        });

        if (target != null) {
            cart.isMove = true;
            MstDomain.UnSpawn(ctx, target);
        }

    }

}
