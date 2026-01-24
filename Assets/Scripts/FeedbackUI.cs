using UnityEngine;

public class FeedbackUI : MonoBehaviour
{
    [SerializeField] private GameObject feedbackPanel;
    private void Awake()
    {
        feedbackPanel.SetActive(false);
    }
    public void Show()
    {
        feedbackPanel.SetActive(true);
    }
    public void Hide()
    {
        feedbackPanel.SetActive(false);
    }
    public void Goodbye()
    {
        CustomerFlow flow = FindFirstObjectByType<CustomerFlow>();
        if (flow != null)
        { 
            flow.OnGoodbyeClicked(); 
        }
    }
}
