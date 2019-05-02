package networking.response;

import metadata.Constants;
import utility.GamePacket;

public class ResponseChat extends GameResponse {

// Variables
	public short status;
	public int playerID;
	public String message;

	public ResponseChat() {
		responseCode = Constants.SMSG_CHAT;
	}

	@Override
	public byte[] constructResponseInBytes() {

		System.out.println("in responseChat*** ");
		GamePacket packet = new GamePacket(responseCode);

		packet.addInt32(playerID);
		packet.addString(message);
		System.out.println("in response*** " + message);
		return packet.getBytes();
	}

	public void setplayerID(int playerID) {
		this.playerID = playerID;
	}

	public void setMessage(String message) {
		this.message = message;
	}

}

