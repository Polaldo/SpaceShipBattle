using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;

public class PlayerShipBehaviour : SpaceShipBehaviour
{
    private PlayerShipData _playerShipData;
    [SerializeField] Animator _engineAnimator;
    [SerializeField] float speed;
    Vector2 moveDir;

    protected override void Start()
    {
       base.Start();
       _playerShipData = PlayerManager.Instance.shipData;
       speed = _playerShipData.speed;
    }

    private void FixedUpdate()
    {
        MoveShip();
        SetValuesAnimation();
    }

    private void MoveShip()
    {
        moveDir = InputManager.Instance.GetInputMovePlayer().normalized;   
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }

    private void SetValuesAnimation()
    {
        _engineAnimator.SetFloat("Moving", moveDir.magnitude);
    }
    
}
