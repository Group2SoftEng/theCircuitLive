<?php
error_reporting(E_ALL);
require_once "functions.php";

$con = get_connection();

$event_id = $_POST["event_id"];

echo get_individual_event($con, $event_id);
mysqli_close($con);

?>