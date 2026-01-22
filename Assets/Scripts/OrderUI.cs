using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private GameObject orderPanel;

    private void Awake()
    {
        orderPanel.SetActive(false);
    }

    public void ShowOrder()
    {
        orderPanel.SetActive(true);
    }

    public void HideOrder()
    {
        orderPanel.SetActive(false);
    }
}
