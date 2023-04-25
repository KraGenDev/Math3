using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemManipulator : MonoBehaviour
{

    [SerializeField] private ItemCreator _itemCreator;
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private float _speedItemSwap = 0.5f;

    private List<GameObject> _items;
    private int _sizeHorizontal;
    private int _sizeVertical;

    private Item _firstItem;
    private Item _secondItem;

    public static event Action MatchThree;
    private void Start()
    {
        var startDelay = 0.1f;
        _sizeHorizontal = _slotCreator.SpaceSizeHorizontal;
        _sizeVertical = _slotCreator.SpaceSizeVertical;
        _items = _itemCreator._createdItems;
        Invoke(nameof(CheckTheeInLine),startDelay);
    }

    private void CheckTheeInLine()
    {
        for (int row = 0; row < _sizeVertical; row++)
        {
            int startIdx = row * _sizeHorizontal;
            for (int col = 0; col <= _sizeHorizontal - 3; col++)
            {
                var targetValue = _items[startIdx + col].GetComponent<Item>().GetUniqueNumber;
                if (_items[startIdx + col + 1].GetComponent<Item>().GetUniqueNumber == targetValue &&
                    _items[startIdx + col + 2].GetComponent<Item>().GetUniqueNumber == targetValue)
                {
                    RaplaceItem(startIdx + col);
                    RaplaceItem(startIdx + col + 1);
                    RaplaceItem(startIdx + col + 2);
                    MatchThree?.Invoke();
                    CheckTheeInLine();
                }
            }
        }
        
        for (int col = 0; col < _sizeHorizontal; col++)
        {
            var startIdx = col;
            for (int row = 0; row <= _sizeVertical - 3; row++)
            {
                var targetValue = _items[startIdx + row * _sizeHorizontal].GetComponent<Item>().GetUniqueNumber;
                if (_items[startIdx + (row + 1) * _sizeHorizontal].GetComponent<Item>().GetUniqueNumber == targetValue &&
                    _items[startIdx + (row + 2) * _sizeHorizontal].GetComponent<Item>().GetUniqueNumber == targetValue)
                {
                    RaplaceItem(startIdx + row * _sizeHorizontal);
                    RaplaceItem(startIdx + (row + 1) * _sizeHorizontal);
                    RaplaceItem(startIdx + (row + 2) * _sizeHorizontal);
                    CheckTheeInLine();
                    MatchThree?.Invoke();
                }
            }
        }
    }

    private void RaplaceItem(int id)
    {
        Destroy(_items[id]);
        _itemCreator.CreateItemAt(id);
    }
    public void TakeButtonInfo(Item item)
    {
        if (_firstItem == null)
        {
            _firstItem = item;
        }
        else
        {
            _secondItem = item;
            SwapItems(_firstItem.ID,_secondItem.ID);
        }
    }
    
    private void SwapItems(int idFirstItem, int idSecondItem)
    {
        var rowA = idFirstItem / _sizeVertical;
        var colA = idFirstItem % _sizeVertical;
        var rowB = idSecondItem / _sizeVertical;
        var colB = idSecondItem % _sizeVertical;
        
        if (Mathf.Abs(rowA - rowB) + Mathf.Abs(colA - colB) != 1)
        {
            _firstItem = null;
            _secondItem = null;
            return;
        }
        
        
        var firstItemParent = _items[idFirstItem].transform.parent;
        _items[idFirstItem].transform.parent = _items[idSecondItem].transform.parent;
        _items[idSecondItem].transform.parent = firstItemParent;

        var firstItem = _items[idFirstItem];
        _items[idFirstItem] = _items[idSecondItem];
        _items[idSecondItem] = firstItem;

        var firstItemID = _items[idFirstItem].GetComponent<Item>().ID;
        _items[idFirstItem].GetComponent<Item>().ID = _items[idSecondItem].GetComponent<Item>().ID;
        _items[idSecondItem].GetComponent<Item>().ID = firstItemID;
       
        _items[idFirstItem].transform.DOLocalMove(Vector3.zero, _speedItemSwap);
        _items[idSecondItem].transform.DOLocalMove(Vector3.zero, _speedItemSwap);
        
        _firstItem = null;
        _secondItem = null;

        CheckTheeInLine();
    }

}