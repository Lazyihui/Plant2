using UnityEngine;

public class BaseEntity : MonoBehaviour {
    public int id;
    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
}