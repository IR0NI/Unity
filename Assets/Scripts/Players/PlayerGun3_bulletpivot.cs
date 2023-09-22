using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun3_bulletpivot : MonoBehaviour
{
    public GameObject glass;
    private void OnEnable()
    {
        glass.SetActive(true);
        glass.transform.position = transform.position;
        glass.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z );
        CancelInvoke();
        Invoke("Deactive", 5.0f);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
