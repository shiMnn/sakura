using System;
using System.Collections.Generic;

public class HandManager {
    List<CardCase> m_cardCases = new List<CardCase>();

    public HandManager() {
        m_cardCases = new List<CardCase>();
        for (int i = 0; i < GameDef.HAND_ZONE_MAX_COUNT; ++i) {
            m_cardCases.Add(new CardCase());
        }
    }

    /// <summary>
    /// カードを追加することができるか
    /// </summary>
    /// <returns>true:可能</returns>
    public bool IsPossibleToAddCard() {
        foreach(var cardCase in m_cardCases) {
            if(cardCase.IsEmpty()) {
                return true;
            }
        }
        return false;
    }

    public void AddCard(CardBase card) {
        int size = m_cardCases.Count;
        for (int i = 0; i < size; ++i) {
            var cardCase = m_cardCases[i];
            if (cardCase.IsEmpty()) {
                cardCase.Set(card);
                break;
            }
        }
    }

    public CardBase GetCard(int CaseIndex) {
        try {
            return m_cardCases[CaseIndex].Card;
        }catch(ArgumentOutOfRangeException e) {
            return null;
        }
    }
}
