using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private float gravity;

    [SerializeField]
    private SoundManager playerAM;

    [SerializeField]
    private GameObject SplashEffect;


    private Transform _tank;
    private Vector3 _moveDir;
    private Vector3 _rotateDir;
    private float _slowSpeed;

    void Start()
    {
        _slowSpeed = Speed / 2f;
        _tank = GetComponent<Transform>();
        _rotateDir = _tank.eulerAngles;
        _characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        _moveDir.y += gravity * Time.deltaTime;
        
        if (_characterController.isGrounded)
        {
            _moveDir = _tank.forward * vertical * Speed * Time.deltaTime;
        }
        _characterController.Move(_moveDir);
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _rotateDir.y += horizontal * RotateSpeed * Time.deltaTime;

        SoundControl(Mathf.Max(Mathf.Abs(_moveDir.x), Mathf.Abs(horizontal)));

        _tank.eulerAngles = _rotateDir;
    }
    public void SlowDown()
    {
        if(Speed != _slowSpeed)
        {
            Destroy(Instantiate(SplashEffect, transform.position, transform.rotation), 2f);
        }
        Speed = _slowSpeed;
    }
    public void SpeedUp()
    {
        Speed = _slowSpeed*2;
    }
    void SoundControl(float moveValue)
    {
        if(moveValue != 0)
        {
            playerAM.Play("Motor");

        }
        else
        {
            playerAM.Pause("Motor");
        }
    }
}
