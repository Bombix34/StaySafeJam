using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private PlayerManager player;

    private void Start()
    {
        player = PlayerManager.Instance;
    }

    private void Update()
    {
        this.transform.position = player.transform.position;
        float size= player.GetAdaptedValue(250f);
        this.transform.localScale = new Vector3(size, size, size);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Cell"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
