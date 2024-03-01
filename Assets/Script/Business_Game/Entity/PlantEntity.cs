using System;
using UnityEngine;

public class PlantEntity : MonoBehaviour {

    public int id;
    public int typeID;
    public string plantName;
    public string plantPrice;

    public int sun;

    public bool isPlanted;

    public SpriteRenderer sp;

    public Vector2 shapeSize;


    public float cd;

    public float maxCd;

    public float maintain;

    public float maintainTimer;

    public float interval;

    public float intervalTimer;

    public int bulletTypeID;

    public bool isShooter;

    public bool isSun;

    public bool isShovel;

    public bool isDisposable;




    public void Ctor() { }

    public void Init(int typeID, Sprite sprite, string plantName, string plantPrice, Vector2 shapeSize, float cd, float maxCd, float maintain, float interval) {

        this.typeID = typeID;
        this.sp.sprite = sprite;
        this.plantName = plantName;
        this.plantPrice = plantPrice;
        
        this.shapeSize = shapeSize;
        this.cd = cd;
        this.maxCd = maxCd;
        this.maintain = maintain;

    }

    public void tearDown() {
        Destroy(gameObject);
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}