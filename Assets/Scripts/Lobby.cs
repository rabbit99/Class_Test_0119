using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Lobby : MonoBehaviourPunCallbacks
{
    public string MAP_PROP_KEY = "map";
    public string GAME_MODE_PROP_KEY = "gm";
    public string AI_PROP_KEY = "ai";

    public InputField PlayerNameInput;
    public Text RoomListText;
    public GameObject GameStartObj;

    private StringBuilder sb = new StringBuilder();
    private List<RoomInfo> _roomList = new List<RoomInfo>();
    // Start is called before the first frame update
    void Start()
    {
        GameStartObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLoginButtonClicked()
    {
        string playerName = "123";

        if (!playerName.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
    }

    public void CreateRoom()
    {
        int randomNum = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "map" };
        roomOptions.CustomRoomProperties = new Hashtable { { "map", 1 } };
        PhotonNetwork.CreateRoom("Test" + randomNum, roomOptions);

    }

    public void SetRoom()
    {
        Room room = PhotonNetwork.CurrentRoom;
        if (room == null)
        {
            return;
        }
        Hashtable cp = room.CustomProperties;
        Debug.Log("cp = " + (string)cp["CustomProperties"]);
        room.SetCustomProperties(cp);
    }

    public void RefreshRoom()
    {
        PhotonNetwork.GetCustomRoomList(TypedLobby.Default, null);
    }

    public void StartGame()
    {
        Room room = PhotonNetwork.CurrentRoom;
        if (room == null)
        {
            return;
        }
        room.IsOpen = false;
    }

    #region PUN CALLBACKS
    public override void OnConnectedToMaster()
    {
        //this.SetActivePanel(SelectionPanel.name);
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("OnJoinedLobby");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // 進入房間失敗時的程式碼
        Debug.Log("OnJoinRoomFailed");
    }
    public override void OnJoinedRoom()
    {
        // 進入房間成功時的程式碼 
        Debug.Log("OnJoinedRoom");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        GameStartObj.SetActive(true);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        Debug.Log("OnRoomListUpdate");

        var oldRoomUpdateList = roomList.Where(i => _roomList.Contains(i)).ToList();
        foreach (RoomInfo room in oldRoomUpdateList)
        {
            //_roomList.Add(room);
            Debug.Log(room);
            if (room.PlayerCount == 0 || !room.IsOpen)
            {
                int index = _roomList.FindIndex(x => x.Equals(room));
                _roomList.RemoveAt(index);
                roomList.Remove(room);
            }
        }
        var newRoomList = roomList.Where(i => !_roomList.Contains(i)).ToList();
        foreach (RoomInfo room in newRoomList)
        {
            _roomList.Add(room);
        }

        sb.Clear();
        foreach (RoomInfo room in _roomList)
        {
            Hashtable cp = room.CustomProperties;
            //string mapCode = (string)cp["map"];
            sb.AppendLine(">> " + room.Name + "  map = " + cp["map"]);
        }
        RoomListText.text = sb.ToString();
    }
    #endregion
}
