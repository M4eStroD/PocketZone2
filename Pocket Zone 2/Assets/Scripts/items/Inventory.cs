using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCellTamplate;
    [SerializeField] private Transform _container;

    public void Render(AssetItem item)
    {
        var cell = Instantiate(_inventoryCellTamplate, _container);
        cell.Render(item);
    }
}
