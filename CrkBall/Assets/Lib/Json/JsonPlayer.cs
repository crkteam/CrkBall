using UnityEngine;

public class JsonPlayer : BaseJson
{
    private Player player;

    public JsonPlayer()
    {
        player = new Player();

        int[] buffer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        
        if (!check("MyPlayer"))
            setAll(0,0,0,buffer);
    }

    public int getcash()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.totalPoint;
    }

    public Player getAll()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player;
    }

    public void setAll(int total,int highPoint,int LastHighPoint,int[] ball)
    {
        player.totalPoint = total;
        player.highPoint = highPoint;
        player.LastHighPoint = LastHighPoint;
        player.ball = ball;
        save(player, "MyPlayer");
    }
}