using UnityEngine;

public class Darken : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float darktime = 0.0f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (darktime < 600)
        {
            darktime += Time.deltaTime;
        }
        spriteRenderer.color = new Color(0, 0, 0, darktime*0.0008333f);
    }
}
