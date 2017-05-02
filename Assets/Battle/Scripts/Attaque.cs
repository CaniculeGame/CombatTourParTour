using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque
{
    private string intitule_;
    private float mp_;
    private float power_;
    private Type type_;


    public Attaque(float mp, float power, string nom, Type tp)
    {
        intitule_ = nom;
        mp_ = mp;
        power_ = power;
        type_ = tp;
    }


    public float Mp { get { return mp_; } }
    public float Power { get { return power_; } }
    public string Intitule { get { return intitule_; } }
    public Type TypeDAttaque { get { return type_; } }

}

