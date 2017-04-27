<?php
error_reporting(E_ALL);
require_once "functions.php";
require_once "chat_functions.php";
$con = get_connection();
$username = $_POST['username'];
$password = $_POST['password'];
$user2 = username_to_id($con, $_POST['user_two']);
echo json_encode(get_chat($username, $password, $user2));
mysqli_close($con);
?>
