<?php
error_reporting(E_ALL);
require_once "functions.php";
require_once "chat_functions.php";

$con = get_connection();
$username = $_POST['username'];
$password = $_POST['password'];
$recip_id = username_to_id($con, $_POST['recipient']);
$messages = get_chat($username, $password, $recip_id);
echo end($messages);

mysqli_close($con);
?>