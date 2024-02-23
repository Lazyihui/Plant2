using System;

using UnityEngine;

//TM 称为配置表

[CreateAssetMenu(fileName = "TM_Mst", menuName = "Template/TM_Mst")]
public class MstTM : ScriptableObject {
    public int TypeID;
    public float moveSpeed;

    public Sprite sprite;
}

