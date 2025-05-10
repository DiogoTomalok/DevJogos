using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public int maxHealth = 20;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    Color ogColor;
    public Animator animator;
    public Transform player;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogColor = spriteRenderer.color;
        animator.SetFloat("EnemyHealth", currentHealth);
    }

    // Update is called once per frame
    void Update(){
        float direction = Mathf.Sign(player.position.x - transform.position.x);
    }

    public void TakeDamage(int damage){
        if(currentHealth > 0){
            currentHealth -= damage;
            animator.SetFloat("EnemyHealth", currentHealth);
            StartCoroutine(FlashWhite());
        }
    }

    private IEnumerator FlashWhite(){
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = ogColor;
    }
}
