package networking.request;

import java.io.IOException;

import core.NetworkManager;
import dataAccessLayer.ChatsDAO;
import networking.response.ResponseChat;
import utility.DataReader;

// Other Imports

public class RequestChat extends GameRequest {

	public int playerID;
	public String message;

	@Override
	public void parse() throws IOException {
		// TODO Auto-generated method stub
		System.out.println("Dinput" + dataInput);
		playerID = DataReader.readInt(dataInput);
		message = DataReader.readString(dataInput).trim();
		System.out.println(message);
	}

	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		ResponseChat response = new ResponseChat();
		ChatsDAO.insertChats(playerID,message);
		System.out.println("***message: " + message);
		System.out.println("***playerID: " + playerID);
		response.setMessage(message);
		response.setplayerID(playerID);
		System.out.println("*****response*** " + message);
		NetworkManager.addResponseForAllOnlinePlayers(playerID, response);
	}
}