using UnityEngine;

public class JsonPlayer : BaseJson
{
    private Player player;

    public JsonPlayer()
    {
       player = new Player();
        if (!check("MyPlayer"))
            setAll(0);
    }

    public int getcash()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.cash;
    }
    
    public Player getAll()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player;
    }

    public void setAll(int lobby)
    {
        player.cash = lobby;
                
        save(player,"MyPlayer");
    }

    public void setCash(int cash)
    {
        player.cash = cash;
        save(player,"MyPlayer");
    }
}