<?php 
require_once "functions.php";
require_once "chat_functions.php";

$username = $_POST['username'];
$password = $_POST['password'];

echo get_users_chatted($username, $password);
?>
