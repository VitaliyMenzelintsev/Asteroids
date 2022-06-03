using System.Collections;
using UnityEngine;

public class BorderCrossing 
{
    // Размеры экрана
    private float screenTopBorder = 8.6f;
    private float screenBottomBorder = -8.6f;
    private float screenRightBorder = 14.5f;
    private float screenLeftBorder = -14.5f;

    public Vector2 UpdateBorder(Vector2 currentPosition)             
    {
        Vector2 newPosition = currentPosition;

        if (currentPosition.y > screenTopBorder) newPosition.y = screenBottomBorder;

        if (currentPosition.y < screenBottomBorder) newPosition.y = screenTopBorder;

        if (currentPosition.x > screenRightBorder) newPosition.x = screenLeftBorder;

        if (currentPosition.x < screenLeftBorder) newPosition.x = screenRightBorder;

        return newPosition;    // обновление положения каждое значение refreshRate 

    }
}
