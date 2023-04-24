using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Item : MonoBehaviour
{
    public int UnicalNumber;
    private int _id;
    [Inject] private ItemManipulator _itemManipulator;
    public int ID
    {
        get => _id;
        set => _id = value;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GiveMyInfo);
    }

    private void GiveMyInfo()
    {
        _itemManipulator.TakeButtonInfo(this);
    }
}

