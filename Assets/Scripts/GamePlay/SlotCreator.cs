using System.Collections.Generic;
using UnityEngine;

public class SlotCreator : MonoBehaviour
{
    [SerializeField] private int _spaceSizeHorizontal;
    [SerializeField] private int _spaceSizeVertical;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Transform _parentPanel;

    public List<Transform> Slots;

    public int SpaceSizeHorizontal => _spaceSizeHorizontal;
    public int SpaceSizeVertical => _spaceSizeVertical;
    

    private void Awake()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        var totalSize = _spaceSizeHorizontal * _spaceSizeVertical;
        for (var i = 0; i < totalSize; i++)
        {
            var slot =  Instantiate(_slotPrefab, _parentPanel);
            Slots.Add(slot.transform);
        }
    }
}
