using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    private WaypointSwitcher _switcher;
    public Transform spawnPointFirst;
    public Transform spawnPointSecond;
    public Transform spawnPointThird;
    public Image healthBar;
    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;
    private int lives;
    private int lives2;

    public Text WaveCountdownText;

    private int waveIndex = 0;

    private void Awake()
    {
        EnemiesAlive = 0;
        countdown = timeBetweenWaves;
        lives = PlayerStats.Lives;
    }

    private void Update()
    {
        if (lives2 == 0)
        {
            Debug.Log("НУЛЬ!!!!");
            healthBar.fillAmount = 0;
        }
        lives2 = PlayerStats.Lives;
        
        healthBar.fillAmount = (float)lives2 / lives;

        
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        
        if(WaveCountdownText != null)WaveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    public IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            int value = UnityEngine.Random.Range(1, 4);
            switch (value)
            {
                case 1:
                    if ((path1[0] != null))
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path1);
                    }

                    if (path2[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path2);
                    }
                    
                    if (path3[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path3);
                    }
                    break;
                case 2:
                    
                    if (path2[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path2);
                    }
                    
                    if (path3[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path3);
                    }
                    if ((path1[0] != null))
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path1);
                    }

                    break;
                case 3:
                    if (path3[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path3);
                    }
                    if ((path1[0] != null))
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path1);
                    }

                    if (path2[0] != null)
                    {
                        SpawnEnemy(wave.enemy, spawnPointFirst, path2);
                    }
                    break;
            }
            
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level WON");
            this.enabled = false;
        }
        

    }

    private void SpawnEnemy(GameObject enemy, Transform spawnPoint,Transform[] path)
    {
        var _enemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        ++EnemiesAlive;
        _enemy.GetComponent<EnemyMovement>().SetPath(path);
    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}