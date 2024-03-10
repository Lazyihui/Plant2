using System;
using UnityEngine;

public class CartEntity : MonoBehaviour {
    public int id;

    public float speed;

    public bool isMove;

    public void Ctor() {

    }

    public void tearDown() {
        GameObject.Destroy(gameObject);
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Init() {
        speed = 2.0f;
        isMove = false;
    }


    public void Move(Vector2 dir, float fixdt) {
        Vector2 pos = transform.position;
        pos += dir * speed * fixdt;
        transform.position = pos;
    }

}