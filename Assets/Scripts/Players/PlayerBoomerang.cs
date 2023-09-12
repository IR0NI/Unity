using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;

    private void OnEnable()
    {
        if (GameManager.instance.BoomerangLevel < 3)
        {
            Invoke("Deactive", 10.0f);
        }else if(GameManager.instance.BoomerangLevel >= 3)
        {
            Invoke("Deactive", 30.0f);
        }
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(GameManager.instance.BoomerangLevel >= 3)
        {
            transform.localScale = new Vector3(3, 3, 0);
        }
    }
    void Update()
    {
        lastVelocity = rigid.velocity;
        transform.Rotate(Vector3.back * 250.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float ran = Random.Range(-0.5f, 0.5f);
            if (GameManager.instance.BoomerangLevel < 2)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(100+Player.instance.AP*0.5f);
            }
            else if (GameManager.instance.BoomerangLevel >= 2)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(200 + Player.instance.AP);
            }
            
            var speed = lastVelocity.magnitude;
            var dir = Vector2.Reflect(lastVelocity.normalized, lastVelocity.normalized);
            var dir2 = new Vector2(ran, ran);
            var dir3 = dir + dir2;
            rigid.velocity = dir3 * Mathf.Max(speed, 0f);
        }
    }
    
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
