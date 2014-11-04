using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour
{
    public GameObject player;
    public float playerHP;
    public float zombieKills;

    public GUIStyle style;

    private bool isPlaying;
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<Player>().maxhp;
        isPlaying = true;
        zombieKills = 0;

        Player.HpChange+= UpdateHP;
        Player.Dead += StopPlaying;
        Zombie.Dead += UpdateKill;
    }

    void OnDisable()
    {
        Player.HpChange -= UpdateHP;
        Player.Dead -= StopPlaying;
        Zombie.Dead -= UpdateKill;
    }

	// Use this for initialization
	void StopPlaying()
	{
	    isPlaying = false;
	}
	
	// Update is called once per frame
	void UpdateHP()
	{
	    playerHP = player.GetComponent<Player>().Health;

	}

    void UpdateKill()
    {
        zombieKills++;
    }

    void OnGUI()
    {
        if (isPlaying)
        {
            GUI.Box(new Rect(20, 20, 100, 50), "Health: " + playerHP, style);
            GUI.Box(new Rect(Screen.width - 80, 20, 100, 50), "Kills: " + zombieKills, style);
        }
        else
        {
            GUI.BeginGroup(new Rect(Screen.width/2 - 140, Screen.height/2, 500, 200));

            GUI.Label(new Rect(0, 60, 200, 50), "You Died! You killed " + zombieKills + " zombies!", style);


            if (GUI.Button(new Rect(80, 120, 100, 50), "Restart?"))
                Application.LoadLevel("test");


            GUI.EndGroup();

        }
    }
}
