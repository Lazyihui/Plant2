using UnityEngine;

public class BaseEntity : MonoBehaviour {
    public int id;

    public float cd;

    public float maxCd;

    public float maintain;
    public float maintainTimer;

    public float interval;

    public float intervalTimer;
    //构造
    public void Ctor() { }

    public void Init() {
        id = 0;
        cd = 5;
        maxCd = 5;
        maintain = 3;
        maintainTimer = 3;
        interval = 1;
        intervalTimer = 1;
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
}