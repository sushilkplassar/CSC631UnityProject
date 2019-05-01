package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseReady extends GameResponse {

    private short status;
    int playerReady;
    private Player player;

    public ResponseReady() {
        responseCode = Constants.SMSG_READY;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);


        	System.out.println("Player that is ready is: Player " + playerReady);
          packet.addInt32(playerReady);
        return packet.getBytes();
    }

    public void setStatus(short status) {
        this.status = status;
    }

    public void setPlayerReady(int ready) {
        this.playerReady = ready;
    }

}