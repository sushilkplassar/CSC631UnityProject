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

public class RequestGetTopScore extends GameRequest {
    private ResponseGetTopScore responseTimer;

    public RequestGetTopScore() {
    	responses.add(responseTimer = new ResponseGetTopScore());
    }

	@Override
	public void parse() throws IOException {
		System.out.println("***In RequestTimer Protocol***");
	}

	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		String[] array = GamesDAO.getTopScorers();
		System.out.println("***PlayerID received from DB: " + array[0]);
		System.out.println("***TIme received from DB: " + array[1]);
		responseTimer.setplayerID(array[0]);
		responseTimer.setTime(array[1]);
	}
}