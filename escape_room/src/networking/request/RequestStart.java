package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
//import core.GameServer;
import model.Player;
import networking.response.ResponseStart;
//import utility.DataReader;
import utility.DataReader;
import utility.Log;

public class RequestStart extends GameRequest {

  // Data
//  private String version;

  // Responses
  private ResponseStart startResponse;
  private static int count = 0;
  private int start;

  public RequestStart() {
    responses.add(startResponse = new ResponseStart());
  }

  @Override
  public void parse() throws IOException {
    start = DataReader.readInt(dataInput);
  }

  @Override
  public void doBusiness() throws Exception {

    startResponse.setStart(start);
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
