package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
//import core.GameServer;
import model.Player;
import networking.response.ResponseRoom;
//import utility.DataReader;
import utility.Log;

public class RequestRoom extends GameRequest {

	// Data
//  private String version;

	// Responses
	private ResponseRoom responseRoom;
	private static int count = 0;

	public RequestRoom() {
		responses.add(responseRoom = new ResponseRoom());
	}

	@Override
	public void parse() throws IOException {
//    version = DataReader.readString(dataInput).trim();
	}

	@Override
	public void doBusiness() throws Exception {
		Player player = new Player();
		Log.printf("********In RequestRoom ******** User '%s' is connecting...", player.getID());

		client.setUserID(player.getID());

//		GameServer.getInstance().setActivePlayer(player);
		player.setClient(client);
		// Pass Player reference into thread
		client.setPlayer(player);

		responseRoom.setPlayer(player);
		System.out.println("****************Count: " + count);
		System.out.println("****************: " + player);
		++count;
	}
}
