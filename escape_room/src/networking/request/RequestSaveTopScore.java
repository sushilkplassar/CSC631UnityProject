package networking.request;

import java.io.IOException;

import dataAccessLayer.GamesDAO;
import model.Player;
import utility.DataReader;

// Other Imports

public class RequestSaveTopScore extends GameRequest {

	public String teamName;
	public int time;
	

	@Override
	public void parse() throws IOException {
		teamName = DataReader.readString(dataInput);
		time=DataReader.readInt(dataInput);
		System.out.println(time);
	}

	@SuppressWarnings("unused")
	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		Player player = GamesDAO.insertGame(teamName, time);
		System.out.println("***Value inserted in db: "+teamName+", "+ time);
	}
}