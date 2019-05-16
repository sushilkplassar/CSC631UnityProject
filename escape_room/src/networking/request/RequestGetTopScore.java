package networking.request;

import java.io.IOException;
import dataAccessLayer.GamesDAO;
import networking.response.ResponseGetTopScore;

public class RequestGetTopScore extends GameRequest {
    private ResponseGetTopScore responseTimer;

    public RequestGetTopScore() {
    	responses.add(responseTimer = new ResponseGetTopScore());
    }

	@Override
	public void parse() throws IOException {
	}

	@Override
	public void doBusiness() throws Exception {
		// TODO Auto-generated method stub
		String[] array = GamesDAO.getTopScorers();
		responseTimer.setplayerID(array[0]);
		responseTimer.setTime(array[1]);
	}
}