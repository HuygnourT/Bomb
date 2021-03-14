using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;

    public Player Player { get; private set; }
    public bool Ready = false;

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        SetPlayerText(Player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(targetPlayer != null && targetPlayer == Player)
        {
            if(changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(targetPlayer);
            }
        }
    }

    private void SetPlayerText(Player player)
    {
        int result = -1;

        if (player.CustomProperties.ContainsKey("RandomNumber"))
            result = (int)player.CustomProperties["RandomNumber"];

        text.text = result.ToString() + ", " + Player.NickName;
    }
}
