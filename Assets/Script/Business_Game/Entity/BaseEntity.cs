using UnityEngine;

public class BaseEntity : MonoBehaviour {
    public int id;

    public int typeID;

    public float cd;

    public float maxCd;

    public float maintain;
    public float maintainTimer;

    public float interval;

    public float intervalTimer;

    public int mstID;

    public Vector2[] path;
    //构造
    public void Ctor() { }

    public void Init() {
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
}