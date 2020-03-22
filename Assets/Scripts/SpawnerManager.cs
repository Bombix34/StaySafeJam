using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    public Transform player;
    public GameObject cellPrefab;
    public Vector2 timeBetweenSpawn;
    private float curChrono;

    private List<GameObject> currentCells;

    private void Start()
    {
        currentCells = new List<GameObject>();
        curChrono = Random.Range(timeBetweenSpawn.x, timeBetweenSpawn.y);
    }

    private void Update()
    {
        if(curChrono>0)
        {
            curChrono -= Time.deltaTime;
        }
        else
        {
            curChrono = Random.Range(timeBetweenSpawn.x, timeBetweenSpawn.y);
            SpawnCell();
        }
    }

    private void SpawnCell()
    {
        GameObject newCell = Instantiate(cellPrefab, GetPointOutOfBounds(), Quaternion.identity, this.transform);
        currentCells.Add(newCell);
        float playerScale = player.transform.localScale.x;
        float randScale = Random.Range(Mathf.Clamp(playerScale - PlayerManager.Instance.GetAdaptedValue(10f),0f,playerScale), playerScale);
        newCell.GetComponent<CellManager>().InitScale(randScale,1.2f);
        InitVelocity(newCell);
    }

    public void InitVelocity(GameObject cell)
    {
        float speed = PlayerManager.Instance.GetComponent<MovementController>().CurSpeed * Random.Range(0.2f, 1.2f);
        cell.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
    }

    private Vector3 GetPointOutOfBounds()
    {
        Vector2 playerPos = player.position;
        Camera curCamera = Camera.main;
        float height = curCamera.orthographicSize + 2;
        float width = curCamera.orthographicSize * (curCamera.aspect + 2);
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

    public void ClearCells()
    {
        foreach(var item in currentCells)
        {
            Destroy(item.gameObject);
        }
    }

    public List<GameObject> CurrentCells
    {
        get => currentCells;
    }
}
