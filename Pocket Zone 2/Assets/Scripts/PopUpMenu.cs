using System.Collections;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField] private GameObject _hideMenu;

    public void OnClickCells()
    {
        _hideMenu.SetActive(true);
        StartCoroutine(HideMenu());
    }

    public void OnClickDelete()
    {
        Destroy(gameObject);
    }

    private IEnumerator HideMenu()
    {
        yield return new WaitForSeconds(2);
        _hideMenu.SetActive(false);
    }
}
