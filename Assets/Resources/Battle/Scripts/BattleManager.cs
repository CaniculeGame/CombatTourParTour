﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public enum E_TextEnum
    {
        HPATT = 1,
        HPCIBLE = 2,
        ATT0 = 4,
        ATT1 = 8,
        ATT2 = 16,
        ATT3 = 32,
        MANAATT = 64,
        MANACIBLE = 128
    }

    public enum E_ManaEnum
    {
        ATTQE = 1,
        CIBLE = 2,
    }

    public enum E_ButtonFlgEnum
    {
        ATT0 = 1,
        ATT1 = 2,
        ATT2 = 4,
        ATT3 = 8,
    }

    public enum E_StateEnum
    {
        COMBAT = 1,
        PAUSE = 2,
        VICTOIRE = 4,
        DEFAITE = 8
    }

    public Image HealhBarAtt;
    public Image HealthBarCible;
    public Image ManaBarAtt;
    public Image ManaBarCible;

    public Text HpAtt;
    public Text HpCible;

    public Text ManaCible;
    public Text ManaAtt;

    public Button Att0;
    public Button Att1;
    public Button Att2;
    public Button Att3;

    private ButtonBattle AttButton0 = null;
    private ButtonBattle AttButton1 = null;
    private ButtonBattle AttButton2 = null;
    private ButtonBattle AttButton3 = null;

    private Personnage Joueur = null;
    private Personnage Ennemie = null;

    public GameObject JoueurObject;
    public GameObject EnnemieObject;
    public float timeMaxAnimation;
    private float timeFinA = 0;
    private float timeFinB = 0;

    public float vitesseInitManaAtt = 0;
    public float vitesseInitManaCible = 0;

    private E_StateEnum State = E_StateEnum.COMBAT;



    internal void Eteindre()
    {
        //desactivation des dependance
        JoueurObject.SetActive(false);
        EnnemieObject.SetActive(false);
        Att0.transform.parent.gameObject.SetActive(false);
    }



    internal void Demarrer()
    {
        //activation des dependance
        JoueurObject.SetActive(true);
        JoueurObject.GetComponent<Animator>().SetInteger("numeroAnimation", 0);
        JoueurObject.transform.position = new Vector3(-1.46f, -1.83f, 0.0f);

        EnnemieObject.SetActive(true);
        Att0.transform.parent.gameObject.SetActive(true);

    }

    public void SetText(string txt, E_TextEnum flg)
    {

        if ((flg & E_TextEnum.ATT0) != 0)
        {
            Att0.GetComponentInChildren<Text>().text = txt;
        }

        else if ((flg & E_TextEnum.ATT1) != 0)
        {
            Att1.GetComponentInChildren<Text>().text = txt;
        }

        else if ((flg & E_TextEnum.ATT2) != 0)
        {
            Att2.GetComponentInChildren<Text>().text = txt;
        }

        else if ((flg & E_TextEnum.ATT3) != 0)
        {
            Att3.GetComponentInChildren<Text>().text = txt;
        }

        else if ((flg & E_TextEnum.HPATT) != 0)
        {
            HpAtt.text = txt;
        }

        else if ((flg & E_TextEnum.HPCIBLE) != 0)
        {
            HpCible.text = txt;
        }

        else if ((flg & E_TextEnum.MANAATT) != 0)
        {
            ManaAtt.text = txt;
        }

        else if ((flg & E_TextEnum.MANACIBLE) != 0)
        {
            ManaCible.text = txt;
        }
    }
    public string GetText(E_TextEnum Val)
    {
        if ((Val & E_TextEnum.ATT0) != 0)
        {
            return Att0.GetComponentInChildren<Text>().text;
        }

        if ((Val & E_TextEnum.ATT1) != 0)
        {
            return Att1.GetComponentInChildren<Text>().text;
        }

        if ((Val & E_TextEnum.ATT2) != 0)
        {
            return Att2.GetComponentInChildren<Text>().text;
        }

        if ((Val & E_TextEnum.ATT3) != 0)
        {
            return Att3.GetComponentInChildren<Text>().text;
        }

        if ((Val & E_TextEnum.HPATT) != 0)
        {
            return HpAtt.text;
        }

        if ((Val & E_TextEnum.HPCIBLE) != 0)
        {
            return HpCible.text;
        }

        if ((Val & E_TextEnum.MANAATT) != 0)
        {
            return ManaAtt.text;
        }

        if ((Val & E_TextEnum.MANACIBLE) != 0)
        {
            return ManaCible.text;
        }

        return "";

    }



    public void Configurer(Personnage joueur, Personnage ennemie)
    {
        //initialisation des boutons
        Joueur = joueur;
        Ennemie = ennemie;

        AttButton0 = new ButtonBattle();
        AttButton1 = new ButtonBattle();
        AttButton2 = new ButtonBattle();
        AttButton3 = new ButtonBattle();


        if (Joueur.AttaquesList.Count > 0)
        {
            Att0.gameObject.SetActive(true);
            SetText(Joueur.AttaquesList[0].Intitule + "  " + (Joueur.AttaquesList[0].Mp * 100.0f).ToString("0") + " Mp", E_TextEnum.ATT0);
        }
        else
        {
            Att0.gameObject.SetActive(false);
            SetText("", E_TextEnum.ATT0);
        }

        if (Joueur.AttaquesList.Count > 1)
        {
            Att1.gameObject.SetActive(true);
            SetText(Joueur.AttaquesList[1].Intitule + "  " + (Joueur.AttaquesList[1].Mp * 100.0f).ToString("0") + " Mp", E_TextEnum.ATT1);
        }
        else
        {
            Att1.gameObject.SetActive(false);
            SetText("", E_TextEnum.ATT1);
        }

        if (Joueur.AttaquesList.Count > 2)
        {
            Att2.gameObject.SetActive(true);
            SetText(Joueur.AttaquesList[2].Intitule + "  " + (Joueur.AttaquesList[2].Mp * 100.0f).ToString("0"), E_TextEnum.ATT2);
        }
        else
        {
            Att2.gameObject.SetActive(false);
            SetText("", E_TextEnum.ATT2);
        }

        if (Joueur.AttaquesList.Count > 3)
        {
            Att3.gameObject.SetActive(true);
            SetText(Joueur.AttaquesList[3].Intitule + "  " + (Joueur.AttaquesList[3].Mp * 100.0f).ToString("0") + " Mp", E_TextEnum.ATT3);
        }
        else
        {
            Att3.gameObject.SetActive(false);
            SetText("", E_TextEnum.ATT3);
        }


        Joueur.Mana = 0.0f;
        Ennemie.Mana = 0.0f;

        HealhBarAtt.fillAmount = Joueur.Pv / Joueur.PvBase;
        ManaBarAtt.fillAmount = Joueur.Mana / Joueur.ManaBase;

        HealthBarCible.fillAmount = Ennemie.Pv / Ennemie.PvBase;
        ManaBarCible.fillAmount = Ennemie.Mana / Ennemie.ManaBase;


        // attention il y a que ici qu'on multiplie par 100
        SetText((Ennemie.ManaBase * 100) + " / " + Ennemie.ManaBase * 100 + " MP", E_TextEnum.MANACIBLE);
        SetText((Ennemie.PvBase * 100) + " / " + Ennemie.PvBase * 100 + " PV", E_TextEnum.HPCIBLE);

        SetText((Joueur.PvBase * 100) + " / " + Joueur.PvBase * 100 + " PV", E_TextEnum.HPATT);
        SetText((Joueur.ManaBase * 100) + " / " + Joueur.ManaBase * 100 + " MP", E_TextEnum.MANAATT);


        State = E_StateEnum.COMBAT;
    }



    private void Combat()
    {

        //code Ia
        float val = UnityEngine.Random.Range(0.4f, 0.8f);
        if (val <= Ennemie.Mana)
        {
            UseMana(val, E_ManaEnum.CIBLE);
        }

        //Attribution du Mana
        Ennemie.Mana += (Ennemie.Vitesse * Time.deltaTime);
        if (Ennemie.Mana >= Ennemie.ManaBase)
        {
            ManaBarCible.fillAmount = 1.0f;
            Ennemie.Mana = Ennemie.ManaBase;
        }
        else
        {
            ManaBarCible.fillAmount = Ennemie.Mana / Ennemie.ManaBase;
        }


        Joueur.Mana += (Joueur.Vitesse * Time.deltaTime);
        if (Joueur.Mana >= Joueur.ManaBase)
        {
            ManaBarAtt.fillAmount = 1.0f;
            Joueur.Mana = Joueur.ManaBase;
        }
        else
        {
            ManaBarAtt.fillAmount = Joueur.Mana / Joueur.ManaBase;
        }


        //Maj des valeurs d'affichage
        SetText((Ennemie.Mana * 100).ToString("0") + " / " + Ennemie.ManaBase * 100 + " MP", E_TextEnum.MANACIBLE);
        SetText((Ennemie.Pv * 100).ToString("0") + " / " + Ennemie.PvBase * 100 + " PV", E_TextEnum.HPCIBLE);

        SetText((Joueur.Pv * 100).ToString("0") + " / " + Joueur.PvBase * 100 + " PV", E_TextEnum.HPATT);
        SetText((Joueur.Mana * 100).ToString("0") + " / " + Joueur.ManaBase * 100 + " MP", E_TextEnum.MANAATT);


        //maj anim
        if (timeFinA < Time.time)
        { JoueurObject.GetComponent<Animator>().SetInteger("numeroAnimation", 0); timeFinA = 0; }

        if (timeFinB < Time.time)
        { EnnemieObject.GetComponent<Animator>().SetInteger("numeroAnimation", 0); timeFinB = 0; }


        if (Ennemie.Pv <= 0.0f)
        {
            Debug.Log("Victoire");
            State = E_StateEnum.VICTOIRE;
        }

        if (Joueur.Pv <= 0.0f)
        {
            Debug.Log("Defaite");
            State = E_StateEnum.DEFAITE;
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Escape))
        {
            if (State != E_StateEnum.PAUSE)
                State = E_StateEnum.COMBAT;
            else
                State = E_StateEnum.PAUSE;
        }

        if (Input.GetKey(KeyCode.A))
        {
            State = E_StateEnum.VICTOIRE;
        }


        switch (State)
        {
            case E_StateEnum.COMBAT:
                Combat();
                break;

            case E_StateEnum.DEFAITE:
                Defaite();
                break;

            case E_StateEnum.VICTOIRE:
                Victoire();
                break;

            case E_StateEnum.PAUSE:
                Pause();
                break;
        }



    }

    public E_StateEnum StateBattle() { return State; }




    private void Pause()
    {
        // throw new NotImplementedException();
        //Debug.Log("Pause");
    }

    private void Victoire()
    {
        //play animation

        //changer d'etat

    }

    private void Defaite()
    {
        // throw new NotImplementedException();
        // Debug.Log("Defaite");
    }

    public void UseMana(float value, E_ManaEnum player)
    {
        if ((player & E_ManaEnum.ATTQE) != 0)
        {
            Joueur.Mana -= value;
        }

        if ((player & E_ManaEnum.CIBLE) != 0)
        {
            Ennemie.Mana -= value;
        }

    }


    public void Attaque(int flg)
    {
        float vie = HealthBarCible.fillAmount;
        int animA = 0;
        int animB = 0;

        if (((E_ButtonFlgEnum)flg & E_ButtonFlgEnum.ATT0) != 0)
        {
            if (AttButton0.Execute(ref Ennemie, ref Joueur, 0))
            {
                UseMana(Joueur.AttaquesList[0].Mp, E_ManaEnum.ATTQE);

                //maj des animation
                animA = Joueur.AttaquesList[0].NumeroAnimationAttaquant;
                animB = Joueur.AttaquesList[0].NumeroAnimationEnnemie;
            }
        }

        else if (((E_ButtonFlgEnum)flg & E_ButtonFlgEnum.ATT1) != 0)
        {
            if (AttButton1.Execute(ref Ennemie, ref Joueur, 1))
            {
                UseMana(Joueur.AttaquesList[1].Mp, E_ManaEnum.ATTQE);
                //maj des animation
                animA = Joueur.AttaquesList[1].NumeroAnimationAttaquant;
                animB = Joueur.AttaquesList[1].NumeroAnimationEnnemie;
            }
        }

        else if (((E_ButtonFlgEnum)flg & E_ButtonFlgEnum.ATT2) != 0)
        {
            if (AttButton2.Execute(ref Ennemie, ref Joueur, 2))
            {
                UseMana(Joueur.AttaquesList[2].Mp, E_ManaEnum.ATTQE);
                //maj des animation
                animA = Joueur.AttaquesList[2].NumeroAnimationAttaquant;
                animB = Joueur.AttaquesList[2].NumeroAnimationEnnemie;
            }
        }

        else if (((E_ButtonFlgEnum)flg & E_ButtonFlgEnum.ATT3) != 0)
        {
            if (AttButton3.Execute(ref Ennemie, ref Joueur, 3))
            {
                UseMana(Joueur.AttaquesList[3].Mp, E_ManaEnum.ATTQE);
                //maj des animation
                animA = Joueur.AttaquesList[3].NumeroAnimationAttaquant;
                animB = Joueur.AttaquesList[3].NumeroAnimationEnnemie;
            }
        }

        //maj animation
        JoueurObject.GetComponent<Animator>().SetInteger("numeroAnimation", 0); // on repasse toujours par l etat idle qui est etat de transition
        JoueurObject.GetComponent<Animator>().SetInteger("numeroAnimation", animA);

        EnnemieObject.GetComponent<Animator>().SetInteger("numeroAnimation", 0);
        EnnemieObject.GetComponent<Animator>().SetInteger("numeroAnimation", animB);

        timeFinA = timeMaxAnimation + Time.time;
        timeFinB = timeMaxAnimation + Time.time;

        HealthBarCible.fillAmount = Ennemie.Pv / Ennemie.PvBase;
        if (Ennemie.Pv <= 0)
            Ennemie.Pv = 0;
    }
}
