using UnityEngine;

public class MstEntity : MonoBehaviour {

    public int id;
    public float moveSpeed;

    public Vector2[] path;

    public int pathIndex;

    public SpriteRenderer spriteRenderer;


    public void Ctor() { }

    public void Init(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }
    public void tearDown() {
        GameObject.Destroy(gameObject);
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
    public void Move(Vector2 dir, float fixdt) {
        Vector2 pos = transform.position;
        pos += dir * moveSpeed * fixdt;
        transform.position = pos;
    }
}