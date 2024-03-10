using System;
using UnityEngine;

public class CellEntity : MonoBehaviour {
    public int id;

    public Vector2 pos;

    public Vector2 size;

    public int line;

    public bool isHaveMst;

    public void Ctor() { }

    public CellEntity() { }

    public void SetPos(Vector2 pos) {
        this.pos = pos;
        transform.position = pos;
    }

    public void Init() {

        size = new Vector2(0.5f, 0.5f);
    }
}