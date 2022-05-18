using UnityEngine.AI;
using UnityEngine;

public class Night3 : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
    }
}
