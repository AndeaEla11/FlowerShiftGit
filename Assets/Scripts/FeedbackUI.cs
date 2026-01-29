using UnityEngine;
using TMPro;

public class FeedbackUI : MonoBehaviour
{
    [SerializeField] private GameObject feedbackPanel;
    [SerializeField] private TMP_Text feedbackText;

    private void Awake()
    {
        feedbackPanel.SetActive(false);
    }
    public void ShowText(string messageToShow)
    {
        feedbackText.text = messageToShow; 
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
