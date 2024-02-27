using System;
using UnityEngine;

public class BulletEntity : MonoBehaviour {

    public int id;

    public int typeID;

    public int damage;

    public float moveSpeed;


    public Vector2[] path;

    public int pathIndex;


    public SpriteRenderer sp;





    public void Ctor() {
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Init(Sprite sprite) {
        this.sp.sprite = sprite;
    }

    public void Move(float x,float dt) {

        Vector3 pos = this.transform.position;
        pos.x += x * moveSpeed * dt;
        this.transform.position = pos;
    }
    

     public void MoveBy(Vector2 dir, float fixdt) {
        Vector2 pos = transform.position;
        pos -= dir * moveSpeed * fixdt;
        transform.position = pos;
    }


}