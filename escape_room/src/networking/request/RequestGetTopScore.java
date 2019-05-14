package networking.request;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Map;
import java.util.Map.Entry;

import dataAccessLayer.GamesDAO;
import dataAccessLayer.UsersDAO;
import model.Player;
import networking.response.ResponseGetTopScore;
import utility.DataReader;

// Other Imports

public class RequestGetTopScore extends GameRequest {

	public int playerID;
	public int time;
	
    private ResponseGetTopScore responseTimer;

    public RequestGetTopScore() {
    	responses.add(responseTimer = new ResponseGetTopScore());
    }

	@Override
	public void parse() throws IOException {
		System.out.println("***In RequestTimer Protocol***");
//		playerID = DataReader.readInt(dataInput);
//		time=DataReader.readInt(dataInput);
//		System.out.println(time);
	}

	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		String[] array = GamesDAO.getTopScorers();
		System.out.println("***PlayerID received from DB: " + array[0]);
		System.out.println("***TIme received from DB: " + array[1]);
		
		
//		for(Map<Integer, Integer> map : player) {
//			for (Map.Entry<Integer, Integer> entry: map.entrySet()) {
//		        int key = entry.getKey();
//		        int val=entry.getValue();
//		        responseTimer.setplayerID(id);
//				responseTimer.setTime(time);
//		    }
//		}
		responseTimer.setplayerID(array[0]);
		responseTimer.setTime(array[1]);
		System.out.println("Value of time is: "+time);
	}
}