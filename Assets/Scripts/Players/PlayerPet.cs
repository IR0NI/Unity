using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * 40.0f * Time.deltaTime);
        if (Player.instance.len.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (Player.instance.len.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
