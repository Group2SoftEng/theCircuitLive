<?php
error_reporting(E_ALL);
require_once "functions.php";

$con = get_connection();

$user_id = $_POST["user_id"];

echo get_individual_user_info($con, $user_id);
mysqli_close($con);
?>