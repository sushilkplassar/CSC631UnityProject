package networking.request;

import java.io.IOException;

import dataAccessLayer.GamesDAO;
import model.Player;
import networking.response.ResponseGetTopScore;
import utility.DataReader;

// Other Imports

public class RequestSaveTopScore extends GameRequest {

	public String teamName;
	public int time;
	
    private ResponseGetTopScore responseTimer;

	@Override
	public void parse() throws IOException {
		System.out.println("***In RequestSaveTopScore Protocol***");
		teamName = DataReader.readString(dataInput);
		time=DataReader.readInt(dataInput);
		System.out.println(time);
	}

	@SuppressWarnings("unused")
	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		System.out.println("***Time received from Unity: " + time);
		System.out.println("***playerID received: " + teamName);
		Player player = GamesDAO.insertGame(teamName, time);
		System.out.println("***Value inserted in db: "+teamName+", "+ time);
	}
}