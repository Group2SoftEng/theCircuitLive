<?php
error_reporting(E_ALL);
require_once "functions.php";
require_once "chat_functions.php";

$username = $_POST['username'];
$password = $_POST['password'];
$search_term = $_POST['search'];
//"jfoley21", "Hello0123!", "a"

echo retrieve_user_matches($username, $password, $search_term);
?>