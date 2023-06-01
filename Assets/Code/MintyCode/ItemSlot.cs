using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Item Item;
    [SerializeField] Image Image;
    [SerializeField] Plate plate;

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot draggedItemSlot = eventData.pointerDrag.GetComponent<ItemSlot>();
        if (draggedItemSlot != null && Item == null && !plate.IsFull())
        {
            // Swap items between slots
            Item = draggedItemSlot.Item;
            draggedItemSlot.Item = null;

            // Add the item to the plate
            plate.AddItem(Item);
        }
    }
}
