package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseReady;
import utility.DataReader;

public class RequestReady extends GameRequest {

	// Data
//  private String version;

	// Responses
	private ResponseReady responseReady;
	private static int count = 0;
	private int ready;

	public RequestReady() {
		responses.add(responseReady = new ResponseReady());
	}

	@Override
	public void parse() throws IOException {
			ready = DataReader.readInt(dataInput);
	}

	@Override
	public void doBusiness() throws Exception {

		responseReady.setPlayerReady(ready);
		/*
		Player player = new Player();
		Log.printf("********In RequestReady ******** User '%s' is connecting...", player.getID());

		client.setUserID(player.getID());

//		GameServer.getInstance().setActivePlayer(player);
		player.setClient(client);
		// Pass Player reference into thread
		client.setPlayer(player);

		responseRoom.setPlayer(player);
		System.out.println("****************Count: " + count);
		System.out.println("****************: " + player);
		++count;*/
	}
}
