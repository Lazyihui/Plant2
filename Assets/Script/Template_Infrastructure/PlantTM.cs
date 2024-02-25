using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Plant", menuName = "Template/TM_Plant")]
public class PlantTM : ScriptableObject {

    public int typeID;
    public string plantName;
    public string plantPrice;
    public Sprite sprite;

    public Vector2 pos;

    public Vector2 shapeSize;


}