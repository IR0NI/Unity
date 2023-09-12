using UnityEngine;

public class Enemy1_2Bullet : MonoBehaviour
{
    

    private void OnEnable()
    {
        Invoke("DeActive", 2.0f);
        transform.localScale = new Vector3(0.5f, 100, 1);
        if (transform.GetComponentInParent<Enemy>().Elite == 1 || transform.GetComponentInParent<Enemy>().Elite == 100)
        {
            transform.localScale = new Vector3(5, 100, 1);
        }
        
    }

    private void DeActive()
    {
        
        gameObject.SetActive(false);

    }
    

    
}
