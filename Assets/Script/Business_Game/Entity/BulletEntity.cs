using System;
using UnityEngine;

public class BulletEntity : MonoBehaviour {

    public int id;

    public int typeID;

    public int damage;

    public float moveSpeed;


    public Vector2[] path;

    public SpriteRenderer sp;





    public void Ctor() {
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Init(Sprite sprite) {
        this.sp.sprite = sprite;
    }

}