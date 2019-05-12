package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseP2Correct;
import utility.DataReader;

public class RequestP2Correct extends GameRequest {

  // Data
//  private String version;

  // Responses
  private ResponseP2Correct responseP2Triggers;
  private int value;

  public RequestP2Correct() {
    responses.add(responseP2Triggers = new ResponseP2Correct());
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
