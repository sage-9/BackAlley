using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        _characterController.Move(transform.forward * (speed * Time.deltaTime));
    }

}
