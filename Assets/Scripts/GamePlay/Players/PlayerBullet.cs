using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    /*public float distance;
    public LayerMask isLayer;*/
    //������Ѿ��ϳ��� ������ �����°� ����
    public bool touch = false;
    private void OnEnable()
    {
        touch = false;
        CancelInvoke();
        Invoke("Deactive", Player.instance.BulletTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.instance.HitBullet > 0.01f)



            if (!touch)
            collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
            touch = true;
            if (collision.GetComponent<Enemy>().HP >= 0)
            {
                Deactive();
            }

        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
