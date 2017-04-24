using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchscreen : InterfaceInput {
    private Vector3 direction;
    private Vector3 mousePosition;
    
    public Vector3 Movement() {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (mousePosition.x > 0.5)
            {
                direction.Set(1, 0, 0);
            }
            else
                direction.Set(-1, 0, 0);
        }
        else
            direction.Set(0, 0, 0);


        return direction;
    }
}
