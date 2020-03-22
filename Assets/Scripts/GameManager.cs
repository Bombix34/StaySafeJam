using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool IsPlayerDead { get; set; } = false;
    private bool launchEnd = false;

    private void Update()
    {
        if(IsPlayerDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                launchEnd = true;
                StartCoroutine(EndGameEffect());
            }
            if(launchEnd)
            {
                Camera.main.orthographicSize += Time.deltaTime *(PlayerManager.instance.GetAdaptedValue( 2f)*1000f);
            }
        }
    }

    private IEnumerator EndGameEffect()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
