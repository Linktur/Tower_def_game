//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    
    
    public float health;
    public float startHealth = 100;

    public int worth = 50;

    public float minimumDistanceCollision = 0.4f;

    public GameObject deathEffect;

    [Header("Unity stuff")] public Image healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    [SerializeField] private AudioClip[] damageSoundClips;
    public void TakeDamage(float amount)
    {
        health -= amount;
        SoundFXManager.instance.PlayRandomSoundFXClip(damageSoundClips, transform, 1f);
        healthBar.fillAmount = health/startHealth;
        if (health <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        --WaveSpawner.EnemiesAlive;

        Destroy(gameObject);
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }
}
