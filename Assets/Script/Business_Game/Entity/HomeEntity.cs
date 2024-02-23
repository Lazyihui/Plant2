using UnityEngine;

public class HomeEntity : MonoBehaviour {

    public int id;

    public int typeID;


    public void Ctor() { }
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
}