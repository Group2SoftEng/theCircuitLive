<?php
include 'functions.php';

$user="hayddqta_softeng";
$password="Team_Account05!";
$dbname= "hayddqta_SoftEngSandbox";
$con=mysqli_connect("localhost",$user,$password, $dbname);

if(!$con) {
	echo "could not connect" ;
}
else
{
	/*
	 * To change the number of events retrieved change limit 4 to limit whatever number you want
	 */
	$sql = "SELECT * from events_app WHERE event_date > NOW() order by event_date ASC limit 6";
	$result = mysqli_query($con, $sql) or die ("error");
	$emparray = array();
	while ($row = $result->fetch_assoc())
	{
		/*
		 * Create a temp array with string indexes
		 * ( Compare the temp index names with the Events and Event objects in the c# code)
		 */
		$temp["EventId"] = $row["event_id"];
		$temp["EventTitle"] = $row["event_title"];
		$temp["EventImg"] = $row["event_img"];
		$temp["EventTopic"] = $row["event_topic"];
		$temp["EventDate"] = $row["event_date"];
		$temp["EventDescription"] = $row["event_desc"];
		$temp["EventSignUpUrl"] = $row["event_url"];

		/*
		 * For each event, create a query that selects all the speakers associated with that event
		 */
		$sql2 = "SELECT a.* FROM speakers_app a 
		INNER JOIN speakers_events_relationship b
		ON a.speaker_id = b.speaker_id WHERE
		event_id =" . $row["event_id"];

		/*
		 * create temp array to be used in the nested loop
		 */
		$tempSpeakerArray = array();

		/*
		 * execute the query 
		 */
		$result2 = mysqli_query($con, $sql2);

		/*
		 * The goal is to get all the speakers associated with an event in its own array
		 */
		while ($row2 = $result2->fetch_assoc())
		{
			$temp2["SpeakerId"] = $row2["speaker_id"];
			$temp2["SpeakerName"] = $row2["speaker_name"];
			$temp2["SpeakerImg"] = $row2["speaker_img"];
			$temp2["SpeakerDescription"] = $row2["speaker_desc"];
			$temp2["SpeakerUrl"] = $row2["speaker_url"];
			array_push($tempSpeakerArray, $temp2); // push the result into the tempspeaker array
		}
		$temp["EventSpeakers"] = $tempSpeakerArray; // before going to the next event, add the speaker info array to the end of this one
		array_push($emparray, $temp); // push this onto the emparray
	}
	echo json_encode(array("EventSet"=>$emparray, JSON_NUMERIC_CHECK)); 
	mysqli_close($con);
}

?>
