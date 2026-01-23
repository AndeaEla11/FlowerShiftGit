using System.Collections.Generic;
using UnityEngine;

public class BouquetSlotManager : MonoBehaviour
{
    [SerializeField] private List<Transform> slots = new List<Transform>();
    private int nextIndex = 0;

    public Transform GetNextSlot()
    {
        if (slots.Count == 0) return null;

        Transform slot = slots[nextIndex];
        nextIndex++;

        if (nextIndex >= slots.Count)
            nextIndex = 0; 

        return slot;
    }
}
