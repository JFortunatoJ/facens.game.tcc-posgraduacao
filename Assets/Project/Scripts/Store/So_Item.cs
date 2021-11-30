using Project.Scripts.Enums;
using UnityEngine;

[CreateAssetMenu]
public class So_Item : ScriptableObject
{
    public string id;
    public ItemType type;
    public string name;
    public int price;
    public Sprite icon;
}
