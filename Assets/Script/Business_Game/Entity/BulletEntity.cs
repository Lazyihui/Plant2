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


    public bool isLive;

    public bool isClick;





    public void Ctor() {
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void Init(Sprite sprite) {
        this.sp.sprite = sprite;
    }

    public void MoveX(float dirx,float dt) {

        Vector3 pos = this.transform.position;
        pos.x += dirx * moveSpeed * dt;
        this.transform.position = pos;
    }

    


    public void tearDown() {
        GameObject.Destroy(gameObject);
    }


}