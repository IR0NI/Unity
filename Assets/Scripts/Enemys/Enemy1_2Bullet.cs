using UnityEngine;

public class Enemy1_2Bullet : MonoBehaviour
{
    

    private void OnEnable()
    {
        Invoke("DeActive", 2.0f);
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }
    

    
}
