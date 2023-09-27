using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _backpack;

    public void OnBackpackClick()
    {
        Time.timeScale = 0f;
        _backpack.SetActive(true);
    }

    public void OnBackClick()
    {
        _backpack.SetActive(false);
        Time.timeScale = 1f;
    }
}
