package networking.request;

import java.io.IOException;

import dataAccessLayer.GamesDAO;
import model.Player;
import networking.response.ResponseGetTopScore;
import utility.DataReader;

// Other Imports

public class RequestSaveTopScore extends GameRequest {

	public int playerID;
	public int time;
	
    private ResponseGetTopScore responseTimer;

	@Override
	public void parse() throws IOException {
		System.out.println("***In RequestTimer Protocol***");
		playerID = DataReader.readInt(dataInput);
		time=DataReader.readInt(dataInput);
		System.out.println(time);
	}

	@SuppressWarnings("unused")
	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		System.out.println("***Time received from Unity: " + time);
		System.out.println("***playerID received: " + playerID);
		Player player = GamesDAO.insertGame(playerID, time);
		System.out.println("***Value inserted in db: "+playerID+", "+ time);
	}
}