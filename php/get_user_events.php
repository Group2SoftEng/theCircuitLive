<?php
error_reporting(E_ALL);
require_once "functions.php";

$con = get_connection();
//second param is participant id i'm guessing we will be passing this
//over from c#

$participant_id = $_POST['id'];
echo retrieve_user_events($con, 8);

mysqli_close($con);
?>
