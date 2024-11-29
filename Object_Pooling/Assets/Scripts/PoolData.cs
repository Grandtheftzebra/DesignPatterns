using System;
using UnityEngine;

[Serializable]
public class PoolData
{
    [field: SerializeField] public string Tag { get; set; }
    [field: SerializeField] public GameObject GO { get; set; }
    [field: SerializeField] public int Size { get; set; }
}
