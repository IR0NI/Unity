using UnityEngine;

public class ShopObject : MonoBehaviour
{
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactive", 60.0f);
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0,0,0), 3.0f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShopManager.instance.ItemNumShuffle();
            GameManager.instance.IsPause();
            GameManager.instance.ShopOpen();
            gameObject.SetActive(false);
        }
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
