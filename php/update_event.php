<?php
error_reporting(E_ALL);
require_once "functions.php";

$con = get_connection();

//$event_id = $_POST["event_id"];
//update_event($con, $event_id);

    $event_id = $_POST["event_id"];    
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

mysqli_close($con);



?>