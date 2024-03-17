using UnityEngine;

public class InputEntity {
    public Vector2 mouseScreenPos;

    public Vector2 mouseWorldPos;

    public bool isMouseLeftDown;

    public InputEntity() { }

    public void Reset() {
        mouseScreenPos = Vector2.zero;
        mouseWorldPos = Vector2.zero;
        isMouseLeftDown = false;
    }

}