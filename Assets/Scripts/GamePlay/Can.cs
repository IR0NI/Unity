using UnityEngine;

public class Can : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.UpgradeMenuOn();
            gameObject.SetActive(false);
        }
    }
}
