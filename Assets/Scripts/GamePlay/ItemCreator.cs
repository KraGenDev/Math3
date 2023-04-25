using System.Collections.Generic;
using UnityEngine;


public class ItemCreator : MonoBehaviour
{
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private GameObject[] _itemPrefabs;

    [HideInInspector] public List<GameObject> _createdItems;
    private void Start()
    {
        FillCreatedSlots();
    }

    private void FillCreatedSlots()
    {
        var slots = _slotCreator.Slots;
        var size = _slotCreator.Slots.Count;
        for (var i = 0; i < size; i++)
        {
            var prefabNumber = Random.Range(0, _itemPrefabs.Length);
            var currentPrefab = _itemPrefabs[prefabNumber];
            var item = Instantiate(currentPrefab, slots[i].transform);
            
            item.GetComponent<Item>().ID = i;
            
            _createdItems.Add(item);
        }
    }
    public void CreateItemAt(int id)
    {
        var slots = _slotCreator.Slots;

        var prefabNumber = Random.Range(0, _itemPrefabs.Length);
        var currentPrefab = _itemPrefabs[prefabNumber];
        var item = Instantiate(currentPrefab, slots[id].transform);
            
        item.GetComponent<Item>().ID = id;

        _createdItems[id] = item;
    }
}
