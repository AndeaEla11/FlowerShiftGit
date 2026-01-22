using UnityEngine;

public class CustomerFlow : MonoBehaviour
{
    private GameController gameController;
    private WaypointManager waypointManager;

    private Transform counterPoint;
    private Transform exitPoint;

    private bool waitingAtCounter = false;
    private bool leaving = false;

    public void Initiate(GameController controller, WaypointManager wm, Transform counter, Transform exit)
    {
        gameController = controller;
        waypointManager = wm;
        counterPoint = counter;
        exitPoint = exit;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingAtCounter && HasArrived())
        {
            waitingAtCounter = true;
            OnArrivedAtCounter(); 
        }

        if (leaving && HasArrived())
        {
            OnArrivedAtExit();
        }
    }

    bool HasArrived()
    {
        return !waypointManager.isMoving;
    }

    void OnArrivedAtCounter()
    {
        Debug.Log("NPC arrived at counter"); 

        OrderUI ui = FindFirstObjectByType<OrderUI>();
        ui.ShowOrder(); 
    }

    public void OnBouquetDelivered()
    {
        Debug.Log("Bouquet delivered");
    }

    public void OnGoodbyeClicked()
    {
        Debug.Log("Goodbye clicked");

        leaving = true;
        waitingAtCounter = false;

        waypointManager.wayPoints.Clear();
        waypointManager.wayPoints.Add(exitPoint);
        waypointManager.StartMoving();

    }

    void OnMouseDown()
    {
        OnGoodbyeClicked();
    }

    void OnArrivedAtExit()
    {
        Debug.Log("NPC exited");

        Destroy(transform.root.gameObject);

        gameController.SpawnCustomer();
    }


}
