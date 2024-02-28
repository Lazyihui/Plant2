using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Bullet", menuName = "Template/TM_Bullet")]
public class BulletTM : ScriptableObject {

    public int typeID;

    public int damage;

    public float moveSpeed;

    public Vector2[] path;

    public Sprite sprite;

    public Vector2 shapeSize;



}