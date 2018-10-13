public class TaskDrawCard : TaskNodeBase {
    PlayerID m_drawPlayerId;
    int m_drawNum = 0;
    public TaskDrawCard(PlayerID drawPlayerId, int drawNum) {
        m_drawPlayerId = drawPlayerId;
        m_drawNum = drawNum;
    }

    public override bool Setup() {
        return true;
    }

    public override bool Exec() {
        Player player = PlayerManager.Instance.GetPlayer(m_drawPlayerId);
        while (m_drawNum > 0) {
            var hand = player.Hand;
            var deck = player.Deck;
            if (hand.IsPossibleToAddCard()) {
                var card = deck.PickTop();
                if (card != null) {
                    hand.AddCard(card);
                }
            }

            --m_drawNum;
        }
        return true;
    }

    public override bool Finish() {
        return true;
    }
}