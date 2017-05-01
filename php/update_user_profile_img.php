<?php
error_reporting(E_ALL);
require_once "functions.php";


$con = get_connection();

$user_id = $_POST["user_id"];
$user_profile_picture = $_POST["user_profile_picture"];

$sql = "UPDATE users 
	SET user_profile_picture = '$user_profile_picture'
	WHERE user_id = '$user_id'";
	 	 
$result = mysqli_query($con, $sql) or die("error");


mysqli_close($con);
?>