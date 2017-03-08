<?php
error_reporting(E_ALL);
require_once "functions.php";
/*
 * page that uses retrieve_events function to print a json-formatted-string of 8 events
 *
 **/
$con = get_connection();
echo retrieve_events($con, 8);
mysqli_close($con);
?>