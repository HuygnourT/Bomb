using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private StatCharacter statCharacter;

    Queue<GameObject> listBombs = new Queue<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        if(listBombs.Count < statCharacter.MaximumBomb)
        {
            GameObject bombPrefab = Instantiate(bomb, GetPositionSpawnBomb(), Quaternion.identity);
            listBombs.Enqueue(bombPrefab);
            bombPrefab.GetComponent<Bomb>().OnInitWeapon(statCharacter.Strength, statCharacter.WaitTimes);
            Debug.Log("Begin");
            Thread spawn = new Thread(() =>
            {
                Thread.Sleep(((int)statCharacter.WaitTimes * 1000));
                listBombs.Dequeue();
                 
                Debug.Log("End");
            });
            spawn.Start();

        }
    }  

    // Return position nearest 
    private Vector3 GetPositionSpawnBomb()
    {
        Vector3 position = transform.position;

        float posX = 0, posY = 0;

        if(Mathf.Round(position.x) > position.x)
        {
            posX = Mathf.Round(position.x) - 0.5f;
        }
        else
        {
            posX = Mathf.Round(position.x) + 0.5f;
        }

        if (Mathf.Round(position.y) > position.y)
        {
            posY = Mathf.Round(position.y) - 0.5f;
        }
        else
        {
            posY = Mathf.Round(position.y) + 0.5f;
        }

        position = new Vector3(posX, posY, position.z);

        return position;
    }

}

