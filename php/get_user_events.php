<?php
error_reporting(E_ALL);
require_once "functions.php";
/*
 * given the proper post key returns a json-formatted-string that represents the corresponding user
 *
 **/
$con = get_connection();
//second param is participant id i'm guessing we will be passing this
//over from c#

$participant_id = $_POST['id'];
echo retrieve_user_events($con, 8);

mysqli_close($con);
?>
