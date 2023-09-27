using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _iconField;

    private AssetItem _item;
    private Inventory _inventory;


    public void Render(AssetItem item)
    {
        _iconField.sprite = item.UIIcon;
        _item = item;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _inventory = other.gameObject.GetComponent<Player>().inventory;
            _inventory.Render(_item);
            Destroy(gameObject);
        }
    }
}