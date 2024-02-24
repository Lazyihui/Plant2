using System;
using UnityEngine;

public class plantEntity : MonoBehaviour {

    public int id;
    public int typeID;
    public string plantName;
    public string plantPrice;
    public Sprite sprite;


    public void Ctor() { }

    public void Init(int typeID, Sprite sprite, string plantName, string plantPrice) {
        this.typeID = typeID;
        this.sprite = sprite;
        this.plantName = plantName;
        this.plantPrice = plantPrice;
        
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}