using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FadeInText finalText;
    [SerializeField]
    private GameObject finalObjects;

    private Spawner[] spawners;
    private float timeToWaitBeforeGameFreeze = 2.5f;
    private int score = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        print("awake was called");
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnDied += GameManager_OnDied;
        spawners = FindObjectsOfType<Spawner>(true);
        Zombie.OnZombieDead += HandleZombieDeath;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
    }

    private void SceneManager_sceneUnloaded(Scene arg0)
    {
        Zombie.OnZombieDead -= HandleZombieDeath;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        print("start was called");
        HandleZombieDeath(0);
    }

    private void HandleZombieDeath(int currentDeadZombies)
    {
        score = currentDeadZombies;
        print(string.Format("found {0} spawners", spawners.Length));
        print(string.Format("current dead zombies : {0}", currentDeadZombies));
        foreach (Spawner spawner in spawners)
        {
            if(spawner.deadZombiesToEnable <= currentDeadZombies)
            {
                spawner.gameObject.SetActive(true);
            }
        }
    }

    private void GameManager_OnDied()
    {
        StartCoroutine(FreezeGame());
    }

    private IEnumerator FreezeGame()
    {
        finalText.TextToDisplay = string.Format("You lost!\nYou killed {0} zombies", score);
        finalObjects.SetActive(true);
        yield return new WaitForSeconds(timeToWaitBeforeGameFreeze);
        Time.timeScale = 0;
    }
}
