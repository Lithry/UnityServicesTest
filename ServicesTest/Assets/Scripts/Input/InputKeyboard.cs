using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : InterfaceInput {
    private Vector3 direction;
    public Vector3 Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.z = 0;

        if (direction.magnitude > 1)
            return Vector3.Normalize(direction);
        else
            return direction;
    }
}
