using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    private Type type_ = null;
    private float pv_ = 0.0f;
    private float pvDefaut_ = 0.0f;
    private float def_ = 0.0f;
    private float defDefaut_ = 0.0f;
    private float mana_ = 0.0f;
    private float manaDefaut_ = 0.0f;
    private float vitesse_ = 0.0f;
    private float vitesseDefaut_ = 0.0f;
    private float esquive_ = 0.0f;
    private float esquiveDefaut_ = 0.0f;
    private float precision_ = 0.0f;
    private float precisionDefaut_ = 0.0f;

    public Personnage(float pv, float def, float mana, float vitesse, float esquive, float precision, Type type)
    {

        if (pv <= 0)
            pv = 1.0f;

        if (def <= 0)
            def = 1.0f;

        if (mana <= 0)
            mana = 1.0f;

        if (vitesse <= 0)
            vitesse = 1.0f;

        if (esquive <= 0)
            esquive = 1.0f;

        if (precision <= 0)
            precision = 1.0f;

        pvDefaut_ = pv;
        defDefaut_ = def;
        manaDefaut_ = mana;
        type_ = type;
        vitesseDefaut_ = vitesse;
        esquiveDefaut_ = esquive;
        precisionDefaut_ = precision;

        pv_ = pv;
        def_ = def;
        mana_ = mana;
        type_ = type;
        vitesse_ = vitesse;
        esquive_ = esquive;
        precision_ = precision;

    }


    public float Pv { get { return pv_; } set { pv_ = value; } }
    public float Def { get { return def_; } set { def_ = value; } }
    public float Mana { get { return mana_; } set { mana_ = value; } }
    public float Vitesse { get { return vitesse_; } set { vitesse_ = value; } }
    public float Esquive { get { return esquive_; } set { esquive_ = value; } }
    public float Precision { get { return precision_; } set { precision_ = value; } }

    public float PvBase { get { return pvDefaut_; } set { pv_ = value; } }
    public float DefBase { get { return defDefaut_; } set { def_ = value; } }
    public float ManaBase { get { return manaDefaut_; } set { mana_ = value; } }
    public float VitesseBase { get { return vitesseDefaut_; } set { vitesse_ = value; } }
    public float EsquiveBase { get { return esquiveDefaut_; } set { esquive_ = value; } }
    public float PrecisionBase { get { return precisionDefaut_; } set { precision_ = value; } }

    public Type Type { get { return type_; } set { type_ = value; } }

}
