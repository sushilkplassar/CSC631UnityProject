package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseStart extends GameResponse {

  private short status;
  int playerStart;

  public ResponseStart() {
    responseCode = Constants.SMSG_START;
  }

  @Override
  public byte[] constructResponseInBytes() {
    GamePacket packet = new GamePacket(responseCode);
    System.out.println("Game is starting.");
    packet.addInt32(playerStart);
    return packet.getBytes();
  }

  public void setStart(int start) {
    this.playerStart = start;
  }

}