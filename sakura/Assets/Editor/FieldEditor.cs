using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldEditor : EditorWindow {
    readonly static Vector2 FIELD_BASE_POS = new Vector2(50.0f, 20.0f);
    readonly static Vector2 FIELD_SIZE = new Vector2(128.0f, 128.0f);

    readonly static Vector2 HAND_BASE_POS = new Vector2(700.0f, 80.0f);
    readonly static Vector2 HAND_SIZE = new Vector2(128.0f, 128.0f);

    Texture texture_handZone = null;
    Texture texture_handZoneNone = null;
    Texture texture_fieldZone = null;
    Texture texture_fieldZoneNone = null;

    Player[] m_players = new Player[2];

    bool m_enable = false;

    [MenuItem("Custom/FieldEditor")]
    static void Open() {
        var window = EditorWindow.CreateInstance<FieldEditor>();
        window.titleContent.text = "FieldEditor";
        window.ShowUtility();
    }

    private void OnGUI() {
        if (PlayerManager.Instance != null) {
            m_players[(int)PlayerID.Self] = PlayerManager.Instance.GetPlayer(PlayerID.Self);
            m_players[(int)PlayerID.Opponent] = PlayerManager.Instance.GetPlayer(PlayerID.Opponent);
        }
        m_enable = ((m_players[(int)PlayerID.Self] != null) && (m_players[(int)PlayerID.Opponent] != null));
        if (!m_enable) { return; }

        if(texture_handZone == null) {
            texture_handZone = Resources.Load("hand_zone") as Texture;
        }
        if (texture_handZoneNone == null) {
            texture_handZoneNone = Resources.Load("hand_zone_none") as Texture;
        }
        if (texture_fieldZone == null) {
            texture_fieldZone = Resources.Load("field_zone") as Texture;
        }
        if (texture_fieldZoneNone == null) {
            texture_fieldZoneNone = Resources.Load("field_zone_none") as Texture;
        }

        this.UpdatePlayerInfo(m_players[(int)PlayerID.Opponent], FIELD_BASE_POS, HAND_BASE_POS);
        Vector2 fieldBasePos = new Vector2(FIELD_BASE_POS.x, FIELD_BASE_POS.y + 300.0f);
        Vector2 handBasepos = new Vector2(HAND_BASE_POS.x, HAND_BASE_POS.y + 300.0f);
        this.UpdatePlayerInfo(m_players[(int)PlayerID.Self], fieldBasePos, handBasepos);
    }

    private void UpdatePlayerInfo(Player player, Vector2 fieldBasePos, Vector2 handBasePos) {
        for (int i = 0; i < GameDef.FRONT_FIELD_ZONE_MAX_COUNT; ++i) {
            Vector3 pos = new Vector3(fieldBasePos.x + (i * FIELD_SIZE.x), fieldBasePos.y, 0.0f);
            Texture texture = (false) ? texture_fieldZone : texture_fieldZoneNone;
            GUI.DrawTexture(new Rect(pos, FIELD_SIZE), texture, ScaleMode.ScaleToFit);
        }
        for (int i = 0; i < GameDef.BACK_FIELD_ZONE_MAX_COUNT; ++i) {
            Vector3 pos = new Vector3(fieldBasePos.x + (i * FIELD_SIZE.x), fieldBasePos.y + FIELD_SIZE.y, 0.0f);
            Texture texture = (false) ? texture_fieldZone : texture_fieldZoneNone;
            GUI.DrawTexture(new Rect(pos, FIELD_SIZE), texture, ScaleMode.ScaleToFit);
        }


        for (int i = 0; i < GameDef.HAND_ZONE_MAX_COUNT; ++i) {
            var card = player.Hand.GetCard(i);
            Vector3 pos = new Vector3(handBasePos.x + (i * HAND_SIZE.x * 0.75f), handBasePos.y, 0.0f);
            Texture texture = (card != null) ? texture_handZone : texture_handZoneNone;
            GUI.DrawTexture(new Rect(pos, HAND_SIZE), texture, ScaleMode.ScaleToFit);
        }
    }
}
