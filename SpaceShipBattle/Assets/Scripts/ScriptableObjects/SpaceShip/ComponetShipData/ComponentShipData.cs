using UnityEngine;

public class ComponentShipData : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }
    public Sprite sprite;
    [Header("Stats")]
    public int health;
    public int damage;
    public int defense;
    public float speed;

    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
