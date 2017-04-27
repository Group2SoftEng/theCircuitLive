<?php
error_reporting(E_ALL);
require_once "functions.php";
require_once "chat_functions.php";

$con = get_connection();

$username_one = username_to_id($con, $_POST['username1']);
$username_two = username_to_id($con, $_POST['username2']);

if (chat_exists($username_one, $username_two)) {
    echo "ok";
}
else {
    echo "no";
}
mysqli_close($con);
?>