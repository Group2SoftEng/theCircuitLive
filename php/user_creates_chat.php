<?php
error_reporting(E_ALL | STRICT);
require_once "functions.php";
require_once "chat_functions.php";

//$user1 = $_POST['user_one'];
//$user2 = $_POST['user_two'];
$user1 = "66";
$user2 = "74";

$con = get_connection();
if (chat_exists($user1, $user2)) {
    echo "ayy";
}
else {
    create_chat($user1,$user2);
}
mysqli_close($con);
?>