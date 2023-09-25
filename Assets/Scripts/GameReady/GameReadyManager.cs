using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReadyManager : MonoBehaviour
{
    public static GameReadyManager instance;
    public int GunNum = 0;
    public int SecondWeaponNum = 0;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SelectGun(int num)
    {
        GunNum = num;
    }

    public void SelectSecondWeapon(int num)
    {
        SecondWeaponNum = num;
    }
}
