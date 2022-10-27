using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private float _groundDistance = 0.4f;
    private bool _isGrounded;

    [SerializeField] private float speed = 12f;
    private float _xInput;
    private float _zInput;

    [SerializeField] private float jumpHeight = 3f;
    
    [SerializeField] private float gravity = 9.81f;

    private Vector3 _movement;
    
    private Vector3 _velocity;

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");

        _movement = transform.right * _xInput + transform.forward * _zInput;

        characterController.Move(_movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }
        
        _velocity.y -= gravity * Time.deltaTime;

        characterController.Move(_velocity * Time.deltaTime);
    }
}
