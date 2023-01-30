using UnityEngine;
using System.Collections.Generic;

public abstract class Spawner : MonoBehaviour
{
    public GameObject spritePrefab;
    public int rows = 5;
    public int columns = 5;
    public float spacing = 0f;
    public List<GameObject> spriteList = new List<GameObject>();
    private Queue<GameObject> spritePool = new Queue<GameObject>();
    
    public virtual void Spawn()
    {
        float spriteWidth = spritePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x * spritePrefab.transform.localScale.x;
        float spriteHeight = spritePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y * spritePrefab.transform.localScale.y;
        float matrixWidth = spriteWidth * columns + (columns - 1) * spacing;
        float matrixHeight = spriteHeight * rows + (rows - 1) * spacing;

        float halfWidth = matrixWidth / 2f;
        float halfHeight = matrixHeight / 2f;

        for (int i = 0; i < rows * columns; i++)
        {
            GameObject sprite = Instantiate(spritePrefab, transform);
            sprite.SetActive(false);
            spritePool.Enqueue(sprite);
        }

        for (int row = rows - 1; row >= 0; row--)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject sprite = spritePool.Dequeue();
                sprite.transform.localPosition = new Vector3(column * (spriteWidth + spacing) - halfWidth + spriteWidth / 2f, 
                                                        row * (spriteHeight + spacing) - halfHeight + spriteHeight / 2f);
                spriteList.Add(sprite);
            }
        }  
    }
}
