using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject PlayerBulletPrefab;
    public GameObject PlayerExplosionPrefab;
    public GameObject Enemy1_1Prefab;
    public GameObject Enemy1_2Prefab;
    public GameObject Enemy1_3Prefab;
    public GameObject Enemy1_1BulletPrefab;
    public GameObject Enemy1_2BulletPrefab;
    public GameObject Enemy1_3BulletPrefab;

    GameObject[] PlayerBullet;
    GameObject[] PlayerExplosion;
    GameObject[] Enemy1_1;
    GameObject[] Enemy1_2;
    GameObject[] Enemy1_3;
    GameObject[] Enemy1_1Bullet;
    GameObject[] Enemy1_2Bullet;
    GameObject[] Enemy1_3Bullet;
    GameObject[] targetPool;

    void Awake()
    {
        Enemy1_1 = new GameObject[100];
        Enemy1_2 = new GameObject[50];
        Enemy1_3 = new GameObject[50];
        Enemy1_1Bullet = new GameObject[100];
        Enemy1_2Bullet = new GameObject[50];
        Enemy1_3Bullet = new GameObject[50];
        PlayerBullet = new GameObject[70];
        PlayerExplosion = new GameObject[30];

        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < Enemy1_1.Length; index++)
        {
            Enemy1_1[index] = Instantiate(Enemy1_1Prefab);
            Enemy1_1[index].SetActive(false);
        }

        for (int index = 0; index < Enemy1_2.Length; index++)
        {
            Enemy1_2[index] = Instantiate(Enemy1_2Prefab);
            Enemy1_2[index].SetActive(false);
        }

        for (int index = 0; index < Enemy1_3.Length; index++)
        {
            Enemy1_3[index] = Instantiate(Enemy1_3Prefab);
            Enemy1_3[index].SetActive(false);
        }

        for (int index = 0; index < Enemy1_1Bullet.Length; index++)
        {
            Enemy1_1Bullet[index] = Instantiate(Enemy1_1BulletPrefab);
            Enemy1_1Bullet[index].SetActive(false);
        }

        for (int index = 0; index < Enemy1_2Bullet.Length; index++)
        {
            Enemy1_2Bullet[index] = Instantiate(Enemy1_2BulletPrefab);
            Enemy1_2Bullet[index].SetActive(false);
        }

        for (int index = 0; index < Enemy1_3Bullet.Length; index++)
        {
            Enemy1_3Bullet[index] = Instantiate(Enemy1_3BulletPrefab);
            Enemy1_3Bullet[index].SetActive(false);
        }

        for (int index = 0; index < PlayerBullet.Length; index++)
        {
            PlayerBullet[index] = Instantiate(PlayerBulletPrefab);
            PlayerBullet[index].SetActive(false);
        }

        for (int index = 0; index < PlayerExplosion.Length; index++)
        {
            PlayerExplosion[index] = Instantiate(PlayerExplosionPrefab);
            PlayerExplosion[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "PlayerBullet":
                targetPool = PlayerBullet;
                break;

            case "PlayerExplosion":
                targetPool = PlayerExplosion;
                break;

            case "Enemy1_1":
                targetPool = Enemy1_1;
                break;

            case "Enemy1_2":
                targetPool = Enemy1_2;
                break;

            case "Enemy1_3":
                targetPool = Enemy1_3;
                break;

            case "Enemy1_1Bullet":
                targetPool = Enemy1_1Bullet;
                break;

            case "Enemy1_2Bullet":
                targetPool = Enemy1_2Bullet;
                break;

            case "Enemy1_3Bullet":
                targetPool = Enemy1_3Bullet;
                break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }


}
