package networking.response;

import java.util.Arrays;

import metadata.Constants;
import utility.GamePacket;

public class ResponseGetTopScore extends GameResponse {

// Variables
	public int playerID;
	public int totalTime;
	public String playerIds;
	public String totalTimes;

	public ResponseGetTopScore() {
		responseCode = Constants.SMSG_TIMER;
	}

	@Override
	public byte[] constructResponseInBytes() {

		System.out.println("***in responseTimer protocol*** ");
		GamePacket packet = new GamePacket(responseCode);
		
//		packet.addInt32(playerID);
//		packet.addString(Arrays.toString(playerIds)); //"[1,2,3,4,5]"
		// 1|123,2|222, 
		packet.addString(playerIds);
		packet.addString(totalTimes);
		return packet.getBytes();
	}

	public void setplayerID(String playerID) {
		this.playerIds = playerID;
	}

	public void setTime(String time) {
		// TODO Auto-generated method stub
		this.totalTimes=time;
	}

}

