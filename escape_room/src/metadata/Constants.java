package metadata;

/**
 * The Constants class stores important variables as constants for later use.
 */
public class Constants {

    // Request (1xx) + Response (2xx)

    // RequestLogin should be renamed to RequestCreate
    public final static short CMSG_AUTH = 101;
    public final static short SMSG_AUTH = 201;

    public final static short CMSG_HEARTBEAT = 102;
    public final static short SMSG_HEARTBEAT = 202;

    public final static short CMSG_PLAYERS = 103;
    public final static short SMSG_PLAYERS = 203;

    public static final short CMSG_TEST = 104;
    public static final short SMSG_TEST = 204;
    
    public static final short CMSG_TIMER = 105;
    public static final short SMSG_TIMER = 205;
    
    public static final short CMSG_WELCOME_PLAYER = 106;
    public static final short SMSG_WELCOME_PLAYER = 206;
    
    public final static short CMSG_PLAYER_JOIN = 107;
    public final static short SMSG_PLAYER_JOIN = 207;

    public final static short CMSG_MOVE = 131;
    public final static short SMSG_MOVE = 231;
    
    public final static short CMSG_READY = 141;
    public final static short SMSG_READY = 241;

    public final static short CMSG_START = 142;
    public final static short SMSG_START = 242;

    public final static short CMSG_UNREADY = 143;
    public final static short SMSG_UNREADY = 243;

    public final static short CMSG_CHAT = 333;
    public final static short SMSG_CHAT = 433;

    public final static short CMSG_LIGHT= 144;
    public final static short SMSG_LIGHT = 244;

    public final static short CMSG_P2CORRECT= 145;
    public final static short SMSG_P2CORRECT = 245;

    public final static short CMSG_P2INCORRECT= 146;
    public final static short SMSG_P2INCORRECT = 246;
    public final static short CMSG_LOGIN = 108;
    public final static short SMSG_LOGIN = 208;

    // Other
    public static final String CLIENT_VERSION = "1.00";


}
