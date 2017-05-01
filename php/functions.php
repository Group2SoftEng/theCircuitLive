<?php
error_reporting(E_ALL);

//general/////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////GENERAL UTILITY PHP FUNCTIONS : ////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////DO NOT EDIT THESE FUNCTIONS EVER ////////////////////////////////////////////////////////
//                                                                                                 //
// retrieves credentials from behind front facing website                                          //
function get_content() {                                                                           //
    $info= explode("\n", file_get_contents("/home/hayddqta/softeng05_config/db_config.txt"));      //
    $res = array(                                                                                  //
        "name" => $info[0],                                                                        //
        "password" => $info[1],                                                                    //
        "database" => $info[2],                                                                    //
        "address" => $info[3]                                                                      //
    );                                                                                             //
    //                                                                                             //
    return $res;                                                                                   //
}                                                                                                  //
//                                                                                                 //
//  Establish connection with databse and return connection                                        //
function get_connection()                                                                          //
{                                                                                                  //
    $con_details = get_content();                                                                  //
	$con = mysqli_connect(                                                                         //
        $con_details["address"],                                                                   //
        $con_details["name"],                                                                      //
        $con_details["password"],                                                                  //
        $con_details["database"]                                                                   //
    );                                                                                             //
	return $con;                                                                                   //
}                                                                                                  //
//                                                                                                 //
//                                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////////////////////

function array_content_is_null($arr) {
    $is_empt = false;
    foreach($arr as $arr_item) {
        if (empty($arr_item)) {
            $is_empt = true;
        }
    }
    return $is_empt;
}

