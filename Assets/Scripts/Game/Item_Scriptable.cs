using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Create Item")]
public class Item_Scriptable : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public string Description;
    public float Weight;
 
    public enum Type
    {
        Equip,
        Use
    };
    public Type type;

    public int ID { get; private set; }

    private void OnEnable()
    {
        ID = this.GetInstanceID();
    }
}
