using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TaskSetup : TaskNodeBase {
    public override bool Setup() {
        // 乱数を種から作る
        GameRandom.Instance.Setup(0);

        PlayerManager.Instance.Setup();

        {// 自プレイヤーのデッキを作る
            Player player = PlayerManager.Instance.GetPlayer(PlayerID.Self);
            //TODO: MOCKデッキ
            List<int> cardIds = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 11, 11, 11, 12, 12, 12, 13, 13, 13, 14 };
            foreach (int cardID in cardIds) {
                CardBase createCard = new CardBase(cardID);
                player.Deck.AddCard(createCard);
            }
        }

        {// 対戦相手のプレイヤーのデッキを作る
            Player player = PlayerManager.Instance.GetPlayer(PlayerID.Opponent);
            //TODO: MOCKデッキ
            List<int> cardIds = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 11, 11, 11, 12, 12, 12, 13, 13, 13, 14 };
            foreach (int cardID in cardIds) {
                CardBase createCard = new CardBase(cardID);
                player.Deck.AddCard(createCard);
            }
        }
            
        return true;
    }

    public override bool Exec() {
        return true;
    }

    public override bool Finish() {
        TaskManager.Instance.Next(this, new TaskGameStart());
        return true;
    }
}