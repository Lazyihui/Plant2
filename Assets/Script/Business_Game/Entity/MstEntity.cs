using UnityEngine;

public class MstEntity : MonoBehaviour {

    public  int id;

    public void Ctor() { }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}