<?php
error_reporting(E_ALL);

require_once "functions.php";

$username = $_POST["username"];
$password = $_POST["password"];

$con = get_connection();

if (user_login($con, $username, $password) == 1) {
    echo "Success";
}

else {
    echo "Incorrect username or password";
}

mysqli_close($con);
?>