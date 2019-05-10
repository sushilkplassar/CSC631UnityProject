package networking.response;

// Other Imports
import metadata.Constants;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseLight extends GameResponse {

  private String color;

  public ResponseLight() {
    responseCode = Constants.SMSG_LIGHT;
  }

  @Override
  public byte[] constructResponseInBytes() {
    GamePacket packet = new GamePacket(responseCode);


    System.out.println("Light color to be sent: " + color);
    packet.addString(color);
    return packet.getBytes();
  }

  public void setColor(String color) {
    this.color = color;
  }

}