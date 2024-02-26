using System;
using UnityEngine;

public class PlantEntity : MonoBehaviour {

    public int id;
    public int typeID;
    public string plantName;
    public string plantPrice;

    public bool isPlanted;

    public SpriteRenderer sp;

    public Vector2 shapeSize;


    public void Ctor() { }

    public void Init(int typeID, Sprite sprite, string plantName, string plantPrice, Vector2 shapeSize) {

        this.typeID = typeID;
        this.sp.sprite = sprite;
        this.plantName = plantName;
        this.plantPrice = plantPrice;
        this.shapeSize = shapeSize;

    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}