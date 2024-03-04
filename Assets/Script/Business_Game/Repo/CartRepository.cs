using System;

using System.Collections.Generic;



public class CartRepository {

    Dictionary<int, CartEntity> all;

    CartEntity[] temArray;

    public CartRepository() {
        all = new Dictionary<int, CartEntity>();
        temArray = new CartEntity[1000];
    }

    public void Add(CartEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(CartEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out CartEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new CartEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<CartEntity> Action<>
    public CartEntity Find(Predicate<CartEntity> predicate) {
        foreach (CartEntity cart in all.Values) {
            bool isMatch = predicate(cart);

            if (isMatch) {
                return cart;
            }
        }
        return null;
    }

}
