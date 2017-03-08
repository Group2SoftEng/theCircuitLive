<?php
error_reporting(E_ALL);

/*
 * Returns content that will be used in the get_connection function to get a databse connection
 **/
function get_content() {
    $info= explode("\n", file_get_contents("/home/hayddqta/softeng05_config/db_config.txt"));
    $res = array(
        "name" => $info[0],
        "password" => $info[1],
        "database" => $info[2],
        "address" => $info[3]
    );

    return $res;
}

/*
 * Establish connection with databse and return connection
 *
 **/
function get_connection()
{
    $con_details = get_content();
	$con = mysqli_connect(
        $con_details["address"],
        $con_details["name"],
        $con_details["password"],
        $con_details["database"]
    );
	return $con;
}

/*
 * help method given an array determines if it is false.
 *
 **/
function array_content_is_null($arr) {
    $is_empt = false;
    foreach($arr as $arr_item) {
        if (empty($arr_item)) {
            $is_empt = true;
        }
    }
    return $is_empt;
}

/*
 * This method returns a string that states what parts of the array matched
 *
 **/
function match_arr_contents($arr, $reg) {
    $response = "";
    foreach($arr as $arr_index => $arr_item) {
        if (preg_match($reg, $arr_item) === 1) {
            $response .= "Success\n";
        }
        else {
            $response .= "$arr_index is not properly formatted\n";
        }
    }
    return $response;
}

/*
 * returns true if all contents match, otherwise returns false
 *
 **/
function all_arr_contents_matched($arr, $reg) {
    $matches = true;
    foreach($arr as $arr_item) {
        if(preg_match($reg, $arr_item) === 0) {
            $matches = false;
        }
    }
    return $matches;
}

/*
* test : ANY, ANY --> VOID
* Given an actual test result and an expected test result, determines if the two are equal, and then
* prints . for equality, and test failed, for non-equality
**/
function test ($actual_res, $expect_res) {
    if (str_replace(" ", "", $actual_res) === str_replace(" ", "", $expect_res)) {
        echo ".\n";
    }
    else {
        echo "Test Failed";
    }
}

/*
 * retrieve-events : Connection, NatNum --> Json-formatted string
 * retrieves a json formatted string representing Natnum number of events
 **/
function retrieve_events($conn, $event_number) {

    $sql = "SELECT * from events_app WHERE event_date > NOW() order by event_date ASC limit $event_number";
    $result = mysqli_query($conn, $sql) or die("error");
    $events = array();

    while($event_row = $result->fetch_assoc()) {

        $temp1["EventId"] = $event_row["event_id"];
        $temp1["EventTitle"] = $event_row["event_title"];
        $temp1["EventImg"] = $event_row["event_img"];
        $temp1["EventTopic"] = $event_row["event_topic"];
        $temp1["EventDate"] = $event_row["event_date"];
        $temp1["EventDescription"] = $event_row["event_desc"];
        $temp1["EventSignUpUrl"] = $event_row["event_url"];

        $sql_inner = "SELECT a.* FROM speakers_app a 
		INNER JOIN speakers_events_relationship b
		ON a.speaker_id = b.speaker_id WHERE
		event_id =" . $event_row["event_id"];

        $speaker_array = array();
        //$speakers = select($conn, $sql_inner);
		$speakers = mysqli_query($conn, $sql_inner);

        while ($speaker_row = $speakers->fetch_assoc()) {
			$temp2["SpeakerId"] = $speaker_row["speaker_id"];
			$temp2["SpeakerName"] = $speaker_row["speaker_name"];
			$temp2["SpeakerImg"] = $speaker_row["speaker_img"];
			$temp2["SpeakerDescription"] = $speaker_row["speaker_desc"];
			$temp2["SpeakerUrl"] = $speaker_row["speaker_url"];
			array_push($speaker_array, $temp2); 
        }
        $temp1["EventSpeakers"] = $speaker_array;
        array_push($events, $temp1);
    }
    return json_encode(array("EventSet"=>$events, JSON_NUMERIC_CHECK));
}

/*
 * get_user : connection, string, string --> json-formatted-string
 * given a connection, a valid username and password combination, return a json-formatted-string
 * with the given user information
 **/
