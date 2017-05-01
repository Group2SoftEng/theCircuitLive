<?php
require_once "functions.php";
require_once "chat_functions.php";
$con = get_connection();

$user1 = username_to_id($con, $_POST['user_one']);
$user2 = username_to_id($con, $_POST['user_two']);

create_chat($user1, $user2);
mysqli_close($con);
?>
