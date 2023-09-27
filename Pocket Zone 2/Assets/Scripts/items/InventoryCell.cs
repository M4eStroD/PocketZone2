using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _countField;
    [SerializeField] private Image _iconField;

    public void Render(IItem item)
    {
        if (item.Count == 1) _countField.text = "";
        else _countField.text = item.Count.ToString();
        
        _iconField.sprite = item.UIIcon;
    }
}
