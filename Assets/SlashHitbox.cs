using UnityEngine;

public class SlashHitbox : MonoBehaviour {
    public Enemy enemy;
    public Animator animator;
    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.5f;
    float atkTimer = 0f;

    // Update is called once per frame
    void Update(){
        CheckMeleeTimer();
        OnAttack();
    }

    public void OnAttack(){
        if(!isAttacking && enemy.currentHealth > 0){
            Melee.SetActive(true);
            isAttacking = true;
            animator.SetTrigger("Attack");
        }
    }

    public void CheckMeleeTimer(){
        if(isAttacking){
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration){
                atkTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }
}
