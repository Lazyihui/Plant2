using System;

using UnityEngine;

//TM 称为配置表

[CreateAssetMenu(fileName = "TM_Bases", menuName = "Template/TM_Bases")]
public class BasesTM : ScriptableObject {
    [Header("bases")]
    public int TypeID;
    public string typeName;

    [Header("Spawner")]

    public bool isSpawner;

    public float cd;


    public float maintain;

    public float interval;

    public int mstTypeID;

    public Vector2[] path;

    public Vector2 pos;



}
