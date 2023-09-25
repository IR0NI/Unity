using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;

    private void OnEnable()
    {
     Invoke("Deactive", GameManager.instance.Boomerangtime);
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
            collision.gameObject.GetComponent<Enemy>().TakeDamage(GameManager.instance.Boomerangdmg);
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
