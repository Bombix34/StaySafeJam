using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform player;


    private Vector3 GetPointOutOfBounds()
    {
        Vector2 playerPos = player.position;
        Camera curCamera = Camera.main;
        float height = curCamera.orthographicSize + 2;
        float width = curCamera.orthographicSize * curCamera.aspect + 2;
        float randomPosX = 0f;
        float randomPosY=0f;
        int randVal = (int)Random.Range(0f, 3.999999f);
        if (randVal==0)
        {
            //Droite
            randomPosX = player.position.x + width;
            randomPosY = player.position.y + Random.Range(-height * 1.2f, height * 1.2f);
            
        }
        else if(randVal==1)
        {
            //Gauche
            randomPosX = player.position.x - width;
            randomPosY = player.position.y + Random.Range(-height * 1.2f, height * 1.2f);
        }
        else if(randVal==2)
        {
            //Haut
            randomPosX = player.position.x + Random.Range(-width * 1.2f, width * 1.2f);
            randomPosY = player.position.y + height;
        }
        else if(randVal==3)
        {
            //Bas
            randomPosX = player.position.x + Random.Range(-width * 1.2f, width * 1.2f);
            randomPosY = player.position.y - height;
        }
        return new Vector3(randomPosX,randomPosY,0f);
    }
}
