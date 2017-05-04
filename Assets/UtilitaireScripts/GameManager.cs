using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BattleManager battle;
    public ModificationPersonnageManager creationPerso;
    public GameObject personnageA;
    public GameObject personnageB;

    public enum E_StateEnum
    {
        DEMARRAGE = 0,
        CREATION = 1,
        COMBAT = 2
    }

    private E_StateEnum state = E_StateEnum.CREATION;
    private E_StateEnum stateActu = E_StateEnum.CREATION;

    //gestion du temps pour la surveillance
    private float timeprecedent = 0;
    public float timeAttente = 0;


    private Type convertirStringToType(string intitule)
    {
        if (intitule == "EAU")
        {
            return new TypeEau();
        }

        if (intitule == "FEU")
        {
            return new TypeFeu();
        }

        if (intitule == "NORMAL")
        {
            return new TypeNormal();
        }

        if (intitule == "PLANTE")
        {
            return new TypePlante();
        }

        return null;
    }


    private Attaque.E_TypeAttaque convertirStringToTypeAttaque(string intitule)
    {
        return (Attaque.E_TypeAttaque)int.Parse(intitule);
    }


    public void ChangeState(E_StateEnum newState)
    {
        stateActu = newState;
    }

    public void ChangeState(int newState)
    {
        stateActu = (E_StateEnum)newState;
        Debug.Log("ChangeState = " + stateActu);
    }

    private void Start()
    {
        creationPerso.enabled = true;
        battle.enabled = false;

        personnageA.GetComponent<Personnage>().SetType(new TypeFeu());
        personnageB.GetComponent<Personnage>().SetType(new TypeEau());
        creationPerso.Configurer();
    }

    // Update is called once per frame
    void Update()
    {
        if (state != stateActu)
        {

            if (stateActu == E_StateEnum.CREATION)
            {

                creationPerso.enabled = true;
                battle.Eteindre();
                creationPerso.Demarrer();
                battle.enabled = false;
            }

            if (stateActu == E_StateEnum.COMBAT)
            {
                creationPerso.Eteindre();

                battle.enabled = true;
                battle.Demarrer();

                List<Attaque> listA = new List<Attaque>();
                List<Attaque> listB = new List<Attaque>();

                //creation de la liste via les elements dans la scrolllist
                List<Item> lst = creationPerso.getListB();
                foreach (Item i in lst)
                {
                    //convertir type
                    Type tp = convertirStringToType(i.IntituleType);
                    //convertir cara
                    Attaque.E_TypeAttaque typeAtt = convertirStringToTypeAttaque(i.Caracteristique);

                    listA.Add(new Attaque(i.Mana, i.Power, i.Intitule, tp, typeAtt, i.animationA, i.animationB));
                }

                for (int i = 0; i < 4; i++)
                {
                    listB.Add(new Attaque(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), "Attaque_" + i, new TypeEau(), global::Attaque.E_TypeAttaque.ATTAQUER, 2, 3));
                }


                Personnage A = personnageA.GetComponent<Personnage>(); 
                Personnage B = personnageB.GetComponent<Personnage>();
                A.InitPersonnage();
                A.AttaquesList = listA;

                B.InitPersonnage();
                B.AttaquesList = listB;
                battle.Configurer(A, B);

                creationPerso.enabled = false;
            }

            state = stateActu;
        }
        else
        {
            if (Time.time > timeprecedent + timeAttente)
            {
                //interogation de l'etat du jeu
                if (battle.enabled)
                {
                    switch (battle.StateBattle())
                    {
                        case BattleManager.E_StateEnum.COMBAT:
                            break;

                        case BattleManager.E_StateEnum.DEFAITE:
                            ChangeState(E_StateEnum.CREATION);
                            break;

                        case BattleManager.E_StateEnum.PAUSE:
                            break;

                        case BattleManager.E_StateEnum.VICTOIRE:
                            ChangeState(E_StateEnum.CREATION);
                            break;
                    }
                }

                timeprecedent = Time.time;
            }

        }
    }
}
