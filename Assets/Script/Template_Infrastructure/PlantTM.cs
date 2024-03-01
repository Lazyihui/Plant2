using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Plant", menuName = "Template/TM_Plant")]
public class PlantTM : ScriptableObject {
    [Header("Plant")]

    public int typeID;
    public string plantName;
    public string plantPrice;

    public int sun;

    [Header("Spawner")]



    public float cd;


    public float maintain;

    public float interval;

    public int bulletTypeID;


    [Header("Sprite")]
    public Sprite sprite;

    public Vector2 plantPos;


    // 好像没用
    public Vector2 shapeSize;

    [Header("bool")]

    public bool isShooter;

    public bool isSun;

    public bool isShovel;

    public bool isDisposable;


}