package dataAccessLayer;

import model.Player;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class UsersDAO {

    public UsersDAO() {
    }

    public static List<Player> getUsersListFromDB() throws SQLException {
        List<Player> usersList = new ArrayList<>();
        String query = "SELECT * FROM `users`";
        Connection connection = null;
        PreparedStatement pstmt = null;
        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            ResultSet rs = pstmt.executeQuery();
            while (rs.next()) {
                int player_id = rs.getInt("player_id");
                String username = rs.getString("username");
                String password = rs.getString("password");
                Player player = new Player(player_id, username, password,(short) 0,0);
                usersList.add(player);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        finally {
        	connection.close();
        }
        return usersList;
    }

    public static Player getUserFromDbIfCredentialsAreValid(String userName, String userPassword) {
        Player player = null;
        String query = "SELECT * FROM `Users` WHERE `username` = '" + userName + "' AND `password` = '" + userPassword + "'";
        Connection connection = null;
        PreparedStatement pstmt = null;
        PreparedStatement Ipstmt = null;
        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            ResultSet rs = pstmt.executeQuery();
            
            if (rs.next() == false)
            {
                String insertQuery = "INSERT INTO `Users` (username, password) VALUES (?, ?)";
                Ipstmt = connection.prepareStatement(insertQuery);

                Ipstmt.setString(1,userName);
                Ipstmt.setString(2, userPassword);
                Ipstmt.executeUpdate();
                pstmt = connection.prepareStatement(query);
                rs = pstmt.executeQuery();
                while(rs.next()) {
                	int player_id = rs.getInt("player_id");
	                String username = rs.getString("username");
	                String password = rs.getString("password");
	                player = new Player(player_id, username, password,(short) 0,0);
                  };


                System.out.println("new user inserted");
            } 
            else {
            	do {
                	int player_id = rs.getInt("player_id");
	                String username = rs.getString("username");
	                String password = rs.getString("password");
	                player = new Player(player_id, username, password,(short) 0,0);
                  } while (rs.next());

            }
            
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return player;
    }
}