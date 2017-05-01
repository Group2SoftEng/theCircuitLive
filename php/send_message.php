<?php
    require_once "chat_functions.php";
    require_once "functions.php";

    $con = get_connection();
$username = $_POST['username'];
   $password = $_POST['password'];
   $recip_id = username_to_id($con, $_POST['recipient']);
   $message = $_POST['message'];

    //send_chat("jfoley21", "Hello0123!", "74", "awidjawijd");
    echo send_chat($username, $password, $recip_id, $message);
mysqli_close();
?>
