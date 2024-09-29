using UnityEngine;

public class CursedKnifeFactory : BaseCreator
{
    public CursedKnifeFactory(GameObject prefab) : base(prefab)
    {
        Spawner.name = "Cursed Knife Factory";
    }

    public override IItem Create()
    {
        GameObject cursedKnife = GameObject.Instantiate(Model);
        cursedKnife.AddComponent<CursedKnife>();
        cursedKnife.transform.position = new Vector3(-0.6f, 0.3f, -7.6f);
        cursedKnife.transform.SetParent(Spawner.transform);

        return cursedKnife.GetComponent<CursedKnife>();
    }
}
