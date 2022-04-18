using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartManager : MonoBehaviour
{

    public GameObject[] heartSprites;
    public Player player;
    private GameObject[] renderedHearts;
    public Camera mainCamera;

    float screenWidth;
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = mainCamera.pixelWidth;
        screenHeight = mainCamera.pixelHeight;
        renderedHearts = new GameObject[player.startHp];
        RenderHearts();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = player.startHp-1; i >= 0; i--)
        {
            if(player.GetPlayerHp()-1 < i)
            {
                renderedHearts[i].SetActive(false);
                
            }
        }
    }

    void RenderHearts()
    {
        int drawnHearts = 0;
        Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
        GameObject obj;
        for(int i = 0; i < player.startHp; i++)
        {
            switch (i%2)
            {
                case (0):
                    obj = Instantiate(heartSprites[0], topLeft + new Vector3((heartSprites[i%3].GetComponent<SpriteRenderer>().bounds.size.x + (heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.x * drawnHearts)), -heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.y, 3), Quaternion.Euler(0f, 0f, 0f));
                    obj.transform.parent = mainCamera.transform;

                    obj= renderedHearts[i] = Instantiate(heartSprites[1], topLeft + new Vector3(heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.x + (heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.x * drawnHearts), -heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.y, 2), Quaternion.Euler(0f, 0f, 0f));
                    obj.transform.parent = mainCamera.transform;
                    break;
                case (1):
                    obj = renderedHearts[i] = Instantiate(heartSprites[2], topLeft + new Vector3(heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.x + (heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.x * drawnHearts), -heartSprites[i % 3].GetComponent<SpriteRenderer>().bounds.size.y, 1), Quaternion.Euler(0f, 0f, 0f));
                    obj.transform.parent = mainCamera.transform;
                    drawnHearts += 1;
                    break;
            }
            
        }
    }
}
