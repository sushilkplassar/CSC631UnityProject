package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseUnready extends GameResponse {

  private short status;
  int playerUnready;
  private Player player;

  public ResponseUnready() {
    responseCode = Constants.SMSG_UNREADY;
  }

  @Override
  public byte[] constructResponseInBytes() {
    GamePacket packet = new GamePacket(responseCode);


    System.out.println("Player that is unready is: Player " + playerUnready);
    packet.addInt32(playerUnready);
    return packet.getBytes();
  }

  public void setStatus(short status) {
    this.status = status;
  }

  public void setPlayerUnready(int ready) {
    this.playerUnready = ready;
  }

}