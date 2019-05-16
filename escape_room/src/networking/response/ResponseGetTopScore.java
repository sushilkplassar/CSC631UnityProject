package networking.response;

import metadata.Constants;
import utility.GamePacket;

public class ResponseGetTopScore extends GameResponse {

// Variables
	public String teamIds;
	public String totalTimes;

	public ResponseGetTopScore() {
		responseCode = Constants.SMSG_TIMER;
	}

	@Override
	public byte[] constructResponseInBytes() {
		GamePacket packet = new GamePacket(responseCode);
		packet.addString(teamIds);
		packet.addString(totalTimes);
		return packet.getBytes();
	}

	public void setplayerID(String teamID) {
		this.teamIds = teamID;
	}

	public void setTime(String time) {
		// TODO Auto-generated method stub
		this.totalTimes=time;
	}

}

