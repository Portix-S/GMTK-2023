using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] Transform follow;
    private NavMeshAgent zombie;
    public enum states {IDLE, WANDER, FOLLOW};
    public states state;

    public RaiseTheDead.jobs job;

    private bool isFacingLeft = false;
    private SpriteRenderer zombieSprite;

    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        follow = GameObject.FindGameObjectWithTag("Player").transform;

        // state = states.IDLE;
        StartCoroutine(Follow());
    }

    private void FixedUpdate() {
        if((zombie.velocity.x < 0f && !isFacingLeft) || (zombie.velocity.x > 0f && isFacingLeft)){
            isFacingLeft = !isFacingLeft;
            GetComponentsInChildren<Transform>()[1].Rotate(0f, 180f, 0f);
        } 
    }

    public IEnumerator Follow(){
        state = states.FOLLOW;

        StartCoroutine(AttentionSpan());
        while(state == states.FOLLOW){
            zombie.SetDestination(follow.position);
            yield return null;
        }

        zombie.SetDestination(Vector3.zero);
    }

    private IEnumerator AttentionSpan(){
        yield return new WaitForSeconds(Random.Range(5f, 10f)); // 10 - 60 sec
        StopFollowing();
    } 

    private void StopFollowing(){
        StopAllCoroutines();

        state = states.WANDER;
        StartCoroutine(Wander());
    }

    private IEnumerator Wander(){
        Vector3 randomPoint = transform.position;
        while(state == states.WANDER){
            if(zombie.velocity == Vector3.zero){
                randomPoint = GetRandomPatrolPoint();
            }
            zombie.SetDestination(randomPoint);
            yield return null;
        }
    }

    private Vector3 GetRandomPatrolPoint(){
        int radius = 10;
        Vector3 randomPoint = Random.insideUnitSphere * radius;
        Vector3 finalPoint = Vector3.zero;
        randomPoint += transform.position;
        if(NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, radius, 1))
            finalPoint = hit.position;

        return finalPoint;
    }
}
