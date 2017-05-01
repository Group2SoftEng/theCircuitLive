<?php
error_reporting(E_ALL);
include "functions.php";

$con = get_connection();
if (!$con) {
    echo "could not connect";
}
else {
    $username = $_POST["username"];
    $password = $_POST["password"];

    mysqli_begin_transaction($con);
    mysqli_query($con,
                 "INSERT INTO users (user_id, username, user_password) VALUES ('null', '$username', '$password');") or die("error 1");
    mysqli_query($con,
                 "INSERT INTO organizer (user_id) VALUES (LAST_INSERT_ID());") or die("error 2");

    mysqli_commit($con);
    mysqli_close($con);
}


mysqli_close($con);
?>
