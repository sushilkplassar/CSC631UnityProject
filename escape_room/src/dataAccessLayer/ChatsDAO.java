package dataAccessLayer;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

public class ChatsDAO {

    private ChatsDAO() {
    }

    public static void insertChats(int playerId, String message) throws  SQLException{
        String query = "INSERT INTO `Chats` (`player_id`, `message` ) VALUES (?,?)";

        Connection connection = null;
        PreparedStatement pstmt = null;

        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            pstmt.setInt(1, playerId);
            pstmt.setString(2, message);
            pstmt.executeUpdate();
        }
        catch (SQLException e){
            e.printStackTrace();
        }
        finally {
            if (connection != null) {
                connection.close();
            }
        }
    }
}
