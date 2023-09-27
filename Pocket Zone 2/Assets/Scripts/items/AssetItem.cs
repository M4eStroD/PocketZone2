using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, IItem
{
    public int Count => _count;
    public Sprite UIIcon => _uiIcon;

    [SerializeField] private int _count;
    [SerializeField] private Sprite _uiIcon;

}
