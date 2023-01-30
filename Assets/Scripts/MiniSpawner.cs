using UnityEngine;
using System.Collections.Generic;
public class MiniSpawner : Spawner
{
    public BigSpawner bigSpawner;
    private byte posId = 0;
    void Start()
    {
        Spawn();
        transform.position = bigSpawner.spriteList[0].transform.position;
    }
  

    public void SwicherOff()
    {
        foreach(Transform child in transform)
        {
            spriteList.Add(child.gameObject);
        }
        foreach(GameObject sprite in spriteList)
        {
            sprite.SetActive(false);
        }
    }

    public void MoveNext()
    {
        bigSpawner.spriteList[posId].SetActive(true);
        posId++;
        transform.position = bigSpawner.spriteList[posId].transform.position;
    }
}
