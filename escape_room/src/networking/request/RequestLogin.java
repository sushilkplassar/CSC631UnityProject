package networking.request;

// Java Imports
import java.io.IOException;
import java.util.List;

// Other Imports
import core.GameClient;
import core.GameServer;
//import dataAccessLayer.UsersDAO;
import metadata.Constants;
import model.Player;
import networking.response.ResponseLogin;
import utility.DataReader;
import utility.GamePacket;
import utility.Log;

/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */
public class RequestLogin extends GameRequest {

  // Data
  private String version;
  private int user_id;
  private String password;
  // Responses
  private ResponseLogin responseLogin;
  private static int count = 0;

  public RequestLogin() {
    responses.add(responseLogin = new ResponseLogin());
  }

  @Override
  public void parse() throws IOException {
    version = DataReader.readString(dataInput).trim();
    //user_id = DataReader.readInt(dataInput);
//        password = DataReader.readString(dataInput).trim();
  }

  @Override
  public void doBusiness() throws Exception {
    Player player = new Player();
    Log.printf("User '%s' is connecting...", player.getID());

    client.setUserID(player.getID());
    responseLogin.setUserID(player.getID());

    GameServer.getInstance().setActivePlayer(player);
    player.setClient(client);
    // Pass Player reference into thread
    client.setPlayer(player);
    // Set response information
    responseLogin.setStatus((short) 0); // Login is a success
    responseLogin.setPlayer(player);
    ++count;
  }
}
