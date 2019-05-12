package networking.response;

// Other Imports
import metadata.Constants;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseP2Correct extends GameResponse {

  private int value;

  public ResponseP2Correct() {
    responseCode = Constants.SMSG_P2CORRECT;
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