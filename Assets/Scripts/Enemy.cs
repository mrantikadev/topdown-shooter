using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    [SerializeField] int health;
    [SerializeField] GameObject enemyDeathEffect;
    [SerializeField] GameObject playerDeathEffect;
    [SerializeField] float speed;
    Transform playerPos;
    PlayerController player;

    private void Start() {
        playerPos = FindAnyObjectByType<PlayerController>().transform;
    }

    private void Update() {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Projectile") {
            TakeDamage(collision.GetComponent<Projectile>().projectileDamageAmount);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Player") {
            Instantiate(playerDeathEffect, playerPos.position, Quaternion.identity);
            Invoke("GoToMainMenu", 0.5f);
        }
    }

    private void Movement() {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
