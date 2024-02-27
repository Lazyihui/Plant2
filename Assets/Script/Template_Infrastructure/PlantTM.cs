using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Plant", menuName = "Template/TM_Plant")]
public class PlantTM : ScriptableObject {
    [Header("Plant")]

    public int typeID;
    public string plantName;
    public string plantPrice;

    [Header("Spawner")]

    public bool isSpawner;

    public float cd;


    public float maintain;

    public float interval;

    public int BulletTypeID;

    public Vector2 bulletPos;

    public Vector2[] path;


    [Header("Sprite")]
    public Sprite sprite;

    public Vector2 plantPos;

    public Vector2 shapeSize;


}