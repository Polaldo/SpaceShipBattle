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
    Camera _camera;
    [SerializeField] float _offSet;

    protected override void Start()
    {
       base.Start();
       _playerShipData = PlayerManager.Instance.shipData;
       speed = _playerShipData.speed;
       _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        MoveShip();
        SetValuesAnimation();
    }

    private void MoveShip()
    {
        moveDir = InputManager.Instance.GetInputMovePlayer().normalized;
        rb.velocity = moveDir * speed;
        PreventPlayerGoOutOffScreen();
    }

    private void SetValuesAnimation()
    {
        _engineAnimator.SetFloat("Moving", moveDir.magnitude);
    }

    private void PreventPlayerGoOutOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _offSet && rb.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _offSet && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if ((screenPosition.y < _offSet && rb.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _offSet && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    
}
