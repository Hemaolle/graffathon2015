using UnityEngine;
using System.Collections;
using System.Net.Sockets;

public class Marslander : MonoBehaviour {

	Socket socket;
	// Use this for initialization
	void Start () {
		socket = new Socket(AddressFamily.InterNetwork,
		                     SocketType.Stream,
		                     ProtocolType.Tcp);
		socket.Connect("localhost", 1338);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
