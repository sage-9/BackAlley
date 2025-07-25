using System;
using Managers;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    float _currentSpeed;
    private CharacterController _characterController;

    void Awake()
    {
        GameSceneManager.Play += ResumeMoving;
        GameSceneManager.Pause += StopMoving;
        GameSceneManager.GameOver += StopMoving;
    }

    private void OnDisable()
    {
        GameSceneManager.Play -= ResumeMoving;
        GameSceneManager.Pause -= StopMoving;
        GameSceneManager.GameOver -= StopMoving;
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Destroy(gameObject, 20f);
        _currentSpeed = speed;
    }

    void Update()
    {
        _characterController.Move(transform.forward * (_currentSpeed * Time.deltaTime));
    }

    void ResumeMoving()
    {
        _currentSpeed = speed;
    }

    void StopMoving()
    {
        _currentSpeed= 0;
    }

}
