using UnityEngine;

public class BaseEntity : MonoBehaviour {
    public int id;

    public float cd;

    public float maxCd;

    public float maintain;
    public float maintainTimer;

    public float interval;

    public float intervalTimer;

    public Vector2[] path;
    //构造
    public void Ctor() { }

    public void Init() {
        id = 0;

        cd = 1;
        maxCd = 1;

        maintain = 3;
        maintainTimer = 3.01f;

        interval = 1;
        intervalTimer = 1;

        path = new Vector2[]{new Vector2(-8, 0)};
    }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
}