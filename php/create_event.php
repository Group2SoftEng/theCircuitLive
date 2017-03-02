<?php
error_reporting(E_ALL);
include "functions.php";
/*
 * NOTE: As-is, this page is not secure, and given the proper info will let any requester
 * create an event.
 * given a request with post array containing
 * a post array with event_date, event_title, event_desc, event_topic, event_img and event_url
 * creates an event with the given criteria
 *
 **/
$con = get_connection();

if(!$con)
{
	echo "could not connect" ;
}

else
{
    $event_date = $_POST["event_date"];
    $event_title = $_POST["event_title"];
    $event_desc = $_POST["event_desc"];
    $event_topic = $_POST["event_topic"];
    $event_img = $_POST["event_img"];
    $event_url = $_POST["event_url"];
    $sql =
        "INSERT INTO events_app (event_id,
        event_date,
        event_title,
        event_desc,
        event_topic,
        event_img,
        event_url)
        VALUES (NULL,
        '$event_date',
        '$event_title',
        '$event_desc',
        '$event_topic',
        '$event_img',
        '$event_url');";

	$result = mysqli_query($con, $sql) or die ("error");
    mysqli_close($con);
}
?>
