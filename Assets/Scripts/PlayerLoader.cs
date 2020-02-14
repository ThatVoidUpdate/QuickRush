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

    private static PlayerLoader _instance;

    public static PlayerLoader Instance {get { return _instance; }}

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
             
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
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
