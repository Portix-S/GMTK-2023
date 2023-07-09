using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazada : MonoBehaviour
{
    private bool isAttacking;
    private BoxCollider pa;
    public GameManager gm;
    private float kbMaxForce = 20f, kbForce= 5f, kbDelay = .5f;
    private Animator animator;

    private void Start() {
        pa = GetComponent<BoxCollider>();
        animator = GetComponentInParent<Animator>();
        kbMaxForce = 20f;
        kbForce = 5f;
    }

    private float attackDuration = .5f;
    private float attackTimer = 0f;
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && attackTimer <= 0f && !gm.isMenuOpen){
            if(kbForce < kbMaxForce){
                kbForce += Time.deltaTime * 20f;
            }
            else kbForce = kbMaxForce;
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse0) && attackTimer <= 0f && !gm.isMenuOpen){
            Debug.Log("Attacking...");
            attackTimer = attackDuration;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
            pa.enabled = true;
        }

        if(attackTimer > 0f){
            attackTimer -= Time.deltaTime;
        }
        else if(isAttacking){
            animator.SetBool("isAttacking", false);
            isAttacking = false;
            pa.enabled = false;
            kbForce = 10f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit! Target: " + other.gameObject.tag);
        if(other.gameObject.tag == "Zombie"){
            Vector3 playerPos = transform.position;
            Vector3 zombiePos = other.gameObject.transform.position;
            Vector3 knockbackDir = new Vector3(zombiePos.x - playerPos.x, 0, zombiePos.z - playerPos.z).normalized;

            Rigidbody zombieRb = other.gameObject.GetComponentInChildren<Rigidbody>();
            ZombieAI zombieAi = other.gameObject.GetComponent<ZombieAI>();
            zombieRb.AddForce(knockbackDir * kbForce, ForceMode.Impulse);
            zombieAi.isTakingKnockBack = true;
            StartCoroutine(KnockBackCooldown(zombieRb, zombieAi));

            StopCoroutine(zombieAi.Follow());
            StartCoroutine(zombieAi.Follow());
        }
    }

    IEnumerator KnockBackCooldown(Rigidbody rb, ZombieAI zai){
        yield return new WaitForSeconds(kbDelay);
        zai.isTakingKnockBack = false;
        rb.velocity = Vector3.zero;
    }
}
