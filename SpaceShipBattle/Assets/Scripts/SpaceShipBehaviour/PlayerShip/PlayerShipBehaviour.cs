using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;

public class PlayerShipBehaviour : SpaceShipBehaviour
{
    private PlayerShipData _playerShipData;
    [SerializeField] GameObject _baseShip;
    [SerializeField] GameObject _engineShip;
    [SerializeField] GameObject _primaryWeaponShip;  
    [SerializeField] Animator _engineAnimation;
    [SerializeField] float speed;
    float targetSpeed;
    Vector2 moveDir;

    protected override void Start()
    {
       base.Start();
       _playerShipData = PlayerManager.Instance.shipData;
        //SpriteRenderer u = _baseShip.GetComponent<SpriteRenderer>();
         //  u.sprite = _playerShipData.baseShip;
       speed = _playerShipData.speed;
    }

    void Update()
    {
        
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
        _engineAnimation.SetFloat("Moving", moveDir.magnitude);
    }
    
}
