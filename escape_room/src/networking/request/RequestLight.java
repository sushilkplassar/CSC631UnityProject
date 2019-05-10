package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseLight;
import utility.DataReader;

public class RequestLight extends GameRequest {

  // Data
//  private String version;

  // Responses
  private ResponseLight responseLight;
  private String color;

  public RequestLight() {
    responses.add(responseLight = new ResponseLight());
  }

  @Override
  public void parse() throws IOException {
    color = DataReader.readString(dataInput);
  }

  @Override
  public void doBusiness() throws Exception {
    responseLight.setColor(color);
    System.out.println("Requested color to turn on is: " + color);
  }
}