//
/*
 * match_arr_contents : array[ANY], regex_string --> string
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

//
/*
 * all_arr_contents_matched : array[string],
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

//
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

//
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////





//newphp///////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
/////////////////////////NEW PHP FUNCTIONS/////////////////////////////////////
///////////////////////////THAT WILL REPLACE///////////////////////////////////
/////////////////////////////THE OLD ONES//////////////////////////////////////
///////////////////////////////EVENTUALLY//////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////

/////////////// get_participant : mysqli_connection, stirng, string --> JsonObject
/////////////// given a valid username and password retrieves a json object of participant
///////////////
function get_participant($connection, $username, $password) {
    $sql = "SELECT * FROM users WHERE username = '"
         . $username
         . "' AND user_password ='"
         . $password
         . "'" ;

    $user = array();

    if ($connection) {
        $users = mysqli_query($connection, $sql);
        while ($result = $users->fetch_assoc()) {
            $user["Id"] = $result["user_id"];
            $user["UserName"] = $result["username"];
            $user["Password"] = $result["user_password"];
            $user["FirstName"] = $result["user_first"];
            $user["LastName"] = $result["user_last"];
            $user["Email"] = $result["user_email"];
            $user["ProfilePicture"] = $result["user_profile_picture"];
            $user["State"] = $result["user_state"];
            $user["PhoneNumber"] = $result["user_phone"];
            $user["Zip"] = $result["user_zip"];
            $user["Address"] = $result["user_address"];
            $user["AboutMe"] = $result["user_about_me"];
            $user["City"] = $result["user_city"];

            $user["EventsAttending"] =  retrieve_user_events(
                $connection
                , $result["participant_id"]);
        }
        return json_encode($user, JSON_NUMERIC_CHECK);
    }

}

/////////////// NOTE:
/////////////// get_participants : mysqli_connection --> JsobObject representing an array of participants
///////////////
///////////////
function get_participants($con) {
    $sql = "SELECT users.* \n"
         . "FROM users \n"
         . "INNER JOIN participant \n"
         . "ON users.user_id = participant.user_id LIMIT 0, 30 ";

    $user = array();
    $all_users = array();
    $users = mysqli_query($con, $sql);
    while($result = $users->fetch_assoc()) {
        $user["Id"] = $result["user_id"];
        $user["UserName"] = $result["username"];
        $user["Password"] = "REDACTED";
        $user["FirstName"] = $result["user_first"];
        $user["LastName"] = $result["user_last"];
        $user["Email"] = $result["user_email"];
        $user["ProfilePicture"] = $result["user_profile_picture"];
        $user["State"] = $result["user_state"];
        $user["PhoneNumber"] = $result["user_phone"];
        $user["Zip"] = $result["user_zip"];
        $user["Address"] = $result["user_address"];
        $user["AboutMe"] = $result["user_about_me"];
        $user["City"] = $result["user_city"];

        $user["EventsAttending"] =  retrieve_user_events1(
            $con
            , $user["Id"]);
        array_push($all_users, $user);
    }
    return json_encode($all_users, JSON_NUMERIC_CHECK);
}

/////////////// NOTE:
/////////////// get_organizers : mysqli_connection --> JsonObject representing an array of organizers
///////////////
///////////////
function get_organizers($con) {
    $sql = "SELECT users.* \n"
         . "FROM users \n"
         . "INNER JOIN organizer \n"
         . "ON users.user_id = organizer.user_id LIMIT 0, 30 ";

    $user = array();
    $all_users = array();
    $users = mysqli_query($con, $sql);
    while($result = $users->fetch_assoc()) {
        $user["Id"] = $result["user_id"];
        $user["UserName"] = $result["username"];
        $user["Password"] = "REDACTED";
        $user["FirstName"] = $result["user_first"];
        $user["LastName"] = $result["user_last"];
        $user["Email"] = $result["user_email"];
        $user["ProfilePicture"] = $result["user_profile_picture"];
        $user["State"] = $result["user_state"];
        $user["PhoneNumber"] = $result["user_phone"];
        $user["Zip"] = $result["user_zip"];
        $user["Address"] = $result["user_address"];
        $user["AboutMe"] = $result["user_about_me"];
        $user["City"] = $result["user_city"];

        $user["EventsAttending"] =  retrieve_user_events1(
            $con
            , $result["user_id"]);

        array_push($all_users, $user);

    }
    return json_encode($all_users, JSON_NUMERIC_CHECK);
}



/////////////// NOTE:
///////////////
///////////////
function username_exists1($connection, $username) {
    $query = "SELECT username FROM users WHERE username = '$username'";
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

///////////////
///////////////
///////////////
function user_join_event($connection, $user_id, $event_id) {

	if(!$connection) {
		echo "Could not connect!";
	}

	else {
		$sql = "INSERT INTO user_joins_event(
			      	user_id,
			      	event_id
			      	)
			      	VALUES (
			      	$user_id,
			     	$event_id
			      	);";

		$result = mysqli_query($connection, $sql) or die ("error");
	}
}

// NOTE: username_to_id : mysqli_connection, username[STRING]
/////////////// PRECONDITION: username exists
/////////////// Returns Id associated with a given username
/////////////// b
function username_to_id($connection, $username) {
    $id = mysqli_query($connection,
                       "SELECT user_id FROM users WHERE username LIKE '$username'")
        ->fetch_assoc()["user_id"];
    return $id;
}

// NOTE: id_to_username : mysqli_connection, username[STRING]
/////////////// PRECONDITION: id exists
/////////////// Returns username associated with a given id
/////////////// 
function id_to_username($connection, $id) {
    $username = mysqli_query($connection,
                       "SELECT username FROM users WHERE user_id = $id")
        ->fetch_assoc()["username"];
    return $username;
}


// NOTE: retrieve_user_events mysqli_connectin
///////////////
///////////////
///////////////
function retrieve_user_events1($connection, $user_id) {

    $sql = "SELECT e.* 
             FROM events e 
             INNER JOIN user_joins_event uje
             ON e.event_id = uje.event_id
             WHERE uje.user_id = $user_id";

    $result = mysqli_query($connection, $sql) or die("error in retrieve user event");
    $events = array();

    while($event_row = $result->fetch_assoc()){
        $temp["EventId"] = $event_row["event_id"];
        $temp["EventTitle"] = $event_row["event_title"];
        $temp["EventImg"] = $event_row["event_img"];
        $temp["EventTopic"] = $event_row["event_topic"];
        $temp["EventDate"] = $event_row["event_date"];
        $temp["EventDescription"] = $event_row["event_desc"];
        $temp["OrganizerId"] = $event_row["organizer_id"];

        array_push($events, $temp);
    }
    return $events;

}

function update_event($con, $event_id)
{
    $event_date = $_POST["event_date"];
    $event_title = $_POST["event_title"];
    $event_desc = $_POST["event_desc"];
    $event_topic = $_POST["event_topic"];
    $event_img = $_POST["event_img"];
    $event_url = $_POST["event_url"];

    $sql =
    	"UPDATE events
    	SET event_date = '$event_date',
    	    event_title = '$event_title',
    	    event_desc = '$event_desc',
    	    event_topic = '$event_topic',
    	    event_img = '$event_img',
    	    event_url = '$event_url'
    	    WHERE event_id = '$event_id';";

    $result = mysqli_query($con, $sql) or die ("error");
}

function delete_event($con, $event_id)
{
	$sql = "DELETE FROM events
	WHERE event_id = '$event_id';";

	$result = mysqli_query($con, $sql) or die ("error");
}

// NOTE: user_login1 : mysqli_connection, username[STRING], password[STRING] --> bool
/////////////// Returns true if username and password success
/////////////// Returns false otherwise
///////////////
function user_login1($connection, $username, $password) {
	$query = "SELECT username FROM users WHERE username LIKE '"
           . $username
           . "' AND user_password LIKE '"
           . $password
           . "'";
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


// NOTE: get_user_type : mysqli_connection, string --> string
/////////////// Returns Participant if in participants
/////////////// Returns Organizer if in Organizer
/////////////// Returns none if does none exists
function get_user_type($connection, $username) {
    $type = "";
    $result = mysqli_query($connection,
                           "SELECT * FROM users WHERE username LIKE '$username'"
    );

    if ($result->num_rows === 0) {
        return "none";
    }

    else {
        $id = mysqli_query($connection,
                           "SELECT user_id FROM users WHERE username LIKE '$username'")->fetch_assoc()["user_id"];

        $result = mysqli_query($connection,
                               "SELECT * FROM organizer WHERE user_id = '$id'");

        if ($result->num_rows > 0 ) {
            $type .= "organizer";
        }

        $result = mysqli_query($connection,
                               "SELECT * FROM participant WHERE user_id LIKE '$id'");

        if ($result->num_rows > 0 ) {
            $type .= "participant";
        }
        return $type;
    }
}

// NOTE: get_user_type : mysqli_connection, string --> string
/////////////// Returns Participant if in participants
/////////////// Returns Organizer if in Organizer
/////////////// Returns none if does none exists
function get_user_type_by_id($connection, $user_id) {
    $type = "";
    $result = mysqli_query($connection,
                           "SELECT * FROM users WHERE user_id = $user_id"
    );

    if ($result->num_rows == 0) {
        return "none";
    }

    else {
        $result = mysqli_query($connection,
                               "SELECT * FROM organizer WHERE user_id = $user_id");

        if ($result->num_rows > 0 ) {
            $type .= "organizer";
        }

        $result = mysqli_query($connection,
                               "SELECT * FROM participant WHERE user_id = $user_id");

        if ($result->num_rows > 0 ) {
            $type .= "participant";
        }
        return $type;
    }

    return "none";
}



/////////////// NOTE: 
/////////////// Ignores user type and retrieves parent class info
///////////////
///////////////
function get_user($connection, $username, $password) {
    $sql = "SELECT * FROM users WHERE username = '" . $username . "' AND user_password ='" . $password . "'" ;
    $user = array();

    if ($connection) {
        $users = mysqli_query($connection, $sql);
        while ($result = $users->fetch_assoc()) {
            $user["Id"] = $result["user_id"];
            $user["UserName"] = $result["username"];
            $user["Password"] = $result["user_password"];
            $user["FirstName"] = $result["user_first"];
            $user["LastName"] = $result["user_last"];
            $user["Email"] = $result["user_email"];
            $user["ProfilePicture"] = $result["user_profile_picture"];
            $user["State"] = $result["user_state"];
            $user["PhoneNumber"] = $result["user_phone"];
            $user["Zip"] = $result["user_zip"];
            $user["Address"] = $result["user_address"];
            $user["AboutMe"] = $result["user_about_me"];
            $user["City"] = $result["user_city"];
            $user["EventsAttending"] =  retrieve_user_events1($connection, $result["user_id"]);

        }

        return json_encode($user, JSON_NUMERIC_CHECK);
    }

}
function get_individual_event($con, $event_id)
{
	$sql = "SELECT * 
	FROM events
	WHERE event_id = '$event_id';";
	
	$event = array();
	
	if($con) {
		$event1 = mysqli_query($con, $sql);
		while($result = $event1->fetch_assoc()) {
			$event["EventTitle"] = $result["event_title"];
			$event["EventTopic"] = $result["event_topic"];
			$event["EventDescription"] = $result["event_desc"];
			$event["EventSignUpUrl"] = $result["event_url"];
			$event["EventDate"] = $result["event_date"];
			$event["EventImg"] = $result["event_img"];
		}
		return json_encode($event, JSON_NUMERIC_CHECK);
	}

}

function get_individual_user_info($con, $user_id)
{
	$sql = "SELECT * 
	FROM users
	WHERE user_id= '$user_id';";
	
	$user_info= array();
	
	if($con) {
		$user1= mysqli_query($con, $sql);
		while($result = $user1->fetch_assoc()) {
			$user_info["Id"] = $result["user_id"];
            		$user_info["UserName"] = $result["username"];
            		$user_info["Password"] = $result["user_password"];

		}
		return json_encode($event, JSON_NUMERIC_CHECK);
	}

}


/////////////// NOTE: 
///////////////
///////////////
///////////////
function admin_login($connection, $username, $password) {
	$query = "SELECT admin_username FROM admins WHERE admin_username = '" . $username . "' AND admin_password = '" . $password . "'";
	$exists = false;

	if($connection)
	{
		$users = mysqli_query($connection, $query) or die("error");
        while($result = $users->fetch_assoc()) {
            $exists = true;
        }
	}

    if ($exists === 1) {
        echo "yay";
    }
	return $exists;
}


///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////



function retrieve_events($conn, $event_number) {

    $sql = "SELECT * from events WHERE event_date > NOW() order by event_date ASC limit $event_number";
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
        $temp1["OrganizerId"] = $event_row["organizer_id"];

        $sql_inner = "SELECT a.* FROM speakers a 
		INNER JOIN speaker_event_relationships b
		ON a.speaker_id = b.speaker_id WHERE
		event_id =" . $event_row["event_id"];

        $speaker_array = array();
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




//attempt log in with param credentials
function user_login($connection, $username, $password) {
	$query = "SELECT user_name FROM participants WHERE user_name = '" . $username . "' AND password = '" . $password . "'";
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

//attempt log in with param credentials
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
 * Given a connection ($connection) and a string ($participant_id)
 *
 **/
