using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject NPCPrefab;

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform counterPosition;
    [SerializeField] private Transform exitPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game started -> spawning first NPC");
        SpawnCustomer();
    }

    public void SpawnCustomer()
    {
        GameObject NPC = Instantiate(NPCPrefab, spawnPosition.position, spawnPosition.rotation);

        WaypointManager waypointManager = NPC.GetComponent<WaypointManager>();
        waypointManager.wayPoints.Clear();
        waypointManager.wayPoints.Add(counterPosition);
        waypointManager.wayPoints.Add(exitPosition);

        waypointManager.StartMoving();

        CustomerFlow flow = NPC.GetComponentInChildren<CustomerFlow>(); 
        flow.Initiate(this, waypointManager, counterPosition, exitPosition);
    }
}
