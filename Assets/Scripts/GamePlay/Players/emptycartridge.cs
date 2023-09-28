using UnityEngine;

public class emptycartridge : MonoBehaviour
{
    private Rigidbody2D rigid;
    private void OnEnable()
    {
        float ran = Random.Range(1.0f, 2.0f);
        rigid = GetComponent<Rigidbody2D>();
        CancelInvoke();
        Invoke("Stop", ran);
        Invoke("Deactive", 2);
    }
    private void Stop()
    {
        rigid.velocity = Vector3.zero;
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
