using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Taping : MonoBehaviour, IPointerDownHandler
{
    public MiniSpawner miniSpawner;
    public int multyplier;
    public List<GameObject> objects = new List<GameObject>();
    

    public void Start()
    {
        objects = miniSpawner.spriteList;
    }

    public void OnPointerDown(PointerEventData eventData)
    {       
        for(int i = 0; i < multyplier; i++)
        {
            ActiveMiniMask();
        }
    }

    public void ActiveMiniMask()
    {
        
        if (objects.Count > 0)
        {
            int randomIndex = Random.Range(0, objects.Count);
            objects[randomIndex].SetActive(true);
            objects.RemoveAt(randomIndex);
        }
        else
        {
            objects = miniSpawner.spriteList;
            miniSpawner.SwicherOff();
            miniSpawner.MoveNext();
            ActiveMiniMask();
        }
    }
}