function get_user($connection, $username, $password) {
    $sql = "SELECT * FROM participant WHERE user_name = '" . $username . "' AND password ='" . $password . "'" ;
    $user = array();

    if ($connection) {
        $users = mysqli_query($connection, $sql);
        while ($result = $users->fetch_assoc()) {
            $user["Id"] = $result["participant_id"];
            $user["UserName"] = $result["user_name"];
            $user["Password"] = $result["password"];
            $user["FirstName"] = $result["first_name"];
            $user["LastName"] = $result["last_name"];
            $user["Email"] = $result["email"];
            $user["ProfilePicture"] = $result["profile_img"];
            $user["State"] = $result["state"];
            $user["PhoneNumber"] = $result["phone"];
            $user["Zip"] = $result["zip"];
            $user["Address"] = $result["address_line"];
            $user["AboutMe"] = $result["about_me"];
            $user["City"] = $result["city"];

            $user["EventsAttending"] =  retrieve_user_events($connection, $result["participant_id"]);

        }

        return json_encode($user, JSON_NUMERIC_CHECK);
    }

}

/*
 * user_login : connection, string, string --> bool
 * Given a working connection, and proper username, password combination, returns if the user exists or not
 **/
function user_login($connection, $username, $password) {
	$query = "SELECT user_name FROM participant WHERE user_name = '" . $username . "' AND password = '" . $password . "'";
	$exists = false;

	if($connection)
	{
		$users = mysqli_query($connection, $query);
        while($result = $users->fetch_assoc()) {
            $exists = true;
        }
	}

	return $exists;
}

/*
 * validate_user : connection, string, string -->
 * Given a working connection, and proper username, password combination, returns if the user exists or not
 **/
function validate_user($connection,$username, $password) {
	$query = "SELECT user_name FROM participant WHERE user_name = '" . $username . "' AND password = '" . $password . "'";
	$exists = false;

	if($connection)
	{
		$users = mysqli_query($connection, $query);
        while($result = $users->fetch_assoc()) {
            $exists = true;
        }
	}

	return $exists;
}

/*
 * username_exists : connection, string --> bool
 * Given a connection ($connection) and a string ($participant_id)
 *
 **/
function username_exists($connection, $username) {
    $query = "SELECT user_name FROM participant WHERE user_name = '$username'";
    $exists = false;

    if($connection)
    {
        $users = mysqli_query($connection, $query);
        while($result = $users->fetch_assoc()) {
            $exists = true;
        }

        return $exists;
    }
}

/*
 * NOTE: function working, but not used yet in the app.
 * NOTE: SIDE-EFFECT : alters participant_event_relationship
 * participant_join_event: connection, string/natnum, string/natnum --> nil
 * given a string that represents a natnum, or a natnum, and another string that represents a natnum, returns nil
 * 
 **/
function participant_join_event($connection, $participant_id, $event_id) {

	if(!$connection) {
		echo "Could not connect!";
	}

	else {
		$sql = "INSERT INTO participant_event_relationship(
			      	participant_id,
			      	event_id
			      	)
			      	VALUES (
			      	$participant_id,
			     	$event_id
			      	);";

		$result = mysqli_query($connection, $sql) or die ("error");
	}
}

/*
 * Given a connection ($connection) and a string ($participant_id)
 * Retrieves a json encoded object with events associated with a particular user id
 **/
function retrieve_user_events($connection, $participant_id) {

     $sql = "SELECT e.* 
             FROM events_app e 
             INNER JOIN participant_event_relationship per
             ON e.event_id = per.event_id
             WHERE per.participant_id = $participant_id";

    $result = mysqli_query($connection, $sql) or die("error in retrieve user event");
    $events = array();

    while($event_row = $result->fetch_assoc()){
        $temp["EventId"] = $event_row["event_id"];
        $temp["EventTitle"] = $event_row["event_title"];
        $temp["EventImg"] = $event_row["event_img"];
        $temp["EventTopic"] = $event_row["event_topic"];
        $temp["EventDate"] = $event_row["event_date"];
        $temp["EventDescription"] = $event_row["event_desc"];

        array_push($events, $temp);
    }
    return $events;

}

/*
 * Given a connection ($connection) and a participant name ($participant_name)
 * Retrieves all events associated with a given username.
 **/
function retrieve_username_events($connection, $participant_name) {
    $sql = "SELECT participant_id FROM participant where user_name = '$participant_name'";
    $result = mysqli_query($connection, $sql);
}

function update_user_profile($connection, $participant_id) {

    $first = $_POST["first_name"];
    $last = $_POST["last_name"];
    $phone = $_POST["phone"];
    $address = $_POST["address_line"];
    //$city = $_POST["city"];
    //$state = $_POST["state"];
    //$zip = $_POST["zip"];
    //$img = $_POST["profile_img"];
    $about_me = $_POST["about_me"];

    $sql = "UPDATE participant
            SET phone = '$phone',
                first_name = '$first',
                last_name = '$last',
                address_line = '$address',
                about_me = '$about_me'
            WHERE participant_id = '$participant_id';";
    $sql = "SELECT * from participant";
    $result = mysqli_query($connection, $sql) or die ("error");
}


?>
