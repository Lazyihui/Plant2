using UnityEngine;


//点和矩形的检测
public static class PFPhysics {

    public static bool IsPointInsideRectangle(Vector2 aPos, Vector2 bPos, Vector2 bSize) {
        float halfW = bSize.x / 2;
        float halfH = bSize.y / 2;
        float left = bPos.x - halfW;
        float right = bPos.x + halfW;
        float top = bPos.y + halfH;
        float bottom = bPos.y - halfH;
        return aPos.x >= left && aPos.x <= right && aPos.y >= bottom && aPos.y <= top;
    }

    // 圆和圆的交叉检测
    public static bool IsCircleCrossCircle(Vector2 aPos, float aRadius, Vector2 bPos, float bRadius) {

        float dis = (aPos - bPos).sqrMagnitude;
        float r = aRadius + bRadius;
        return dis <= r * r;
        
    }
}