using UnityEngine;

public class FlowerPickup : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Camera worldCamera;
    [SerializeField] private LayerMask bouquetSurfaceMask;
    [SerializeField] private float yOffset = 0.02f;

    private GameObject dragged;

    void Awake()
    {
        if (worldCamera == null)
            worldCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (spawnPrefab == null || worldCamera == null) return;

        dragged = Instantiate(spawnPrefab);
    }

    void OnMouseDrag()
    {
        if (dragged == null) return;

        Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, bouquetSurfaceMask))
        {
            dragged.transform.position = hit.point + Vector3.up * yOffset;
        }
    }

    void OnMouseUp()
    {
        if (dragged == null) return;

        BouquetSlotManager slots = FindFirstObjectByType<BouquetSlotManager>();
        Transform slot = slots.GetNextSlot();

        if (slot != null)
        {
            dragged.transform.position = slot.position;
            dragged.transform.rotation = slot.rotation;

            BouquetBuilder builder = FindFirstObjectByType<BouquetBuilder>();
            if (builder != null)
            {
                builder.RegisterFlower(dragged);
            }
        }

        dragged = null;
    }

}