function username_exists($connection, $username) {
    $query = "SELECT user_name FROM participants WHERE user_name = '$username'";
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



//
function participant_join_event($connection, $participant_id, $event_id) {

	if(!$connection) {
		echo "Could not connect!";
	}

	else {
		$sql = "INSERT INTO participant_event_relationships(
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
             FROM events e 
             INNER JOIN participant_event_relationships per
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

/*function user_profile_img_update($con, $user_id, $img_url) {
	 $sql = "UPDATE users 
	 	 SET user_profile_picture = '$img_url'
	 	 WHERE user_id = '$user_id'";
	 	 
	 	 $result = mysqli_query($con, $sql);
}*/

function event_img_update($con, $event_id, $img_url) {
	 $sql = "UPDATE events
	 	 SET event_img= '$img_url'
	 	 WHERE event_id= '$event_id'";
	 	 
	 	 $result = mysqli_query($con, $sql);
}


/*
 * Given a connection ($connection) and a participant name ($participant_name)
 * Retrieves all events associated with a given username.
 **/
function retrieve_username_events($connection, $participant_name) {
    $sql = "SELECT participant_id FROM participants where user_name = '$participant_name'";
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

    $sql = "UPDATE participants
            SET phone = '$phone',
                first_name = '$first',
                last_name = '$last',
                address_line = '$address',
                about_me = '$about_me'
            WHERE participant_id = '$participant_id';";
    $sql = "SELECT * from participants";
    $result = mysqli_query($connection, $sql) or die ("error");
}

//
function retrieve_user_matches($username, $password, $search_term) {
    $con = get_connection();
    if (user_login1($con, $username, $password)) {
        $sql = "SELECT * FROM users WHERE username LIKE '%" . $search_term .  "%'";
        $users = mysqli_query($con, $sql) or die ("lawdijdliajwd");
        $result = array();
        while($user = $users->fetch_assoc()) {

            $temp["Id"] = $user["user_id"];
            $temp["UserName"] = $user["username"];
            $temp["Password"] = "";
            $temp["FirstName"] = $user["user_first"];
            $temp["LastName"] = $user["user_last"];
            $temp["Email"] = $user["user_email"];
            $temp["ProfilePicture"] = $user["user_profile_picture"];
            $temp["State"] = $user["user_state"];
            $temp["PhoneNumber"] = "";
            $temp["Zip"] = $user["user_zip"];
            $temp["Address"] = $user["user_address"];
            $temp["AboutMe"] = $user["user_about_me"];
            $temp["City"] = $user["user_city"];
            array_push($result, $temp);
        }
    }
    else {
        return "INVALID CREDENTIALS";
    }
    mysqli_close($con);
    return json_encode($result, JSON_NUMERIC_CHECK);
}
?>
