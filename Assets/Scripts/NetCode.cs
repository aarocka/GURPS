using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;//the socekt that connects to the server
    public GameObject playerPrefab;//the prefab that represents the player
    public GameObject enemyPrefab;//the prefab that represents other players
    public string nic = "";//the players nickname
    static string gameInfoString = "{\"gameID\":123456,\"turn\":1,\"gameStart\":true,\"players\":[{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100},{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":2,\"nicname\":\"steve\",\"posX\":17.64,\"posY\":0,\"maxHealth\":100,\"health\":100}]}";
    static string playerObjectString = "{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100}";
    public JSONObject gameInfo = new JSONObject(gameInfoString);//the json object that hold the game stutusinfo that is passed to the backend
    public JSONObject playerObject = new JSONObject(playerObjectString);//the json object that holds players position and stats
	public float playerTurn;//the players place in the turn sequence
	public float playerNumber;//the number attached to the player
    // Use this for initialization
    void Start () {
        //create initializethe socket object
		GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

		//spawn players
        socket.On("playerJoined", spawnPlayerFromSocket);
        socket.On("gameStarted", spawnEnemiesFromSocket);
        socket.On("turnEnded", updatePlayerPositions);
        //spawnPlayer(playerObject);
        //spawnEnemies(gameInfo);
        

    }
	
	// Update is called once per frame
	void Update () {

		//these functions can be called either by clicking buttons or pressing hot keys
        if (Input.GetKeyDown("s"))
        {
			startGame ();
            
        }
        else if (Input.GetKeyDown("j"))
        {
			joinGame ();
        }
		else if (Input.GetKeyDown("e"))
        {
			endTurn();
        }
	}

	//this function starts the game
	public void startGame(){
		Debug.Log("Starting Game");
		socket.Emit("start", "something");
	}
	//this function adds the player to the game
	public void joinGame(){
		Debug.Log("joining game with username "+nic);
		socket.Emit("join", nic);
	}

	//this  function sends the players position to the server when his turn is over
	public void endTurn(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<Unit> ().moveCounter = 0;
		playerObject.list [3].n = player.transform.position.x;
		playerObject.list [4].n = player.transform.position.z;
		socket.Emit ("playerUpdate", playerObject);
	}
		
    void spawnEnemiesFromSocket(SocketIOEvent e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
		//imports the json information about the players from the backend
        JSONObject players = (JSONObject)e.data.list[3];
		//imports the json information about eh players turn order from the backend
		playerTurn = e.data.list [1].n;
        //Debug.Log(players.list[0]);

        foreach (JSONObject j in players.list)
        {
            if (j.list[1].n != playerObject.list[1].n)
            {
                Debug.Log("Spawned enemy:" + j);

				//initialize variables that hold the enemys coordinates
                float tempX = j.list[3].n;
                float tempY = j.list[4].n;

				//instatiates a enemy prefab
                GameObject temp = (GameObject)Instantiate(enemyPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
                temp.name = j.list[2].str;//initialize a variable that hodls the neame of the enemy
            }
        }

    }


    public void spawnPlayerFromSocket(SocketIOEvent e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        playerObject = e.data;
        Debug.Log("You are player number" + e.data.list[1]);
		playerNumber = e.data.list[1].n;//initializes the players number from the json information on the back end
        
		//initialize variables that hod the players coordinates
		float tempX = e.data.list[3].n;
        float tempY = e.data.list[4].n;
        GameObject temp = (GameObject)Instantiate(playerPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
        temp.name = e.data.list[2].str;
        Camera.main.GetComponent<Mouse>().setPlayer();
    }

    public void updatePlayerPositions(SocketIOEvent e) {
        JSONObject players = (JSONObject)e.data.list[3];

		playerTurn = e.data.list [1].n;

        foreach (JSONObject j in players.list)
        {
            if (j.list[1].n != playerObject.list[1].n)
            {
                Unit temp = GameObject.Find(j.list[2].str).GetComponent<Unit>();
                temp.destination = new Vector3(j.list[3].n,0,j.list[4].n);
            }
        }


    }
    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }
}
