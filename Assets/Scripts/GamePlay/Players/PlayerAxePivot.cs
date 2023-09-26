using UnityEngine;

public class PlayerAxePivot : MonoBehaviour
{
    private void Update()
    {
        
       transform.Rotate(Vector3.back * GameManager.instance.Axespeed * Time.deltaTime);
       transform.localScale = new Vector3(GameManager.instance.Axerange*2.5f, GameManager.instance.Axerange*2.5f, 0);
                
    }
}
