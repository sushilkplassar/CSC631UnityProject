package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseP2Triggers;
import utility.DataReader;

public class RequestP2Triggers extends GameRequest {

  // Data
//  private String version;

  // Responses
  private ResponseP2Triggers responseP2Triggers;
  private int value;

  public RequestP2Triggers() {
    responses.add(responseP2Triggers = new ResponseP2Triggers());
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
