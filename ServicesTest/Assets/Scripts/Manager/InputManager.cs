using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static public InputManager instance = null;
    private InterfaceInput input;

    private bool fire;

    void Awake()
    {
        instance = this;

#if UNITY_EDITOR
        input = new InputTouchscreen();
#elif UNITY_STANDALONE_WIN
        input = new InputKeyboard();
#elif UNITY_ANDROID
        input = new InputTouchscreen();
#endif

    }

    public Vector3 Movement()
    {
        return input.Movement();
    }
}