using UnityEngine;

public class PlayerAxe : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back * 150.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(250 + Player.instance.AP * 1.2f);
        }
    }
}
