using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShipBehaviour : SpaceShipBehaviour
{
    private PlayerShipData _playerShipData;
    [SerializeField] GameObject _baseShip;
    [SerializeField] GameObject _engineShip;
    [SerializeField] GameObject _primaryWeaponShip;
    [SerializeField] float speed;

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
    }
    private void MoveShip()
    {
        rb.MovePosition(rb.position + InputManager.Instance.GetInputMovePlayer().normalized * speed * Time.fixedDeltaTime);
    }
}
