package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseP2Incorrect;
import utility.DataReader;

public class RequestP2Incorrect extends GameRequest {

  // Data
//  private String version;

  // Responses
  private ResponseP2Incorrect responseP2Triggers;
  private int value;

  public RequestP2Incorrect() {
    responses.add(responseP2Triggers = new ResponseP2Incorrect());
  }

  @Override
  public void parse() throws IOException {
    value = DataReader.readInt(dataInput);
  }

  @Override
  public void doBusiness() throws Exception {
    responseP2Triggers.setValue(value);
    System.out.println("Requested value is: " + value);
  }
}
