using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Text _hPField;
    [SerializeField] private Text _boostField;

    private int _hp = 10;
    public int HP
    {
        get { return _hp; }
        set
        {
            _hp = value;
            _hPField.text = $"HP: {value}";
        }
    }

    private int _boost = 0;
    public int Boost
    {
        get { return _boost; }
        set
        {
            _boost = value;
            _boostField.text = $"Boost: {value}x";
        }
    }
}