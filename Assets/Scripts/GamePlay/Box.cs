using UnityEngine;

public class Box : MonoBehaviour
{
    public float HP = 50;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (HP <= 0)
        {
            GameObject Can = GameManager.instance.pool.Get(5);
            Can.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    public void Takedamage(float dmg)
    {
        HP -= dmg;
        animator.SetBool("Takedamage", true);
        Invoke("Idlebox", 0.3f);
    }

    private void Idlebox()
    {
        animator.SetBool("Takedamage", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Takedamage(Player.instance.AD);
        }

        if(collision.gameObject.tag == "PlayerAttack")
        {
            switch (GameReadyManager.instance.SecondWeaponNum)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
    }
}
