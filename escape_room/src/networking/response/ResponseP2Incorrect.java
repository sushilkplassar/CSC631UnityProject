package networking.response;

// Other Imports
import metadata.Constants;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseP2Incorrect extends GameResponse {

  private int value;

  public ResponseP2Incorrect() {
    responseCode = Constants.SMSG_P2INCORRECT;
  }

  @Override
  public byte[] constructResponseInBytes() {
    GamePacket packet = new GamePacket(responseCode);


    System.out.println("Trigger value is: " + value);
    packet.addInt32(value);
    return packet.getBytes();
  }

  public void setValue(int value) {
    this.value = value;
  }

}