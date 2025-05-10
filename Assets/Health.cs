using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    public int maxHealth = 20;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    Color ogColor;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    SlashHitbox slash = collision.GetComponent<SlashHitbox>();
        if (slash != null) {
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if (enemy != null) {
                TakeDamage(enemy.damage);
            }
        }
    }

    public void TakeDamage(int damage){
        if(currentHealth > 1){
            currentHealth -= damage;
            StartCoroutine(FlashWhite());
        }
        else if(currentHealth <= 1){
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private IEnumerator FlashWhite(){
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = ogColor;
    }
}
