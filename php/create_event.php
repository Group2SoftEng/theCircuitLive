<?php
error_reporting(E_ALL);
include "functions.php";

$con = get_connection();

if(!$con)
{
	echo "could not connect" ;
}

else
{
    mysqli_begin_transaction($con);
    $event_date = $_POST["event_date"];
    $organizer_id = $_POST["organizer_id"];
    $event_title = $_POST["event_title"];
    $event_desc = $_POST["event_desc"];
    $event_topic = $_POST["event_topic"];
    $event_img = $_POST["event_img"];
    $event_url = $_POST["event_url"];
    $sql =
        "INSERT INTO events (event_id,
        organizer_id,
        event_date,
        event_title,
        event_desc,
        event_topic,
        event_img,
        event_url)
        VALUES (NULL,
        '$organizer_id',
        '$event_date',
        '$event_title',
        '$event_desc',
        '$event_topic',
        '$event_img',
        '$event_url');";

	$result = mysqli_query($con, $sql) or die ("error1");
	/*$speaker_name = $_POST["speaker_name"];
	$speaker_desc = $_POST["speaker_desc"];
	$speaker_img = $_POST["speaker_img"];
	$sql2 = "INSERT INTO speakers (speaker_name,
			speaker_desc,
			speaker_img)
			VALUES ('$speaker_name',
				'$speaker_desc',
				'$spaker_img');";
                $result2 = mysqli_query($con, $sql2) or die ("error2");*/

    echo mysqli_insert_id($con);
    mysqli_commit($con);
    mysqli_close($con);
}
?>
