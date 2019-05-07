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
	
	public final static short CMSG_LOGIN = 108;
    public final static short SMSG_LOGIN = 208;

    // Organism Type
    public static final short ORGANISM_TYPE_ANIMAL = 0;
    public static final short ORGANISM_TYPE_PLANT = 1;
    // Parameter Type
    public static final short PARAMETER_K = 0;	//Plants Carrying capacity >0
    public static final short PARAMETER_R = 1;	//Plants Growth rate 0-1
    public static final short PARAMETER_X = 2;	//Plants Metabolic rate 0-1
    public static final short PARAMETER_X_A = 3;	//Animals
    public static final short PARAMETER_E = 4; //Animals assimilationEfficiency
    public static final short PARAMETER_D = 5; //Animals predatorInterference
    public static final short PARAMETER_Q = 6; //Animals functionalResponseControl
    public static final short PARAMETER_A = 7; //Animals relativeHalfSaturationDensity
    // Other
    public static final float BIOMASS_SCALE = 1000;
    public static final String CLIENT_VERSION = "1.00";
    public static final int TIMEOUT_SECONDS = 90;
    public static final String CSV_SAVE_PATH = "src/log/";

}
