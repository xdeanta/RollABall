using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    private Vector3 OriginalPos;
    
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        OriginalPos = transform.position;
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        pathfinder.SetDestination(target.position);
        Debug.Log(target.position);
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            transform.position = OriginalPos;
        }
    }
}
