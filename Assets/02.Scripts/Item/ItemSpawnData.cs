using UnityEngine;

[System.Serializable]
public class ItemSpawnData
{
    [SerializeField] private ItemType _itemType;
    public ItemType ItemType => _itemType;

    [SerializeField] private int _weight;
    public int Weight => _weight;
}