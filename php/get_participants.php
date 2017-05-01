<?php
error_reporting(E_ALL);
include "functions.php";

$con = get_connection();
$users = get_participants($con);

echo $users;
//var_dump(retrieve_user_events1($con, 900));
mysqli_close($con);
?>