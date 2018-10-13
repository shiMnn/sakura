using System.Collections.Generic;

public class PlayerManager : SingletonClass<PlayerManager> {
    List<Player> m_palyers = new List<Player>();

    public void Setup() {
        m_palyers.Add(new Player(PlayerID.Self));
        m_palyers.Add(new Player(PlayerID.Opponent));
    }

    public Player GetPlayer(PlayerID id) {
        return m_palyers[(int)id];
    }

    public Player GetOpponentPlayer(Player player) {
        if(player.ID == PlayerID.Self) {
            return m_palyers[(int)PlayerID.Opponent];
        } else {
            return m_palyers[(int)PlayerID.Self];
        }
    }

    /// <summary>
    /// ターンプレイヤーの取得
    /// </summary>
    /// <returns></returns>
    public Player GetTurnPlayer() {
        foreach(Player player in m_palyers) {
            if (player.IsMyTurn) { return player; }
        }

        return null;
    }

    public List<Player> GetPlayers() {
        return m_palyers;
    }
}