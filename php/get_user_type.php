<?php
error_reporting(E_ALL);
include "functions.php";

$username = $_POST["username"];
$con = get_connection();

echo get_user_type($con, $username);

mysqli_close($con);
?>