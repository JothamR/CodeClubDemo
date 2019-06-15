using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _body;

    public float speed = 5.0f;

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
        //Move
        _body.MovePosition(_body.position + GamePad.Direction * speed * Time.fixedDeltaTime);
    }
}
