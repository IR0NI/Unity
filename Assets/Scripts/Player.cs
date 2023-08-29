using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Vector3 moveDirectionX = Vector3.zero;
    private float moveSpeed = 100.0f;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }

    
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirectionX = new Vector3(x, y, 0).normalized;
        transform.position += moveDirectionX * moveSpeed * 0.05f * Time.deltaTime;
    }
}
