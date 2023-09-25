using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagedText : MonoBehaviour
{
    public float MoveSpeed;
    public float AlphaSpeed;
    TextMeshPro text;
    Color alpha;
    public float damage;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        Invoke("Destroy", 2);
    }

    private void OnEnable()
    {
        alpha.a = 1;
        Invoke("Destroy", 2);
    }

    void Update()
    {

        text.text = damage.ToString();
        transform.Translate(new Vector3(0, MoveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * AlphaSpeed);
        text.color = alpha;

    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
