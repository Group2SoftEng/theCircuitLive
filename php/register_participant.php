<?php
error_reporting(E_ALL);
include "functions.php";

$con = get_connection();
if (!$con) {
    echo "could not connect";
}
else {
    $username = $_POST["username"];
    $password = $_POST["user_password"];

    mysqli_begin_transaction($con); // Start transaction

    mysqli_query($con, //Insert new User to parent table
                 "INSERT INTO users (user_id, username, user_password) VALUES ('null', '$username', '$password');") or die("error 1"); 

    mysqli_query($con, //Add reference to the newely created user
                 "INSERT INTO participant (user_id) VALUES (LAST_INSERT_ID());") or die("error 2");

    mysqli_commit($con);

    ///$result = $sql->query($sql); 
    //$con->begin_transaction();
}


mysqli_close($con);
?>