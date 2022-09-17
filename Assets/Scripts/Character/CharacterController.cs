using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float _playerInput;
    private bool _userJumped;

    private const float _inputScale = 0.5f;
    
    private Rigidbody _rigidBody;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Horizontal");
        _userJumped = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity += transform.forward * _playerInput * _inputScale;

        if(_userJumped) 
        {
            _rigidBody.AddForce(Vector3.up, ForceMode.VelocityChange);
            _userJumped = false;
        }
    } 
}
