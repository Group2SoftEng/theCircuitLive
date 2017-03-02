<?php
include "functions.php";
error_reporting(E_ALL);
/*
 * given the proper post keys returns a user that matches criteria
 **/
$con = get_connection();
$username = $_POST["username"];
$password = $_POST["password"];
echo get_user($con, $username, $password);
mysqli_close($con);
?>