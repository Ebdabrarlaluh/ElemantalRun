using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Blok türlerini içeren dizi
    public Transform blockParent; // Blokların alt objelerini tutacak üst obje
    public float blockSpacing = 1.0f; // Bloklar arası boşluk
    public int elementSize=4;

    public static GameObject[] blockInGame;



    void Start()
    {
        blockInGame = new GameObject[elementSize];

        for (int i = 0; i < elementSize; i++)
        {
            CreateBlock(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (blockInGame[0] == null)
        {
            
            for (int i = 0; i < blockInGame.Length - 1; i++)
            {
                blockInGame[i] = blockInGame[i + 1];
                ReCoordinate(i);
            }
            CreateBlock(blockInGame.Length-1);
        }
    }
    void ReCoordinate(int i)
    {
        blockInGame[i].transform.position += new Vector3(-blockSpacing, 0, 0);
    }
    void CreateBlock(int i)
    {
        Vector3 blockPosition = new Vector3(blockParent.position.x + i * blockSpacing, blockParent.position.y, blockParent.position.z);
        GameObject newBlock = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], blockPosition, Quaternion.identity);
        blockInGame[i] = newBlock;
        blockInGame[i].transform.SetParent(blockParent); // Oluşturulan bloğu üst objeye bağla
    }
}
