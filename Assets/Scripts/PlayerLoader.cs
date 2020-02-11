using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoader : MonoBehaviour
{
    public Sprite[] IdleSprites;
    public Sprite[] MoveSprites;
    public Sprite[] HurtSprites;

    public int PlayerID;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

             
    }

    private void OnLevelWasLoaded(int level)
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {//We have loaded into the main game
            player.StandardSprite = IdleSprites[PlayerID];
            player.HurtSprite = HurtSprites[PlayerID];
            player.Movingsprite = MoveSprites[PlayerID];
        }
    }

    public void LoadGame(int _PlayerID)
    {
        PlayerID = _PlayerID;
        SceneManager.LoadScene("Gameplay");
    }
}
