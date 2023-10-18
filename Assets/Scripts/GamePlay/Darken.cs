using UnityEngine;

public class Darken : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.instance.PlayTime < 600)
        {
            spriteRenderer.color = new Color(0, 0, 0, GameManager.instance.PlayTime * 0.0008333f);
        }
    }
}
