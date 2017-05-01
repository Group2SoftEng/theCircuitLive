<?php
include "functions.php";
error_reporting(E_ALL);

$con = get_connection();
$username = $_POST["username"];
$password = $_POST["user_password"];
echo get_user($con, $username, $password);
mysqli_close($con);
?>
