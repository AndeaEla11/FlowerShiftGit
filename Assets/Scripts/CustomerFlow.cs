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
    void Update()
    {
        if(waypointManager == null || gameController == null)
        {
            return;
        }

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

        if (GameState.bouquetDelivered)
        {
            GameState.bouquetDelivered = false;
            OnBouquetDelivered();
            return;
        }

        OrderUI ui = FindFirstObjectByType<OrderUI>();
        ui.ShowOrder();
    }
    public void OnBouquetDelivered()
    {
        Debug.Log("Bouquet delivered");

        OrderUI orderUI = FindFirstObjectByType<OrderUI>();
        if (orderUI != null) 
        {
            orderUI.HideOrder();
        }

        FeedbackUI feedback = FindAnyObjectByType<FeedbackUI>();
        if (feedback != null)
        {
            feedback.Show();
        }
    }
    public void OnGoodbyeClicked()
    {
        Debug.Log("Goodbye clicked");

        FeedbackUI feedback = FindFirstObjectByType<FeedbackUI>();
        if (feedback != null)
        {
            feedback.Hide();
        }

        leaving = true;
        waitingAtCounter = false;

        waypointManager.wayPoints.Clear();
        waypointManager.wayPoints.Add(exitPoint);
        waypointManager.StartMoving();
    }
    void OnArrivedAtExit()
    {
        Debug.Log("NPC exited");

        Destroy(transform.root.gameObject);

        gameController.SpawnCustomer();
    }
}
