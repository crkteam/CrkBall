using UnityEngine;

public class JsonPlayer : BaseJson
{
    private Player player;

    public JsonPlayer()
    {
        player = new Player();

        int[] buffer_ball = {2, 0, 0, 0, 0};
        int[] buffer_music = {2, 0};
        
        if (!check("MyPlayer"))
            setAll(0,0,0,buffer_ball,buffer_music);
    }

    public void settotal(int total)
    {
        player.totalPoint = total;
        save(player, "MyPlayer");
    }
    
    public void sethighPoint(int highPoint)
    {
        player.highPoint = highPoint;
        save(player, "MyPlayer");
    }
    
    public void sethighLevel(int highLevel)
    {
        player.highLevel = highLevel;
        save(player, "MyPlayer");
    }
    
    public void setBall(int[] ball)
    {
        player.ball = ball;
        save(player, "MyPlayer");
    }
    
    public void setMusic(int[] music)
    {
        player.music = music;
        save(player, "MyPlayer");
    }
    
    public int gettotal()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.totalPoint;
    }
    
    public int gethighPoint()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.highPoint;
    }
    
    public int gethighLevel()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.highLevel;
    }
    
    public int[] getBall()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.ball;
    }
    
    public int[] getMusic()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.music;
    }

    public Player getAll()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player;
    }

    public void setAll(int total,int highPoint,int highLevel,int[] ball,int[] music)
    {
        player.totalPoint = total;
        player.highPoint = highPoint;
        player.highLevel = highLevel;
        player.ball = ball;
        player.music = music;
        save(player, "MyPlayer");
    }
}