using System;
using UnityEngine;

public class CartEntity : MonoBehaviour {
    public int id;

    public float speed;

    public void Ctor() {

    }

    public void tearDown() {
        GameObject.Destroy(gameObject);
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Init() {
        speed = 2f;
    }


    public void Move(Vector2 dir, float fixdt) {
        Vector2 pos = transform.position;
        pos += dir * speed * fixdt;
        transform.position = pos;
    }

}