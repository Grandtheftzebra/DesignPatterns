using UnityEngine;

public class PotionFactory : BaseCreator
{
    public PotionFactory(GameObject prefab) : base(prefab)
    {
        Spawner.name = "Potion Factory";
    }

    // Could be made more generic, maybe even put in baseCreator
    public override IItem Create()
    {
        GameObject potion = GameObject.Instantiate(Model);
        potion.AddComponent<Potion>();
        potion.transform.position = new Vector3(0.6f, 0.3f, -7f);
        potion.transform.SetParent(Spawner.transform);

        return potion.GetComponent<Potion>();
    }
}
