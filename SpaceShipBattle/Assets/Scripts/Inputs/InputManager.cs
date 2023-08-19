using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public MapInputPlayer inputs;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        inputs = new MapInputPlayer();
        inputs.Ship.Enable();
    }
    public Vector2 GetInputMovePlayer()
    {
        return inputs.Ship.Move.ReadValue<Vector2>();
    }

    public bool GetInputShoot()
    {
        return inputs.Ship.Shoot.IsPressed();
    }
}
