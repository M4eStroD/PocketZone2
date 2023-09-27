using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private DropItem _dropItem;

    public void Render(AssetItem item)
    {
        var cell = Instantiate(_dropItem, transform.position, Quaternion.identity);
        cell.Render(item);
    }
}
