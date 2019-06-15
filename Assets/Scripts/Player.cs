﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5.0f;
    public float Jump = 6f;

    private Rigidbody _body;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Look
        if (GamePad.HasDirection) transform.forward = GamePad.Direction;
    }

    void FixedUpdate()
    {
        FallCheck();
        GroundCheck();

        //Jumping
        if (GamePad.ButtonB && isGrounded)
        {
            _body.velocity = _body.velocity.SetY(Jump);
        }

        //Move
        _body.MovePosition(_body.position + GamePad.Direction * Speed * Time.fixedDeltaTime);
    }

    private void FallCheck()
    {
        if (transform.position.y < -10f)
        {
            Debug.Log("ahhhhh!");
            _body.velocity = Vector3.zero;
            _body.MovePosition(new Vector3(0f, 20f, 0f));
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}
