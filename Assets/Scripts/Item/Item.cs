using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Item : MonoBehaviour
{
    [SerializeField] private int _uniqueNumber;
    [Inject] private ItemManipulator _itemManipulator;

    private int _id;
    
    public int ID
    {
        get => _id;
        set => _id = value;
    }

    public int GetUniqueNumber => _uniqueNumber;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GiveMyInfo);
    }

    private void GiveMyInfo()
    {
        _itemManipulator.TakeButtonInfo(this);
    }
}

