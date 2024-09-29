using UnityEngine;

public class PebbleFactory : BaseCreator
{
    public PebbleFactory(GameObject prefab) : base(prefab)
    {
        Spawner.name = "Pebble Factory";
    }

    public override IItem Create()
    {
        GameObject pebble = GameObject.Instantiate(Model);
        pebble.AddComponent<Pebble>();
        pebble.transform.position = new Vector3(-2.2f, 0.3f, -7f);
        pebble.transform.SetParent(Spawner.transform);

        return pebble.GetComponent<Pebble>();
    }
}
