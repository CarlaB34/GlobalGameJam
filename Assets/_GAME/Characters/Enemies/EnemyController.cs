using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField]
    private UnityEvent m_Animaiton = new UnityEvent();

    [SerializeField]
    AudioSource SoundBrancheBreak;

    [SerializeField]
    AudioSource SoundBrancheHit;
    [SerializeField]
    AudioSource SoundDeath;

    public static bool isDeath = false;


    public bool IsDie
    {
        get { return isDeath; }
        set { isDeath = value; }
    }
    private void Awake()
    {
        stats.HP = stats.MaxHp;
        m_Animaiton.Invoke();
    }

    public void Damage(int amount)
    {
        stats.HP -= amount;


        if (stats.enemy_index == 0)
        {
            SoundBrancheHit.Play();

            if (stats.HP <= 0)
            {
                SoundBrancheBreak.Play();
                isDeath = true;
                this.gameObject.SetActive(false);
                stats.HP = 20;
            }
        }

        else
        {


            if (stats.HP <= 0)
            {
                GetComponent<BossDetection>().enabled = false;
                SoundDeath.Play();
                isDeath = true;                    
                stats.HP = 100;
                win();
            }

        }

    }



    public void win()
    {
        StartCoroutine(winScreen());
    }

    IEnumerator winScreen()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("MenuEndAttack");
        Debug.Log("Victoire");
    }


}
